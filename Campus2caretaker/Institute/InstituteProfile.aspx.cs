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
    public partial class InstituteProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DTOInstituteDetails toins = new DTOInstituteDetails();
                toins.InstituteID = int.Parse(Session["InstituteID"].ToString());

                DataTable dt = new DataTable();
                dt = new BOInstituteDetails().GetInstituteDetails(toins);

                try
                {
                    txtAddress.Text = String.Concat(dt.Rows[0][1].ToString(), System.Environment.NewLine, dt.Rows[0][8].ToString(), System.Environment.NewLine, dt.Rows[0][9].ToString());
                    txtContactNumber.Text = dt.Rows[0][2].ToString();
                    txtPrincipalName.Text = dt.Rows[0][4].ToString();
                    txtPrincipalContactNumber.Text = dt.Rows[0][5].ToString();
                    txtC2CContact.Text = "info@campus2caretaker.in";
                }
                catch
                {

                }
            }
        }
    }
}