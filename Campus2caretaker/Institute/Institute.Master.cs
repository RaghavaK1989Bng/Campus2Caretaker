using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Campus2caretaker.Institute
{
    public partial class Institute : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetNoStore();

            string url = "~/uploaded/" + Session["LogoPath"].ToString();
            imgInstituteLogo.Src = url;

            InstituteName.InnerText = Session["InstituteName"].ToString();

            lnkLogout.ServerClick += new EventHandler(lnkLogout_Click);

        }

        private void lnkLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("InstituteLogin.aspx");
        }
    }
}