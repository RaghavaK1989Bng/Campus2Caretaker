using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessObjects;
using DataTransferObject;
using System.Drawing;

namespace Campus2caretaker.Institute
{
    public partial class UpdateInternals : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Response.Cache.SetNoStore();
                clear();

                if (rbNew.Checked == true)
                {
                    btnGetStudentsList.Visible = true;
                    btnGetStudentsListEdit.Visible = false;
                }

                if (rbEdit.Checked == true)
                {
                    btnGetStudentsList.Visible = false;
                    btnGetStudentsListEdit.Visible = true;
                }
            }

            if (Session["InstituteType"].ToString() == "S")
            {
                trSemester.Visible = false;
                trSemesterLineBreak.Visible = false;
            }
            else
            {
                trSemester.Visible = true;
                trSemesterLineBreak.Visible = true;
            }
        }

        public void clear()
        {
            //Clears all the fields and gets the form to initial state

            BindClassList();

            ListItem selectItem = new ListItem();
            selectItem.Text = "Select";
            selectItem.Value = "";
            //cmbComissionNo.Items.Insert(0, selectItem);
            // ddlClass.Items.Insert(0, selectItem);
            ddlMonth.Items.Insert(0, selectItem);
            ddlYear.Items.Insert(0, selectItem);
            ddlSemester.Items.Insert(0, selectItem);

            ddlClass.SelectedIndex = 0;
            ddlMonth.SelectedIndex = 0;
            ddlYear.SelectedIndex = 0;
            ddlSemester.SelectedIndex = 0;

            ViewState["CurrentTable"] = null;
            SetInitialRow();
        }

        private void SetInitialRow()
        {
            DataTable dt = new DataTable();
            DataRow dr = null;
            dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));
            dt.Columns.Add(new DataColumn("Column1", typeof(string)));
            dt.Columns.Add(new DataColumn("Column2", typeof(string)));
            dt.Columns.Add(new DataColumn("Column3", typeof(decimal)));
            dt.Columns.Add(new DataColumn("Column4", typeof(decimal)));
            dt.Columns.Add(new DataColumn("Column5", typeof(decimal)));
            dt.Columns.Add(new DataColumn("Column6", typeof(string)));

            dr = dt.NewRow();
            dr["RowNumber"] = 1;
            dr["Column1"] = string.Empty;
            dr["Column2"] = string.Empty;
            dr["Column3"] = 0;
            dr["Column4"] = 0;
            dr["Column5"] = 0;
            dr["Column6"] = string.Empty;

            dt.Rows.Add(dr);

            ViewState["CurrentTable"] = dt;

            gvInternals.DataSource = dt;
            gvInternals.DataBind();
        }

        private void BindClassList()
        {
            DataTable dt = new BOStudentRegistration().GetClassesList(Session["InstituteID"].ToString());
            ddlClass.DataSource = dt;
            ddlClass.DataBind();

            ListItem Item = new ListItem("Select", "");
            ddlClass.Items.Insert(0, Item);
            ddlClass.SelectedIndex = 0;
        }

        private void BindSubjectsList()
        {
            DataTable dt = new BOPersonalizeApplication().GetSubjectsList(Session["InstituteID"].ToString(), int.Parse(ddlClass.SelectedValue));
            ddlSubjects.DataSource = dt;
            ddlSubjects.DataBind();

            ListItem Item = new ListItem("Select", "");
            ddlSubjects.Items.Insert(0, Item);
            ddlSubjects.SelectedIndex = 0;
        }

        private void AddRowsToGrid(DataTable dtStudents)
        {

            for (int p = 0; p < dtStudents.Rows.Count; p++)
            {
                int rowIndex = 0;

                if (ViewState["CurrentTable"] != null)
                {
                    DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                    DataRow drCurrentRow = null;
                    if (dtCurrentTable.Rows.Count > 0)
                    {
                        int i = dtCurrentTable.Rows.Count - 1;

                        //extract the Label values
                        Label lbl1 = (Label)gvInternals.Rows[rowIndex].Cells[1].FindControl("lblStudentName");
                        Label lbl2 = (Label)gvInternals.Rows[rowIndex].Cells[2].FindControl("lblRollNo");
                        TextBox txt1 = (TextBox)gvInternals.Rows[rowIndex].Cells[3].FindControl("txtMaxMarks");
                        TextBox txt2 = (TextBox)gvInternals.Rows[rowIndex].Cells[4].FindControl("txtMinMarks");
                        TextBox txt3 = (TextBox)gvInternals.Rows[rowIndex].Cells[5].FindControl("txtMarksScored");
                        Label lbl3 = (Label)gvInternals.Rows[rowIndex].Cells[6].FindControl("lblStudentID");

                        drCurrentRow = dtCurrentTable.NewRow();
                        drCurrentRow["RowNumber"] = dtCurrentTable.Rows.Count + 1;

                        lbl1.Text = dtStudents.Rows[p][7].ToString();
                        lbl2.Text = dtStudents.Rows[p][11].ToString();
                        txt1.Text = dtStudents.Rows[p][3].ToString();
                        txt2.Text = dtStudents.Rows[p][4].ToString();
                        txt3.Text = dtStudents.Rows[p][5].ToString();
                        lbl3.Text = dtStudents.Rows[p][6].ToString();

                        dtCurrentTable.Rows[i]["Column1"] = lbl1.Text;
                        dtCurrentTable.Rows[i]["Column2"] = lbl2.Text;
                        dtCurrentTable.Rows[i]["Column3"] = txt1.Text;
                        dtCurrentTable.Rows[i]["Column4"] = txt2.Text;
                        dtCurrentTable.Rows[i]["Column5"] = txt3.Text;
                        dtCurrentTable.Rows[i]["Column6"] = lbl3.Text;

                        rowIndex++;
                    }


                    dtCurrentTable.Rows.Add(drCurrentRow);
                    ViewState["CurrentTable"] = dtCurrentTable;

                    gvInternals.DataSource = dtCurrentTable;
                    gvInternals.DataBind();
                }
                else
                {
                    Response.Write("ViewState is null");
                }

                //Set Previous Data on Postbacks
                SetPreviousData();
            }
        }

        private void SetPreviousData()
        {
            int rowIndex = 0;

            if (ViewState["CurrentTable"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable"];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Label lbl1 = (Label)gvInternals.Rows[rowIndex].Cells[1].FindControl("lblStudentName");
                        Label lbl2 = (Label)gvInternals.Rows[rowIndex].Cells[2].FindControl("lblRollNo");
                        TextBox txt1 = (TextBox)gvInternals.Rows[rowIndex].Cells[3].FindControl("txtMaxMarks");
                        TextBox txt2 = (TextBox)gvInternals.Rows[rowIndex].Cells[4].FindControl("txtMinMarks");
                        TextBox txt3 = (TextBox)gvInternals.Rows[rowIndex].Cells[5].FindControl("txtMarksScored");
                        Label lbl3 = (Label)gvInternals.Rows[rowIndex].Cells[2].FindControl("lblStudentID");


                        lbl1.Text = dt.Rows[i]["Column1"].ToString();
                        lbl2.Text = dt.Rows[i]["Column2"].ToString();
                        txt1.Text = dt.Rows[i]["Column3"].ToString();
                        txt2.Text = dt.Rows[i]["Column4"].ToString();
                        txt3.Text = dt.Rows[i]["Column5"].ToString();
                        lbl3.Text = dt.Rows[i]["Column6"].ToString();

                        rowIndex++;
                    }
                }
            }
        }

        protected void btnGetStudentsList_Click(object sender, EventArgs e)
        {
            DTOInternals toInt = new DTOInternals();
            toInt.BranchId = int.Parse(ddlClass.SelectedValue);
            if (Session["InstituteType"].ToString() == "S")
            {
                toInt.SemesterId = 0;
            }
            else
            {
                toInt.SemesterId = int.Parse(ddlSemester.SelectedValue);
            }
            toInt.InstituteId = int.Parse(Session["InstituteID"].ToString());
            toInt.SubjectId = int.Parse(ddlSubjects.SelectedValue);
            ViewState["CurrentTable"] = null;
            SetInitialRow();
            AddRowsToGrid(new BOInternals().GetStudentsList(toInt));
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {

        }

        protected void gvInternals_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Save")
            {
                DTOInternals toInt = new DTOInternals();
                toInt.BranchId = int.Parse(ddlClass.SelectedValue);
                if (Session["InstituteType"].ToString() == "S")
                {
                    toInt.SemesterId = 0;
                }
                else
                {
                    toInt.SemesterId = int.Parse(ddlSemester.SelectedValue);
                }
                toInt.Month = ddlMonth.SelectedValue;
                toInt.Year = ddlYear.SelectedValue;
                toInt.SubjectId = int.Parse(ddlSubjects.SelectedValue);

                int index = Convert.ToInt32(e.CommandArgument.ToString());
                Label lblStudentID = (Label)gvInternals.Rows[index].FindControl("lblStudentID");
                Label lblStudentName = (Label)gvInternals.Rows[index].FindControl("lblStudentName");
                TextBox txtMaxMarks = (TextBox)gvInternals.Rows[index].FindControl("txtMaxMarks");
                TextBox txtMinMarks = (TextBox)gvInternals.Rows[index].FindControl("txtMinMarks");
                TextBox txtMarksScored = (TextBox)gvInternals.Rows[index].FindControl("txtMarksScored");

                toInt.InstituteId = int.Parse(Session["InstituteID"].ToString());
                toInt.MarksScored = decimal.Parse(txtMarksScored.Text);
                toInt.MaxMarks = decimal.Parse(txtMaxMarks.Text);
                toInt.MinMarks = decimal.Parse(txtMinMarks.Text);
                toInt.StudentId = int.Parse(lblStudentID.Text);

                new BOInternals().SaveUpdateInternals(toInt);
            }
        }

        protected void btnGetStudentsListEdit_Click(object sender, EventArgs e)
        {
            DTOInternals toInt = new DTOInternals();
            toInt.BranchId = int.Parse(ddlClass.SelectedValue);
            if (Session["InstituteType"].ToString() == "S")
            {
                toInt.SemesterId = 0;
            }
            else
            {
                toInt.SemesterId = int.Parse(ddlSemester.SelectedValue);
            }
            toInt.Month = ddlMonth.SelectedValue;
            toInt.Year = ddlYear.SelectedValue;
            toInt.SubjectId = int.Parse(ddlSubjects.SelectedValue);
            toInt.InstituteId = int.Parse(Session["InstituteID"].ToString());
            ViewState["CurrentTable"] = null;
            SetInitialRow();
            AddRowsToGrid(new BOInternals().GetStudentsListEdit(toInt));
        }

        protected void rbNew_CheckedChanged(object sender, EventArgs e)
        {
            if (rbNew.Checked == true)
            {
                btnGetStudentsList.Visible = true;
                btnGetStudentsListEdit.Visible = false;
            }
        }

        protected void rbEdit_CheckedChanged(object sender, EventArgs e)
        {
            if (rbEdit.Checked == true)
            {
                btnGetStudentsList.Visible = false;
                btnGetStudentsListEdit.Visible = true;
            }
        }

        protected void gvInternals_DataBound(object sender, EventArgs e)
        {

        }

        protected void gvInternals_RowCreated(object sender, GridViewRowEventArgs e)
        {

        }

        protected void ddlClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindSubjectsList();
            ddlSubjects.SelectedIndex = 0;
        }
    }
}