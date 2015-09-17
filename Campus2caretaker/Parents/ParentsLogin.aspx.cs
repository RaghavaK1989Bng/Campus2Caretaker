using BusinessObjects;
using DataTransferObject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Campus2caretaker.Parents
{
    public partial class ParentsLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Response.Cache.SetNoStore();
                Clear();
            }
        }

        private void Clear()
        {
            Password.Visible = false;
            LoginButton.Visible = false;
            lblPassword.Visible = false;
            spnPassword.Visible = false;
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            FailureText.Text = "";

            try
            {
                DTOParentsLoginDetails topLogin = new DTOParentsLoginDetails();

                topLogin.Mobilenumber = MobileNumber.Text;
                topLogin.Otp = Password.Text;
                bool authenticated = new BOParentsLoginDetails().CheckParentsLoginUser(topLogin);
                if (authenticated)
                {
                    Session["ParentsMobileNumber"] = MobileNumber.Text;
                    Response.Redirect("ParentsDefault.aspx");
                }
                else
                {
                    FailureText.Text = "Username or OTP is incorrect.";
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            FailureText.Text = "";

            DTOLogin tologin = new DTOLogin();
            tologin.UserID = MobileNumber.Text;
            bool chkParentsMobileNumber = new BOLogin().CheckParentsMobileNumber(tologin);

            if (chkParentsMobileNumber)
            {
                string otp;
                string email = new BOParentsLoginDetails().GetParentsEmailId(MobileNumber.Text);
                string existingotp = new BOParentsLoginDetails().GetExistingotp(MobileNumber.Text);
                if (!string.IsNullOrEmpty(existingotp))
                {
                    otp = existingotp;
                }
                else
                {
                    RandomStringGenerator randomStringGen = new RandomStringGenerator();
                    randomStringGen.UseSpecialCharacters = false;
                    otp = randomStringGen.Generate(8);
                }
                DTOParentsLoginDetails topLogin = new DTOParentsLoginDetails();

                topLogin.Mobilenumber = MobileNumber.Text;
                topLogin.Otp = otp;
                topLogin.Isused = 0;
                bool sendotp = false;
                if (string.IsNullOrEmpty(existingotp))
                {
                    sendotp = new BOParentsLoginDetails().InsertParentsLoginOTP(topLogin);
                }

                if ((string.IsNullOrEmpty(existingotp) && sendotp) || !string.IsNullOrEmpty(existingotp))
                {
                    string _messageTemplate;
                    _messageTemplate = new BOSms().GetSMSTemplate("OTPPARENTS");


                    #region E-Mail
                    if (!string.IsNullOrEmpty(email))
                    {
                        //Send mail

                        string s_subject = "Information From Campus2Caretaker";
                        string s_msg = String.Concat("Greetings from Campus2Caretaker.", Environment.NewLine, Environment.NewLine, _messageTemplate.Replace("##OTP##", otp)) + Environment.NewLine + Environment.NewLine; 
                        
                        C2CEmail.SendC2CMail(s_msg, s_subject, string.Empty, email, null, null);
                    }
                    #endregion

                    #region SMS
                    C2CSMS.SendSMS(_messageTemplate.Replace("##OTP##", otp), MobileNumber.Text);
                    #endregion

                    btnNext.Visible = false;
                    Password.Visible = true;
                    LoginButton.Visible = true;
                    lblPassword.Visible = true;
                    spnPassword.Visible = true;

                    FailureText.ForeColor = Color.Green;
                    FailureText.Text = "OTP has been sent to your contact details.";
                }
                else
                {
                    FailureText.Text = "An error occured while generating OTP.Please try again after some time";
                }
            }
            else
            {
                FailureText.Text = "Invalid Mobile Number";
            }
        }
    }
}