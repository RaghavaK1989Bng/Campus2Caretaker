using BusinessObjects;
using DataTransferObject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;

namespace Campus2caretaker.Institute
{
    public partial class InstituteDefault : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadStudentsCount(Session["InstituteID"].ToString());
                LoadStudentsCountClasswise(Session["InstituteID"].ToString());
            }
        }

        private void LoadStudentsCount(string instituteId)
        {
            DTOInstituteDetails toins = new DTOInstituteDetails();
            toins.InstituteID = int.Parse(instituteId);

            int? allCount = new BOReport().GetStudentCountReport(toins, "All");
            int? maleCount = new BOReport().GetStudentCountReport(toins, "Male");
            int? femaleCount = new BOReport().GetStudentCountReport(toins, "Female");

            double? allPercent = (double)((double)allCount / double.Parse(Session["MaxStudentsInstitute"].ToString()));
            dvAllCount.InnerText = String.Concat(String.Format("{0:0.00}", (allPercent * 100)).ToString(), "%");
            dvAllCount.Attributes["data-percent"] = (allPercent * 100).ToString();
            lblAllCount.InnerText = allCount.ToString();
            lblAllCountText.InnerText = "Total Students";

            double? malePercent = (double)((double)maleCount / (double)allCount);
            dvMaleCount.InnerText = String.Concat(String.Format("{0:0.00}", (malePercent * 100)).ToString(), "%");
            dvMaleCount.Attributes["data-percent"] = (malePercent * 100).ToString();
            lblMaleCount.InnerText = maleCount.ToString();
            lblMaleCountText.InnerText = "Male";

            double? femalePercent = (double)((double)femaleCount / (double)allCount);
            dvFemaleCount.InnerText = String.Concat(String.Format("{0:0.00}", (femalePercent * 100)).ToString(), "%");
            dvFemaleCount.Attributes["data-percent"] = (femalePercent * 100).ToString();
            lblFemaleCount.InnerText = femaleCount.ToString();
            lblFemaleCountText.InnerText = "Female";
        }

        protected void gvClasswiseStrength_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        private void LoadStudentsCountClasswise(string instituteId)
        {
            DTOInstituteDetails toins = new DTOInstituteDetails();
            toins.InstituteID = int.Parse(instituteId);

            DataTable branches = new BOPersonalizeApplication().GetClassesList(instituteId);
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[4] { new DataColumn("colBranchName", typeof(string)),
                            new DataColumn("colTotalCount", typeof(string)),
                            new DataColumn("colMaleCount",typeof(string)) ,
                            new DataColumn("colFemaleCount",typeof(string)) });

            for (int j = 0; j < branches.Rows.Count; j++)
            {
                List<DTOClasswiseCount> allCount = new BOReport().GetStudentCountClasswiseReport(toins, "All", int.Parse(branches.Rows[j][0].ToString()));
                List<DTOClasswiseCount> maleCount = new BOReport().GetStudentCountClasswiseReport(toins, "Male", int.Parse(branches.Rows[j][0].ToString()));
                List<DTOClasswiseCount> femaleCount = new BOReport().GetStudentCountClasswiseReport(toins, "Female", int.Parse(branches.Rows[j][0].ToString()));

                for (int i = 0; i < allCount.Count; i++)
                {
                    string finalMaleCount = "0";
                    if (maleCount.Count > i)
                    {
                        finalMaleCount = maleCount[i].Count.ToString();
                    }

                    string finalFemaleCount = "0";
                    if (femaleCount.Count > i)
                    {
                        finalFemaleCount = femaleCount[i].Count.ToString();
                    }

                    dt.Rows.Add(allCount[i].ClassName, allCount[i].Count.ToString(), finalMaleCount, finalFemaleCount);
                }
            }

            for (int i = 1; i < dt.Columns.Count; i++)
            {
                Series series = new Series();

                foreach (DataRow dr in dt.Rows)
                {
                    int y = Convert.ToInt32(dr[i]);

                    series.Points.AddXY(dr["colBranchName"].ToString(), y);
                }

                chrtStudentsStrengthvsClass.Series.Add(series);
            }
            gvClasswiseStrength.DataSource = dt;
            gvClasswiseStrength.DataBind();
        }
    }
}