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

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            try
            {
                DTOLogin tologin = new DTOLogin();
                tologin.UserID = UserName.Text;
                tologin.Password = PasswordEncDec.EncodePasswordToBase64(Password.Text);
                bool authenticated = new BOLogin().CheckAdminUser(tologin);
                if (authenticated)
                {
                    Session["UserName"] = UserName.Text;
                    Response.Redirect("AdminDefault.aspx");
                }
                else
                {
                    FailureText.Text = "Username or Password is incorrect.";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}