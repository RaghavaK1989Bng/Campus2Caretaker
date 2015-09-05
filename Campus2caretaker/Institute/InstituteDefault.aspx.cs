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
                Response.Cache.SetNoStore();
                clear();
            }

            LoadStudentsCount(Session["InstituteID"].ToString());
            LoadStudentsCountClasswise(Session["InstituteID"].ToString());
        }

        private void clear()
        {
            System.Web.UI.WebControls.ListItem selectItem = new System.Web.UI.WebControls.ListItem();
            selectItem.Text = "Select";
            selectItem.Value = "Select";
            ddlAttendanceMonth.Items.Insert(0, selectItem);
            ddlAttendanceYear.Items.Insert(0, selectItem);

            ddlAttendanceMonth.SelectedIndex = 0;
            ddlAttendanceYear.SelectedIndex = 0;

            ddlInternalsMonth.Items.Insert(0, selectItem);
            ddlInternalsYear.Items.Insert(0, selectItem);

            ddlInternalsMonth.SelectedIndex = 0;
            ddlInternalsYear.SelectedIndex = 0;
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

        protected void btnGenerateAttendanceStatistics_Click(object sender, EventArgs e)
        {
            LoadStudentsAttendanceClasswise(Session["InstituteID"].ToString(), ddlAttendanceMonth.SelectedValue, ddlAttendanceYear.SelectedValue);
        }

        private void LoadStudentsAttendanceClasswise(string instituteId, string month, string year)
        {
            DataTable branches = new BOPersonalizeApplication().GetClassesList(instituteId);
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[3] { new DataColumn("colBranchName", typeof(string)),
                            new DataColumn("col35", typeof(string)),
                            new DataColumn("col85",typeof(string)) });
            for (int j = 0; j < branches.Rows.Count; j++)
            {
                List<DTOClasswiseCount> lt85Count = new BOReport().GetStudentAttendanceCountClasswiseReport(Convert.ToInt32(instituteId), "lt85", int.Parse(branches.Rows[j][0].ToString()), month, year);
                List<DTOClasswiseCount> gt85Count = new BOReport().GetStudentAttendanceCountClasswiseReport(Convert.ToInt32(instituteId), "gt85", int.Parse(branches.Rows[j][0].ToString()), month, year);

                int count = 0;
                if (lt85Count.Count > 0)
                {
                    count = lt85Count.Count;
                }
                else
                {
                    count = gt85Count.Count;
                }

                for (int i = 0; i < count; i++)
                {
                    string finallt85Count = "0";
                    if (lt85Count.Count > i)
                    {
                        finallt85Count = lt85Count[i].Count.ToString();
                    }

                    string finalgt85Count = "0";
                    if (gt85Count.Count > i)
                    {
                        finalgt85Count = gt85Count[i].Count.ToString();
                    }

                    dt.Rows.Add(branches.Rows[j][1].ToString(), finallt85Count, finalgt85Count);
                }
            }

            gvAttendanceMonth.DataSource = dt;
            gvAttendanceMonth.DataBind();

            for (int i = 1; i < dt.Columns.Count; i++)
            {
                Series attseries = new Series();

                foreach (DataRow dr in dt.Rows)
                {
                    int y = Convert.ToInt32(dr[i]);

                    attseries.Points.AddXY(dr["colBranchName"].ToString(), y);
                }

                chrtAttendanceMonth.Series.Add(attseries);
            }
        }

        protected void gvAttendanceMonth_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void btnGenerateInternalsStatistics_Click(object sender, EventArgs e)
        {
            LoadInternalsMarksMonthwise(Session["InstituteID"].ToString(), ddlInternalsMonth.SelectedValue, ddlInternalsYear.SelectedValue);
        }

        private void LoadInternalsMarksMonthwise(string instituteId, string month, string year)
        {
            DataTable branches = new BOPersonalizeApplication().GetClassesList(instituteId);

            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[6] { new DataColumn("colBranchName", typeof(string)),
                            new DataColumn("colSubjectName", typeof(string)),
                            new DataColumn("col0", typeof(string)),
                            new DataColumn("col35",typeof(string)),
                            new DataColumn("col60",typeof(string)),
                            new DataColumn("col85",typeof(string)) });

            for (int j = 0; j < branches.Rows.Count; j++)
            {
                DataTable subjects = new BOPersonalizeApplication().GetSubjectsList(instituteId, int.Parse(branches.Rows[j][0].ToString()));

                for (int p = 0; p < subjects.Rows.Count; p++)
                {
                    List<DTOClasswiseCount> col0Count = new BOReport().GetStudentInternalsCountClasswiseReport(Convert.ToInt32(instituteId), "col0", int.Parse(branches.Rows[j][0].ToString()), month, year, int.Parse(subjects.Rows[p][0].ToString()));
                    List<DTOClasswiseCount> col35Count = new BOReport().GetStudentInternalsCountClasswiseReport(Convert.ToInt32(instituteId), "col35", int.Parse(branches.Rows[j][0].ToString()), month, year, int.Parse(subjects.Rows[p][0].ToString()));
                    List<DTOClasswiseCount> col60Count = new BOReport().GetStudentInternalsCountClasswiseReport(Convert.ToInt32(instituteId), "col60", int.Parse(branches.Rows[j][0].ToString()), month, year, int.Parse(subjects.Rows[p][0].ToString()));
                    List<DTOClasswiseCount> col85Count = new BOReport().GetStudentInternalsCountClasswiseReport(Convert.ToInt32(instituteId), "col85", int.Parse(branches.Rows[j][0].ToString()), month, year, int.Parse(subjects.Rows[p][0].ToString()));

                    int count = Max(col0Count.Count, col35Count.Count, col60Count.Count, col85Count.Count);

                    for (int i = 0; i < count; i++)
                    {
                        string finalcol0Count = "0";
                        if (col0Count.Count > i)
                        {
                            finalcol0Count = col0Count[i].Count.ToString();
                        }

                        string finalcol35Count = "0";
                        if (col35Count.Count > i)
                        {
                            finalcol35Count = col35Count[i].Count.ToString();
                        }

                        string finalcol60Count = "0";
                        if (col60Count.Count > i)
                        {
                            finalcol60Count = col60Count[i].Count.ToString();
                        }

                        string finalcol85Count = "0";
                        if (col85Count.Count > i)
                        {
                            finalcol85Count = col85Count[i].Count.ToString();
                        }

                        dt.Rows.Add(branches.Rows[j][1].ToString(), subjects.Rows[p][3].ToString(), finalcol0Count, finalcol35Count, finalcol60Count, finalcol85Count);
                    }
                }
            }

            gvInternalsMonth.DataSource = dt;
            gvInternalsMonth.DataBind();

            for (int i = 2; i < dt.Columns.Count; i++)
            {
                Series attseries = new Series();

                foreach (DataRow dr in dt.Rows)
                {
                    object y = dr[i];
                    attseries.Points.AddXY(String.Concat(dr["colBranchName"].ToString(), dr["colSubjectName"].ToString()), y);
                }

                chrtInternalsMonth.Series.Add(attseries);
            }
        }

        public static int Max(int w, int x, int y, int z)
        {
            return Math.Max(w, Math.Max(x, Math.Max(y, z)));
        }
    }
}