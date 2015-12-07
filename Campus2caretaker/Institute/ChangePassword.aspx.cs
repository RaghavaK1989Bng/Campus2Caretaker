using BusinessObjects;
using DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Campus2caretaker.Institute
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Clear();
            }
        }

        private void Clear()
        {
            txtConfirmPassword.Text = "";
            txtNewPassword.Text = "";
            txtCurrentPassword.Text = "";

        }

        protected void btnChangePassword_Click(object sender, EventArgs e)
        {
            DTOLogin tologin = new DTOLogin();
            tologin.UserID = Session["UserName"].ToString();
            tologin.Password = PasswordEncDec.EncodePasswordToBase64(txtCurrentPassword.Text);
            bool isCurrentPasswordCorrect = new BOLogin().CheckInstituteUser(tologin);

            if (isCurrentPasswordCorrect)
            {
                tologin.Password = PasswordEncDec.EncodePasswordToBase64(txtNewPassword.Text);

                if (new BOLogin().ChangeInstituteUserPassword(tologin))
                {
                    //string script = @"document.getElementById('" + divStatus.ClientID + "').innerHTML='Password changed successfully';var elem = document.createElement('img');elem.setAttribute('src', 'tick.jpg');document.getElementById('" + divStatus.ClientID + "').appendChild(elem);document.getElementById('" + divStatus.ClientID + "').style.color = 'Green';document.getElementById('" + divStatus.ClientID + "').style.fontSize = '1em' ;document.getElementById('" + divStatus.ClientID + "').style.fontWeight = 'bold' ;setTimeout(function(){document.getElementById('" + divStatus.ClientID + "').style.display='none';},4500);";
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "script", script, true);
                    string alertScript = "jAlert('Password Changed Successfully', 'Campus2Caretaker');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertScript", alertScript, true);
                    Clear();
                    Session.Abandon();
                    Response.Redirect("InstituteLogin.aspx");
                }
                else
                {
                    //string script = @"document.getElementById('" + divStatus.ClientID + "').innerHTML='Error';var elem = document.createElement('img');elem.setAttribute('src', 'cross.jpg');document.getElementById('" + divStatus.ClientID + "').appendChild(elem);document.getElementById('" + divStatus.ClientID + "').style.color = 'Red';document.getElementById('" + divStatus.ClientID + "').style.fontSize = '1em' ;document.getElementById('" + divStatus.ClientID + "').style.fontWeight = 'bold' ;setTimeout(function(){document.getElementById('" + divStatus.ClientID + "').style.display='none';},4500);";
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "script", script, true);
                    string alertScript = "jAlert('Error', 'Campus2Caretaker');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertScript", alertScript, true);
                }
            }
            else
            {
                //string script = @"document.getElementById('" + divStatus.ClientID + "').innerHTML='Please enter the valid current password.';var elem = document.createElement('img');elem.setAttribute('src', 'cross.jpg');document.getElementById('" + divStatus.ClientID + "').appendChild(elem);document.getElementById('" + divStatus.ClientID + "').style.color = 'Red';document.getElementById('" + divStatus.ClientID + "').style.fontSize = '1em' ;document.getElementById('" + divStatus.ClientID + "').style.fontWeight = 'bold' ;setTimeout(function(){document.getElementById('" + divStatus.ClientID + "').style.display='none';},4500);";
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "script", script, true);
                string alertScript = "jAlert('Please Enter Valid Current Password', 'Campus2Caretaker');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertScript", alertScript, true);
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }
    }
}