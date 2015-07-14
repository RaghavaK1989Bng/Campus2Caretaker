using BusinessObjects;
using DataTransferObject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Campus2caretaker.Institute
{
    public partial class InstituteLogin : System.Web.UI.Page
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
                e.Authenticated = new BOLogin().CheckInstituteUser(tologin);
                if (e.Authenticated)
                {
                    Session["InstituteID"] = new BOInstituteDetails().GetInstituteId(Login1.UserName);
                    Session["UserName"] = Login1.UserName;

                    DTOInstituteDetails toins = new DTOInstituteDetails();
                    toins.InstituteEmail = Session["UserName"].ToString();
                    toins.InstituteID = int.Parse(Session["InstituteID"].ToString());

                    DataTable dt = new BOInstituteDetails().GetInstituteDetails(toins);

                    Session["LogoPath"] = dt.Rows[0][3].ToString();
                    Session["InstituteName"] = dt.Rows[0][0].ToString();
                    Session["InstituteType"] = dt.Rows[0][6].ToString();

                    Response.Redirect("InstituteDefault.aspx");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}