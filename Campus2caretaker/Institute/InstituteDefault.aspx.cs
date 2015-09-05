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
            if (!IsPostBack)
                LoadStudentsCount(Session["InstituteID"].ToString());
        }

        private void LoadStudentsCount(string instituteId)
        {
            DTOInstituteDetails toins = new DTOInstituteDetails();
            toins.InstituteID = int.Parse(instituteId);

            int? allCount = new BOReport().GetStudentCountReport(toins, "All");
            int? maleCount = new BOReport().GetStudentCountReport(toins, "Male");
            int? femaleCount = new BOReport().GetStudentCountReport(toins, "Female");

            double? allPercent = (double)((double)allCount / double.Parse(Session["MaxStudentsInstitute"].ToString()));
            dvAllCount.InnerText = String.Concat(String.Format("{0:0.00}",(allPercent * 100)).ToString(), "%");
            dvAllCount.Attributes["data-percent"] = (allPercent * 100).ToString();
            lblAllCount.InnerText = allCount.ToString();            
            lblAllCountText.InnerText = "Total Students";

            double? malePercent = (double)((double)maleCount / (double)allCount);
            dvMaleCount.InnerText = String.Concat(String.Format("{0:0.00}", (malePercent * 100)).ToString(), "%");
            dvMaleCount.Attributes["data-percent"] = (malePercent * 100).ToString();
            lblMaleCount.InnerText = maleCount.ToString();
            lblMaleCountText.InnerText = "Male";

            double? femalePercent = (double)((double)femaleCount / (double)allCount);
            dvFemaleCount.InnerText = String.Concat(String.Format("{0:0.00}",(femalePercent * 100)).ToString(), "%");
            dvFemaleCount.Attributes["data-percent"] = (femalePercent * 100).ToString();
            lblFemaleCount.InnerText = femaleCount.ToString();
            lblFemaleCountText.InnerText = "Female";

            //lblMaleStudents.Text = maleCount.ToString();
            //lblFemaleStudents.Text = femaleCount.ToString();
        }
    }
}