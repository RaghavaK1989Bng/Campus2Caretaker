using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Campus2caretaker.Parents
{
    public partial class ParentsDefault : System.Web.UI.Page
    {
        string studentId;
        protected void Page_Load(object sender, EventArgs e)
        {
            dvStudentsList.Controls.Clear();

            DataTable dtStudentsList = new BOParentsLoginDetails().GetStudentsList(Session["ParentsMobileNumber"].ToString());

            foreach (DataRow row in dtStudentsList.Rows)
            {
                var button = new Button
                   {
                       ID = String.Concat("sbtn", row["colStudentId"].ToString()),
                       CommandArgument = row["colStudentId"].ToString(),
                       CssClass = "btn btn-info btn-large",
                       Text = row["colStudentName"].ToString(),
                   };
                button.Click += new EventHandler(btnStudent_Click); ;
                button.Style.Add("margin-right", "10px");

                dvStudentsList.Controls.Add(button);
            }
        }

        protected void btnStudent_Click(object sender, EventArgs e)
        {
            studentId = ((Button)sender).CommandArgument;
            DataTable dtStudentDetails = new BOParentsLoginDetails().GetStudentsDetails(Convert.ToInt32(studentId));
            if (dtStudentDetails.Rows.Count > 0)
            {
                txtClass.Text = dtStudentDetails.Rows[0]["colBranchName"].ToString();
                txtSchoolName.Text = dtStudentDetails.Rows[0]["colInstituteName"].ToString();
                txtPrincipalName.Text = dtStudentDetails.Rows[0]["colPrincipalName"].ToString();
                txtPrincipalContact.Text = dtStudentDetails.Rows[0]["colPrincipalContact"].ToString();
                txtSemester.Text = string.IsNullOrEmpty(dtStudentDetails.Rows[0]["colSemesterName"].ToString()) ? string.Empty : dtStudentDetails.Rows[0]["colSemesterName"].ToString();
                txtStudentName.Text = dtStudentDetails.Rows[0]["colStudentName"].ToString();
                txtFatherName.Text = dtStudentDetails.Rows[0]["colFatherName"].ToString();
                txtMotherName.Text = dtStudentDetails.Rows[0]["colMotherName"].ToString();
                txtAddress.Text = dtStudentDetails.Rows[0]["colAddress"].ToString();
            }

            RefreshStudentInternalsDetails(studentId);
            RefreshStudentAttendanceDetails(studentId);
        }

        private void RefreshStudentInternalsDetails(string studentId)
        {
            DataTable dtStudentInternalsDetails = new BOParentsLoginDetails().GetStudentInternalDetails(Convert.ToInt32(studentId));
            gvInternalsMonth.DataSource = dtStudentInternalsDetails;
            gvInternalsMonth.DataBind();
        }

        protected void gvInternalsMonth_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvInternalsMonth.PageIndex = e.NewPageIndex;
            RefreshStudentInternalsDetails(studentId);
        }

        private void RefreshStudentAttendanceDetails(string studentId)
        {
            DataTable dtStudentAttendanceDetails = new BOParentsLoginDetails().GetStudentAttendanceDetails(Convert.ToInt32(studentId));
            gvAttendanceDetails.DataSource = dtStudentAttendanceDetails;
            gvAttendanceDetails.DataBind();
        }

        protected void gvAttendanceDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvAttendanceDetails.PageIndex = e.NewPageIndex;
            RefreshStudentAttendanceDetails(studentId);
        }
    }
}