using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Campus2caretaker.Institute
{
    public partial class SendSMS : System.Web.UI.Page
    {
        string ckuser, ckpass;
        private HttpWebRequest req;
        private CookieContainer cookieCntr;
        private string strNewValue;
        public static string responseee;
        private HttpWebResponse response;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Response.Cache.SetNoStore();
                clear();
            }

            lnkallstudents.ServerClick += new EventHandler(lnkallstudents_Click);
            lnkbranchwise.ServerClick += new EventHandler(lnkbranchwise_Click);
            lnkindividual.ServerClick += new EventHandler(lnkindividual_Click);
            lnksemesterwise.ServerClick += new EventHandler(lnksemesterwise_Click);

            lnkinternalmarks.ServerClick += new EventHandler(lnkinternalmarks_Click);
            lnkattendance.ServerClick += new EventHandler(lnkattendance_Click);
            lnkpersonalisedmessage.ServerClick += new EventHandler(lnkpersonalisedmessage_Click);
        }

        protected void lnkallstudents_Click(object sender, EventArgs e)
        {
            txtSendTo.Text = string.Empty;
            List<string> contactsList = new BOSms().GetContactsListAll(int.Parse(Session["InstituteID"].ToString()));
            foreach (var item in contactsList)
            {
                txtSendTo.Text += String.Concat(item, ";");
            }
        }

        protected void lnkbranchwise_Click(object sender, EventArgs e)
        {
            dvBranch.Visible = true;
            dvIndividualStudent.Visible = false;
            dvSemester.Visible = false;
        }

        protected void lnkindividual_Click(object sender, EventArgs e)
        {
            dvBranch.Visible = false;
            dvIndividualStudent.Visible = true;
            dvSemester.Visible = false;
        }

        protected void lnksemesterwise_Click(object sender, EventArgs e)
        {
            dvBranch.Visible = false;
            dvIndividualStudent.Visible = false;
            dvSemester.Visible = true;
        }

        protected void lnkinternalmarks_Click(object sender, EventArgs e)
        {
            dvMonthYear.Visible = true;
        }

        protected void lnkattendance_Click(object sender, EventArgs e)
        {
            txtMessage.Text = "";
            dvMonthYear.Visible = true;
            txtMessage.Text = new BOSms().GetSMSTemplate("ATTENDANCEINTIMATIONWITHSUBJECT");
        }

        protected void lnkpersonalisedmessage_Click(object sender, EventArgs e)
        {
            dvMonthYear.Visible = false;
            txtSendTo.ReadOnly = false;
            txtMessage.ReadOnly = false;

        }

        private void clear()
        {
            ddlClass.Items.Clear();
            RefreshClasses();
            RefreshSemesters();
            ListItem selectItem = new ListItem();
            selectItem.Text = "Select";
            selectItem.Value = "Select";
            ddlMonth.Items.Insert(0, selectItem);
            ddlYear.Items.Insert(0, selectItem);

            ddlClass.SelectedIndex = 0;
            ddlMonth.SelectedIndex = 0;
            ddlYear.SelectedIndex = 0;
            ddlSemester.SelectedIndex = 0;

            dvBranch.Visible = false;
            dvIndividualStudent.Visible = false;
            dvSemester.Visible = false;
            dvMonthYear.Visible = false;

            txtSendTo.ReadOnly = true;
            txtMessage.ReadOnly = true;
        }

        private void RefreshSemesters()
        {
            ddlSemester.Items.Clear();
            List<ListItem> items = GetSemesters.GetSemester(Session["InstituteType"].ToString());

            for (int i = 0; i < items.Count; i++)
            {
                ListItem Item = new ListItem(items[i].Text, items[i].Value);
                ddlSemester.Items.Add(Item);
            }

            ListItem SelectItem = new ListItem("Select", "Select");
            ddlSemester.Items.Insert(0, SelectItem);
            ddlSemester.SelectedIndex = 0;
        }

        private void RefreshClasses()
        {
            DataTable dt = new BOStudentRegistration().GetClassesList(Session["InstituteID"].ToString());
            ddlClass.DataSource = dt;
            ddlClass.DataBind();

            ListItem Item = new ListItem("Select", "Select");
            ddlClass.Items.Insert(0, Item);
            ddlClass.SelectedIndex = 0;
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            connect();
            foreach (string mobno in txtSendTo.Text.Split(';'))
            {
                if (!string.IsNullOrEmpty(mobno))
                {
                    sendSms(mobno, txtMessage.Text);
                }
            }
        }

        protected void ddlClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSendTo.Text = string.Empty;
            List<string> contactsList = new BOSms().GetContactsListBranchwise(int.Parse(Session["InstituteID"].ToString()), int.Parse(ddlClass.SelectedValue));
            foreach (var item in contactsList)
            {
                txtSendTo.Text += String.Concat(item, ";");
            }
        }

        protected void ddlSemester_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSendTo.Text = string.Empty;
            List<string> contactsList = new BOSms().GetContactsListSemesterwise(int.Parse(Session["InstituteID"].ToString()), int.Parse(ddlSemester.SelectedValue));
            foreach (var item in contactsList)
            {
                txtSendTo.Text += String.Concat(item, ";");
            }
        }

        public void connect()
        {
            ckuser = "8970978907";
            ckpass = "98445380680";

            try
            {
                this.req = (HttpWebRequest)WebRequest.Create("http://wwwd.way2sms.com/auth.cl");

                this.req.CookieContainer = new CookieContainer();
                this.req.AllowAutoRedirect = false;
                this.req.Method = "POST";
                this.req.ContentType = "application/x-www-form-urlencoded";
                this.strNewValue = "username=" + ckuser + "&password=" + ckpass;
                this.req.ContentLength = this.strNewValue.Length;
                StreamWriter writer = new StreamWriter(this.req.GetRequestStream(), Encoding.ASCII);
                writer.Write(this.strNewValue);
                writer.Close();
                this.response = (HttpWebResponse)this.req.GetResponse();
                this.cookieCntr = this.req.CookieContainer;
                this.response.Close();
                this.req = (HttpWebRequest)WebRequest.Create("http://wwwd.way2sms.com//jsp/InstantSMS.jsp?val=0");
                this.req.CookieContainer = this.cookieCntr;
                this.req.Method = "GET";
                this.response = (HttpWebResponse)this.req.GetResponse();
                responseee = new StreamReader(this.response.GetResponseStream()).ReadToEnd();
                int index = Regex.Match(responseee, "custf").Index;
                responseee = responseee.Substring(index, 0x12);
                responseee = responseee.Replace("\"", "").Replace(">", "").Trim();
                this.response.Close();
                divStatus.InnerText = "connected";
            }
            catch (Exception)
            {
                divStatus.InnerText = "Error connecting to the server...";
            }
        }

        public void sendSms(string mbno, string mseg)
        {
            if ((mbno != "") && (mseg != ""))
            {
                try
                {
                    this.req = (HttpWebRequest)WebRequest.Create("http://wwwd.way2sms.com//FirstServletsms?custid=");
                    this.req.AllowAutoRedirect = false;
                    this.req.CookieContainer = this.cookieCntr;
                    this.req.Method = "POST";
                    this.req.ContentType = "application/x-www-form-urlencoded";
                    this.strNewValue = "custid=undefined&HiddenAction=instantsms&Action=" + responseee + "&login=&pass=&MobNo=" + mbno + "&textArea=" + mseg;

                    this.req.ContentLength = this.strNewValue.Length;
                    StreamWriter writer = new StreamWriter(this.req.GetRequestStream(), Encoding.ASCII);
                    writer.Write(this.strNewValue);
                    writer.Close();
                    this.response = (HttpWebResponse)this.req.GetResponse();

                    this.response.Close();
                    divStatus.InnerText = "Message Sent..... ";
                }
                catch (Exception)
                {
                    divStatus.InnerText = "Error Sending msg....check your connection...";
                }
            }
            else
            {
                divStatus.InnerText = "Mob no or msg missing";
            }
        }
    }
}