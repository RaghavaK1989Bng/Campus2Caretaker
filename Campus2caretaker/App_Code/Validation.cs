using System;
using System.ComponentModel;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Linq;

public static class Validation
{
    public static void DisplayError(this System.Web.UI.ITextControl source, string message)
    {
        var ctrl = source as System.Web.UI.WebControls.WebControl;
        if (ctrl == null)
            return;
        
        ctrl.Attributes["invalid"] = message;
        ctrl.Attributes["invalidVal"] = source.Text;
        ctrl.Page.ClientScript.RegisterStartupScript(ctrl.Page.GetType(), "error_" + ctrl.ID, "$('#" + ctrl.ClientID + "').highlight();", true);

        //display message at top in case missed at control
        Util.DisplayMessage(message);
    }

    /// <summary>
    /// To perform server validation (as a backup to client side validation) call this method on postback in the MasterPage Page_Load method.
    /// </summary>
    public static void PerformValidation(System.Web.UI.Page Page)
    {
        //get postback control
        Control ctrl = null;

        if (!String.IsNullOrEmpty(Page.Request.Params["__EVENTTARGET"]))
            ctrl = Page.FindControl(Page.Request.Params["__EVENTTARGET"]);

        for (int i = 0; ctrl == null && i < Page.Request.Form.Count; i++)
        {
			if (String.IsNullOrEmpty(Page.Request.Form.Keys[i]))
				continue;
			
            string id = Page.Request.Form.Keys[i];

            // handle ImageButton controls ...
            if (id.EndsWith(".x") || id.EndsWith(".y"))
                id = id.Substring(0, id.Length - 2);

            System.Web.UI.Control c = Page.FindControl(id);
            if (c is System.Web.UI.WebControls.Button || c is System.Web.UI.WebControls.ImageButton)
                ctrl = c;
        }

        //if postback ctrl not a button skip valiator checks
        if (ctrl as IButtonControl == null)
            return;

        //retrive validation group if exists otherwise return
        string validationGroup = ctrl.GetType().GetProperty("OnClientClick").GetValue(ctrl, null).ToString();
        Match match = Regex.Match(validationGroup, @"validate\('(.*?)'\)");
        if (match.Groups.Count < 2 || match.Groups[1].Value == "")
            return;
        validationGroup = match.Groups[1].Value;

        bool isvalid = true;

        //validate all controls
        foreach (string id in Page.Request.Form.AllKeys.Where(k => !String.IsNullOrEmpty(k)))
        {
            Control field = Page.FindControl(id);
            System.Web.UI.AttributeCollection attr = null;
            bool disabled = true;
            string value = Page.Request.Form[id];

            if (field is WebControl)
            {
                attr = (field as WebControl).Attributes;
                disabled = !(field as WebControl).Enabled;
            }
            else if (field is HtmlControl)
            {
                attr = (field as HtmlControl).Attributes;
                disabled = (field as HtmlControl).Disabled;
            }

            //do not validate if param is not a control, or control is disabled, or validationgroup is different
            if (disabled || !validationGroup.Equals(attr["validate"], StringComparison.CurrentCultureIgnoreCase))
                continue;

            string type = null;

            if (String.IsNullOrEmpty(value))
            {
                if (!String.IsNullOrEmpty(attr["require"]))
                    type = "require";
            }
            else
            {
                if (!String.IsNullOrEmpty(attr["regular"]) && !String.IsNullOrEmpty(attr["validExpress"]) && !Regex.IsMatch(value, attr["validExpress"]))
                    type = "regular";

                if (!String.IsNullOrEmpty(attr["regular"]) && !String.IsNullOrEmpty(attr["invalidExpress"]) && Regex.IsMatch(value, attr["invalidExpress"]))
                    type = "regular";

                if (!String.IsNullOrEmpty(attr["compare"]) && !String.IsNullOrEmpty(attr["compareTo"]) && value != Page.Request.Form[attr["compareTo"].Replace('_', '$')])
                    type = "compare";

                if (!String.IsNullOrEmpty(attr["invalid"]) && !String.IsNullOrEmpty(attr["invalidVal"]) && value == attr["invalidVal"])
                    type = "invalid";
				
				if (!String.IsNullOrEmpty(attr["email"]))
				{
					try { new System.Net.Mail.MailAddress(value); }
					catch (FormatException) { type = "email"; }
				}
            }

            if (type != null)
            {
                isvalid = false;
                if (ctrl is ITextControl)
                    (ctrl as ITextControl).DisplayError(attr[type]);
                else
                    Util.DisplayMessage(attr[type]);
            }
        }

        //if failed validation, cancel click or command event by removing the event handler
        if (!isvalid)
        {
            EventInfo click = ctrl.GetType().GetEvent("Click");
            EventInfo command = ctrl.GetType().GetEvent("Command");

            BindingFlags flags = BindingFlags.Instance | BindingFlags.NonPublic;
            EventHandlerList eh = (EventHandlerList)ctrl.GetType().GetProperty("Events", flags).GetValue(ctrl, null);
            object entry = eh.GetType().GetField("head", flags).GetValue(eh);

            while (entry != null)
            {
                Delegate handler = (Delegate)entry.GetType().GetField("handler", flags).GetValue(entry);
                try { click.RemoveEventHandler(ctrl, handler); }
                catch (Exception) { }
                try { command.RemoveEventHandler(ctrl, handler); }
                catch (Exception) { }
                entry = entry.GetType().GetField("next", flags).GetValue(entry);
            }
        }
    }
}
