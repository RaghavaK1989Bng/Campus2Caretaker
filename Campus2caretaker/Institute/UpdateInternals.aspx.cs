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
using System.IO;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;

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
                dvSemester.Visible = false;
            }
            else
            {
                dvSemester.Visible = true;

                RequiredFieldValidator validator = new RequiredFieldValidator();
                validator.ID = "SemesterRequired";
                validator.ControlToValidate = ((DropDownList)this.Form.FindControl("ContentPlaceHolder1").FindControl("ddlSemester")).ID;
                validator.EnableClientScript = true;
                validator.ErrorMessage = "Semester Selection is required.";
                validator.Text = "*";
                validator.ValidationGroup = "Internals";
                validator.ForeColor = System.Drawing.Color.Red;
                validator.InitialValue = "Select";
                validator.ToolTip = "Semester Selection is required.";

                this.Form.FindControl("ContentPlaceHolder1").Controls.Add(validator);
            }

            RequiredFieldValidator validatorsubjects = new RequiredFieldValidator();
            validatorsubjects.ID = "SubjectRequired";
            validatorsubjects.ControlToValidate = ((DropDownList)this.Form.FindControl("ContentPlaceHolder1").FindControl("ddlSubjects")).ID;
            validatorsubjects.EnableClientScript = true;
            validatorsubjects.ErrorMessage = "Subject Selection is required.";
            validatorsubjects.Text = "*";
            validatorsubjects.ValidationGroup = "Internals";
            validatorsubjects.ForeColor = System.Drawing.Color.Red;
            validatorsubjects.InitialValue = "Select";
            validatorsubjects.ToolTip = "Subject Selection is required.";

            this.Form.FindControl("ContentPlaceHolder1").Controls.Add(validatorsubjects);


            lnkpdfdownload.ServerClick += new EventHandler(lnkpdfdownload_Click);
            lnkexceldownload.ServerClick += new EventHandler(lnkexceldownload_Click);
        }

        private void lnkexceldownload_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.ClearContent();
            Response.ClearHeaders();
            Response.Charset = "";
            StringWriter strwritter = new StringWriter();
            HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.ms-excel";
            HttpContext.Current.Response.AddHeader("content-disposition", String.Format("attachment;filename={0}.xls", String.Concat("InternalDetails", DateTime.Now.Ticks)));
            gvInternals.GridLines = GridLines.Both;
            gvInternals.HeaderStyle.Font.Bold = true;
            gvInternals.RenderControl(htmltextwrtter);
            Response.Write(strwritter.ToString());
            Response.End();
        }

        //override the VerifyRenderingInServerForm() to verify the control
        public override void VerifyRenderingInServerForm(Control control)
        {
            //Required to verify that the control is rendered properly on page
        }

        private void lnkpdfdownload_Click(object sender, EventArgs e)
        {
            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                {
                    gvInternals.RenderControl(hw);
                    StringReader sr = new StringReader(sw.ToString());
                    Document pdfDoc = new Document(PageSize.A4, 5f, 5f, 5f, 0f);
                    HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                    PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                    pdfDoc.Open();
                    htmlparser.Parse(sr);
                    pdfDoc.Close();

                    Response.ContentType = "application/pdf";
                    Response.AddHeader("content-disposition", String.Format("attachment;filename={0}.pdf", String.Concat("InternalDetails", DateTime.Now.Ticks)));
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    Response.Write(pdfDoc);
                    Response.End();
                }
            }
        }

        public void clear()
        {
            //Clears all the fields and gets the form to initial state

            BindClassList();
            RefreshSemesters();

            System.Web.UI.WebControls.ListItem selectItem = new System.Web.UI.WebControls.ListItem();
            selectItem.Text = "Select";
            selectItem.Value = "Select";
            //cmbComissionNo.Items.Insert(0, selectItem);
            // ddlClass.Items.Insert(0, selectItem);
            ddlMonth.Items.Insert(0, selectItem);
            ddlYear.Items.Insert(0, selectItem);
            //ddlSemester.Items.Insert(0, selectItem);

            ddlClass.SelectedIndex = 0;
            ddlMonth.SelectedIndex = 0;
            ddlYear.SelectedIndex = 0;
            ddlSemester.SelectedIndex = 0;

            ViewState["CurrentTable"] = null;
            SetInitialRow();
        }

        private void RefreshSemesters()
        {
            ddlSemester.Items.Clear();
            List<System.Web.UI.WebControls.ListItem> items = GetSemesters.GetSemester(Session["InstituteType"].ToString());

            for (int i = 0; i < items.Count; i++)
            {
                System.Web.UI.WebControls.ListItem Item = new System.Web.UI.WebControls.ListItem(items[i].Text, items[i].Value);
                ddlSemester.Items.Add(Item);
            }

            System.Web.UI.WebControls.ListItem SelectItem = new System.Web.UI.WebControls.ListItem("Select", "Select");
            ddlSemester.Items.Insert(0, SelectItem);
            ddlSemester.SelectedIndex = 0;
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

            System.Web.UI.WebControls.ListItem Item = new System.Web.UI.WebControls.ListItem("Select", "Select");
            ddlClass.Items.Insert(0, Item);
            ddlClass.SelectedIndex = 0;
        }

        private void BindSubjectsList()
        {
            DataTable dt = new BOPersonalizeApplication().GetSubjectsList(Session["InstituteID"].ToString(), int.Parse(ddlClass.SelectedValue));
            ddlSubjects.DataSource = dt;
            ddlSubjects.DataBind();

            System.Web.UI.WebControls.ListItem Item = new System.Web.UI.WebControls.ListItem("Select", "Select");
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

                        lbl1.Text = dtStudents.Rows[p]["colStudentName"].ToString();
                        lbl2.Text = dtStudents.Rows[p]["colRollNo"].ToString();
                        txt1.Text = dtStudents.Rows[p]["colMaxMarks"].ToString();
                        txt2.Text = dtStudents.Rows[p]["colMinMarks"].ToString();
                        txt3.Text = dtStudents.Rows[p]["colMarksScored"].ToString();
                        lbl3.Text = dtStudents.Rows[p]["colStudentId"].ToString();

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
            toInt.Month = ddlMonth.SelectedValue;
            toInt.Year = ddlYear.SelectedValue;
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

        protected void btnSaveInternals_Click(object sender, EventArgs e)
        {

        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            clear();
        }

        protected void txtMaxMarks_TextChanged(object sender, EventArgs e)
        {
            TextBox txtRow1 = (TextBox)gvInternals.Rows[0].Cells[3].FindControl("txtMaxMarks");
            for (int p = 1; p < gvInternals.Rows.Count - 1; p++)
            {
                TextBox txt1 = (TextBox)gvInternals.Rows[p].Cells[3].FindControl("txtMaxMarks");
                txt1.Text = txtRow1.Text;
                p++;
            }
        }

        protected void txtMinMarks_TextChanged(object sender, EventArgs e)
        {
            TextBox txtRow1 = (TextBox)gvInternals.Rows[0].Cells[4].FindControl("txtMinMarks");
            for (int p = 1; p < gvInternals.Rows.Count - 1; p++)
            {
                TextBox txt1 = (TextBox)gvInternals.Rows[p].Cells[4].FindControl("txtMinMarks");
                txt1.Text = txtRow1.Text;
                p++;
            }
        }
    }
}