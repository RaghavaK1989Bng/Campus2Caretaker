﻿using BusinessObjects;
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

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            try
            {
                DTOLogin tologin = new DTOLogin();
                tologin.UserID = UserName.Text;
                tologin.Password = PasswordEncDec.EncodePasswordToBase64(Password.Text);
                bool authenticated = new BOLogin().CheckInstituteUser(tologin);
                if (authenticated)
                {
                    Session["InstituteID"] = new BOInstituteDetails().GetInstituteId(UserName.Text);
                    Session["UserName"] = UserName.Text;

                    DTOInstituteDetails toins = new DTOInstituteDetails();
                    toins.InstituteEmail = Session["UserName"].ToString();
                    toins.InstituteID = int.Parse(Session["InstituteID"].ToString());

                    DataTable dt = new BOInstituteDetails().GetInstituteDetails(toins);

                    Session["LogoPath"] = dt.Rows[0][3].ToString();
                    Session["InstituteName"] = dt.Rows[0][0].ToString();
                    Session["InstituteType"] = dt.Rows[0][6].ToString();
                    Session["MaxStudentsInstitute"] = dt.Rows[0][10].ToString();

                    Response.Redirect("InstituteDefault.aspx");
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