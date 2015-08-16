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
    public partial class InstituteDefault : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DTOInternals toint = new DTOInternals();
            toint.InstituteId = int.Parse(Session["InstituteID"].ToString());
            toint.Month = "January";
            toint.Year = "2015";
            //(InternalsChartDS.Select() as DataView).Table = ;

            chartInternals.Series["seriesChartInternals"].XValueMember = "colSubjectName";
            chartInternals.Series["seriesChartInternals"].YValueMembers = "colMarksScored";
            chartInternals.DataSource = new BOInternals().GetInternalsChartDetails(toint);
            chartInternals.DataBind();
        }
    }
}