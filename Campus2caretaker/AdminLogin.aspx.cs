using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataTransferObject;
using BusinessObjects;
using System.Web.Security;

namespace Campus2caretaker
{
    public partial class AdminLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Response.Cache.SetNoStore();
            }
        }

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            try
            {
                DTOLogin tologin = new DTOLogin();
                tologin.UserID = Login1.UserName;
                tologin.Password = PasswordEncDec.EncodePasswordToBase64(Login1.Password);
                e.Authenticated = new BOLogin().CheckAdminUser(tologin);
                if (e.Authenticated)
                {
                    Session["UserName"] = Login1.UserName;
                    Response.Redirect("AdminDefault.aspx");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}