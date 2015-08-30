using BusinessObjects;
using DataTransferObject;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Campus2caretaker.Institute
{
    public partial class UpdateAttendance : System.Web.UI.Page
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
                dvSubjects.Visible = false;
            }
            else
            {
                dvSemester.Visible = true;
                dvSubjects.Visible = true;

                RequiredFieldValidator validator = new RequiredFieldValidator();
                validator.ID = "SemesterRequired";
                validator.ControlToValidate = ((DropDownList)this.Form.FindControl("ContentPlaceHolder1").FindControl("ddlSemester")).ID;
                validator.EnableClientScript = true;
                validator.ErrorMessage = "Semester Selection is required.";
                validator.Text = "*";
                validator.ValidationGroup = "Attendance";
                validator.ForeColor = System.Drawing.Color.Red;
                validator.InitialValue = "Select";
                validator.ToolTip = "Semester Selection is required.";

                this.Form.FindControl("ContentPlaceHolder1").Controls.Add(validator);

                RequiredFieldValidator validatorsubjects = new RequiredFieldValidator();
                validatorsubjects.ID = "SubjectRequired";
                validatorsubjects.ControlToValidate = ((DropDownList)this.Form.FindControl("ContentPlaceHolder1").FindControl("ddlSubjects")).ID;
                validatorsubjects.EnableClientScript = true;
                validatorsubjects.ErrorMessage = "Subject Selection is required.";
                validatorsubjects.Text = "*";
                validatorsubjects.ValidationGroup = "Attendance";
                validatorsubjects.ForeColor = System.Drawing.Color.Red;
                validatorsubjects.InitialValue = "Select";
                validatorsubjects.ToolTip = "Subject Selection is required.";

                this.Form.FindControl("ContentPlaceHolder1").Controls.Add(validatorsubjects);
            }

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
            HttpContext.Current.Response.AddHeader("content-disposition", String.Format("attachment;filename={0}.xls", String.Concat("AttendanceDetails", DateTime.Now.Ticks)));
            gvAttendance.GridLines = GridLines.Both;
            gvAttendance.HeaderStyle.Font.Bold = true;
            gvAttendance.RenderControl(htmltextwrtter);
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
                    gvAttendance.RenderControl(hw);
                    StringReader sr = new StringReader(sw.ToString());
                    iTextSharp.text.Document pdfDoc = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4, 5f, 5f, 5f, 0f);
                    iTextSharp.text.html.simpleparser.HTMLWorker htmlparser = new iTextSharp.text.html.simpleparser.HTMLWorker(pdfDoc);
                    iTextSharp.text.pdf.PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                    pdfDoc.Open();
                    htmlparser.Parse(sr);
                    pdfDoc.Close();

                    Response.ContentType = "application/pdf";
                    Response.AddHeader("content-disposition", String.Format("attachment;filename={0}.pdf", String.Concat("AttendanceDetails", DateTime.Now.Ticks)));
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    Response.Write(pdfDoc);
                    Response.End();
                }
            }
        }

        public void clear()
        {
            //Clears all the fields and gets the form to initial state
            // Call Bind Model Codes and Model Description

            BindClassList();
            RefreshSemesters();
            //dsCommissionNo.DataBind();
            //cmbComissionNo.DataBind();

            ListItem selectItem = new ListItem();
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
            dt.Columns.Add(new DataColumn("Column6", typeof(decimal)));
            dt.Columns.Add(new DataColumn("Column7", typeof(decimal)));
            dt.Columns.Add(new DataColumn("Column8", typeof(decimal)));
            dt.Columns.Add(new DataColumn("Column9", typeof(string)));
            dt.Columns.Add(new DataColumn("Column10", typeof(string)));

            dr = dt.NewRow();
            dr["RowNumber"] = 1;
            dr["Column1"] = string.Empty;
            dr["Column2"] = string.Empty;
            dr["Column3"] = 0;
            dr["Column4"] = 0;
            dr["Column5"] = 0;
            dr["Column6"] = 0;
            dr["Column7"] = 0;
            dr["Column8"] = 0;
            dr["Column9"] = string.Empty;
            dr["Column10"] = string.Empty;

            dt.Rows.Add(dr);

            ViewState["CurrentTable"] = dt;

            gvAttendance.DataSource = dt;
            gvAttendance.DataBind();
        }

        private void BindClassList()
        {
            DataTable dt = new BOStudentRegistration().GetClassesList(Session["InstituteID"].ToString());
            ddlClass.DataSource = dt;
            ddlClass.DataBind();

            ListItem Item = new ListItem("Select", "Select");
            ddlClass.Items.Insert(0, Item);
            ddlClass.SelectedIndex = 0;
        }

        private void AddRowsToGrid(DataTable dtStudents)
        {
            if (dtStudents.Rows.Count > 0)
            {
                txtDescription.Text = dtStudents.Rows[0]["colDescription"].ToString();
            }

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
                        Label lbl1 = (Label)gvAttendance.Rows[rowIndex].Cells[1].FindControl("lblStudentName");
                        Label lbl2 = (Label)gvAttendance.Rows[rowIndex].Cells[2].FindControl("lblRollNo");
                        TextBox txt1 = (TextBox)gvAttendance.Rows[rowIndex].Cells[3].FindControl("txtClassesHeld");
                        TextBox txt2 = (TextBox)gvAttendance.Rows[rowIndex].Cells[4].FindControl("txtClassesAttended");
                        TextBox txt3 = (TextBox)gvAttendance.Rows[rowIndex].Cells[5].FindControl("txtPercentage");
                        TextBox txt4 = (TextBox)gvAttendance.Rows[rowIndex].Cells[6].FindControl("txtCumClassesHeld");
                        TextBox txt5 = (TextBox)gvAttendance.Rows[rowIndex].Cells[7].FindControl("txtCumClassesAttended");
                        TextBox txt6 = (TextBox)gvAttendance.Rows[rowIndex].Cells[8].FindControl("txtCumPercentage");
                        Label lbl3 = (Label)gvAttendance.Rows[rowIndex].Cells[9].FindControl("lblStudentID");
                        TextBox txt7 = (TextBox)gvAttendance.Rows[rowIndex].Cells[10].FindControl("txtRemarks");

                        drCurrentRow = dtCurrentTable.NewRow();
                        drCurrentRow["RowNumber"] = dtCurrentTable.Rows.Count + 1;

                        lbl1.Text = dtStudents.Rows[p]["colStudentName"].ToString();
                        lbl2.Text = dtStudents.Rows[p]["colRollNo"].ToString();
                        txt1.Text = dtStudents.Rows[p]["colClassesHeldMonth"].ToString();
                        txt2.Text = dtStudents.Rows[p]["colClassesAttendedMonth"].ToString();
                        txt3.Text = dtStudents.Rows[p]["colClassesAttendedMonthPercent"].ToString();
                        txt4.Text = dtStudents.Rows[p]["colAccumulatedClassesHeld"].ToString();
                        txt5.Text = dtStudents.Rows[p]["colAccumulatedClassesAttended"].ToString();
                        txt6.Text = dtStudents.Rows[p]["colAccumulatedClassesAttendedPercent"].ToString();
                        lbl3.Text = dtStudents.Rows[p]["colStudentId"].ToString();
                        txt7.Text = dtStudents.Rows[p]["colRemarks"].ToString();

                        dtCurrentTable.Rows[i]["Column1"] = lbl1.Text;
                        dtCurrentTable.Rows[i]["Column2"] = lbl2.Text;
                        dtCurrentTable.Rows[i]["Column3"] = txt1.Text;
                        dtCurrentTable.Rows[i]["Column4"] = txt2.Text;
                        dtCurrentTable.Rows[i]["Column5"] = txt3.Text;
                        dtCurrentTable.Rows[i]["Column6"] = txt4.Text;
                        dtCurrentTable.Rows[i]["Column7"] = txt5.Text;
                        dtCurrentTable.Rows[i]["Column8"] = txt6.Text;
                        dtCurrentTable.Rows[i]["Column9"] = lbl3.Text;
                        dtCurrentTable.Rows[i]["Column10"] = txt7.Text;
                        rowIndex++;
                    }


                    dtCurrentTable.Rows.Add(drCurrentRow);
                    ViewState["CurrentTable"] = dtCurrentTable;

                    gvAttendance.DataSource = dtCurrentTable;
                    gvAttendance.DataBind();
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
                        Label lbl1 = (Label)gvAttendance.Rows[rowIndex].Cells[1].FindControl("lblStudentName");
                        Label lbl2 = (Label)gvAttendance.Rows[rowIndex].Cells[2].FindControl("lblRollNo");
                        TextBox txt1 = (TextBox)gvAttendance.Rows[rowIndex].Cells[3].FindControl("txtClassesHeld");
                        TextBox txt2 = (TextBox)gvAttendance.Rows[rowIndex].Cells[4].FindControl("txtClassesAttended");
                        TextBox txt3 = (TextBox)gvAttendance.Rows[rowIndex].Cells[5].FindControl("txtPercentage");
                        TextBox txt4 = (TextBox)gvAttendance.Rows[rowIndex].Cells[6].FindControl("txtCumClassesHeld");
                        TextBox txt5 = (TextBox)gvAttendance.Rows[rowIndex].Cells[7].FindControl("txtCumClassesAttended");
                        TextBox txt6 = (TextBox)gvAttendance.Rows[rowIndex].Cells[8].FindControl("txtCumPercentage");
                        Label lbl3 = (Label)gvAttendance.Rows[rowIndex].Cells[9].FindControl("lblStudentID");
                        TextBox txt7 = (TextBox)gvAttendance.Rows[rowIndex].Cells[10].FindControl("txtRemarks");


                        lbl1.Text = dt.Rows[i]["Column1"].ToString();
                        lbl2.Text = dt.Rows[i]["Column2"].ToString();
                        txt1.Text = dt.Rows[i]["Column3"].ToString();
                        txt2.Text = dt.Rows[i]["Column4"].ToString();
                        txt3.Text = dt.Rows[i]["Column5"].ToString();
                        txt4.Text = dt.Rows[i]["Column6"].ToString();
                        txt5.Text = dt.Rows[i]["Column7"].ToString();
                        txt6.Text = dt.Rows[i]["Column8"].ToString();
                        lbl3.Text = dt.Rows[i]["Column9"].ToString();
                        txt7.Text = dt.Rows[i]["Column10"].ToString();

                        rowIndex++;
                    }
                }
            }
        }

        protected void gvAttendance_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Save")
            {
                DTOAttendance toAtt = new DTOAttendance();
                toAtt.BranchId = int.Parse(ddlClass.SelectedValue);
                if (Session["InstituteType"].ToString() == "S")
                {
                    toAtt.SemesterId = 0;
                }
                else
                {
                    toAtt.SemesterId = int.Parse(ddlSemester.SelectedValue);
                }

                if (Session["InstituteType"].ToString() == "S")
                {
                    toAtt.SubjectId = 0;
                }
                else
                {
                    toAtt.SubjectId = int.Parse(ddlSubjects.SelectedValue);
                }

                toAtt.Month = ddlMonth.SelectedValue;
                toAtt.Year = int.Parse(ddlYear.SelectedValue);
                toAtt.Description = txtDescription.Text;

                int index = Convert.ToInt32(e.CommandArgument.ToString());
                Label lblStudentID = (Label)gvAttendance.Rows[index].FindControl("lblStudentID");
                Label lblStudentName = (Label)gvAttendance.Rows[index].FindControl("lblStudentName");
                TextBox txtClassesHeld = (TextBox)gvAttendance.Rows[index].FindControl("txtClassesHeld");
                TextBox txtClassesAttended = (TextBox)gvAttendance.Rows[index].FindControl("txtClassesAttended");
                TextBox txtPercentage = (TextBox)gvAttendance.Rows[index].FindControl("txtPercentage");
                TextBox txtCumClassesHeld = (TextBox)gvAttendance.Rows[index].FindControl("txtCumClassesHeld");
                TextBox txtCumClassesAttended = (TextBox)gvAttendance.Rows[index].FindControl("txtCumClassesAttended");
                TextBox txtCumPercentage = (TextBox)gvAttendance.Rows[index].FindControl("txtCumPercentage");
                TextBox txtReMarks = (TextBox)gvAttendance.Rows[index].FindControl("txtRemarks");

                toAtt.InstituteId = int.Parse(Session["InstituteID"].ToString());
                toAtt.ClassesAttended = decimal.Parse(txtClassesAttended.Text);
                toAtt.ClassesHeld = decimal.Parse(txtClassesHeld.Text);
                toAtt.ClassesPercentage = decimal.Parse(txtPercentage.Text);
                toAtt.CumClassesHeld = decimal.Parse(txtCumClassesHeld.Text);
                toAtt.CumClassesAttended = decimal.Parse(txtCumClassesAttended.Text);
                toAtt.CumClassesPercentage = decimal.Parse(txtCumPercentage.Text);
                toAtt.Remarks = txtReMarks.Text;

                toAtt.StudentId = int.Parse(lblStudentID.Text);

                new BOAttendance().SaveUpdateAttendance(toAtt);
            }
        }

        protected void gvAttendance_DataBound(object sender, EventArgs e)
        {

        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {

        }

        protected void btnGetStudentsList_Click(object sender, EventArgs e)
        {
            DTOAttendance toAtt = new DTOAttendance();
            toAtt.BranchId = int.Parse(ddlClass.SelectedValue);
            if (Session["InstituteType"].ToString() == "S")
            {
                toAtt.SemesterId = 0;
            }
            else
            {
                toAtt.SemesterId = int.Parse(ddlSemester.SelectedValue);
            }
            if (Session["InstituteType"].ToString() == "S")
            {
                toAtt.SubjectId = 0;
            }
            else
            {
                toAtt.SubjectId = int.Parse(ddlSubjects.SelectedValue);
            }
            toAtt.Month = ddlMonth.SelectedValue;
            toAtt.Year = int.Parse(ddlYear.SelectedValue);
            toAtt.InstituteId = int.Parse(Session["InstituteID"].ToString());
            ViewState["CurrentTable"] = null;
            SetInitialRow();
            AddRowsToGrid(new BOAttendance().GetStudentsList(toAtt));
        }

        protected void btnGetStudentsListEdit_Click(object sender, EventArgs e)
        {
            DTOAttendance toAtt = new DTOAttendance();
            toAtt.BranchId = int.Parse(ddlClass.SelectedValue);
            if (Session["InstituteType"].ToString() == "S")
            {
                toAtt.SemesterId = 0;
            }
            else
            {
                toAtt.SemesterId = int.Parse(ddlSemester.SelectedValue);
            }
            if (Session["InstituteType"].ToString() == "S")
            {
                toAtt.SubjectId = 0;
            }
            else
            {
                toAtt.SubjectId = int.Parse(ddlSubjects.SelectedValue);
            }
            toAtt.Month = ddlMonth.SelectedValue;
            toAtt.Year = int.Parse(ddlYear.SelectedValue);
            toAtt.InstituteId = int.Parse(Session["InstituteID"].ToString());
            ViewState["CurrentTable"] = null;
            SetInitialRow();
            AddRowsToGrid(new BOAttendance().GetStudentsListEdit(toAtt));
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

        private void BindSubjectsList()
        {
            DataTable dt = new BOPersonalizeApplication().GetSubjectsList(Session["InstituteID"].ToString(), int.Parse(ddlClass.SelectedValue));
            ddlSubjects.DataSource = dt;
            ddlSubjects.DataBind();

            ListItem Item = new ListItem("Select", "Select");
            ddlSubjects.Items.Insert(0, Item);
            ddlSubjects.SelectedIndex = 0;
        }

        protected void ddlClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindSubjectsList();
            ddlSubjects.SelectedIndex = 0;
        }

        protected void btnSaveAttendance_Click(object sender, EventArgs e)
        {

        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            clear();
        }

        protected void txtClassesHeld_TextChanged(object sender, EventArgs e)
        {
            TextBox txtRow1 = (TextBox)gvAttendance.Rows[0].Cells[3].FindControl("txtClassesHeld");
            for (int p = 1; p < gvAttendance.Rows.Count - 1; p++)
            {
                TextBox txt1 = (TextBox)gvAttendance.Rows[p].Cells[3].FindControl("txtClassesHeld");
                txt1.Text = txtRow1.Text;
                p++;
            }
        }

        protected void txtCumClassesHeld_TextChanged(object sender, EventArgs e)
        {
            TextBox txtRow1 = (TextBox)gvAttendance.Rows[0].Cells[6].FindControl("txtCumClassesHeld");
            for (int p = 1; p < gvAttendance.Rows.Count - 1; p++)
            {
                TextBox txt1 = (TextBox)gvAttendance.Rows[p].Cells[6].FindControl("txtCumClassesHeld");
                txt1.Text = txtRow1.Text;
                p++;
            }
        }

        protected void txtClassesAttended_TextChanged(object sender, EventArgs e)
        {
            for (int p = 0; p < gvAttendance.Rows.Count - 1; p++)
            {
                GridViewRow row = gvAttendance.Rows[p];
                TextBox txtClassesHeld = (TextBox)row.Cells[3].FindControl("txtClassesHeld");
                TextBox txtClassesAttended = (TextBox)row.Cells[4].FindControl("txtClassesAttended");
                TextBox txtClassesPercentage = (TextBox)row.Cells[5].FindControl("txtPercentage");

                txtClassesPercentage.Text = ((Convert.ToDouble(txtClassesAttended.Text) * 100) / (Convert.ToDouble(txtClassesHeld.Text))).ToString("0.00");
            }
        }

        protected void txtCumClassesAttended_TextChanged(object sender, EventArgs e)
        {
            for (int p = 0; p < gvAttendance.Rows.Count - 1; p++)
            {
                GridViewRow row = gvAttendance.Rows[p];
                TextBox txtCumClassesHeld = (TextBox)row.Cells[3].FindControl("txtCumClassesHeld");
                TextBox txtCumClassesAttended = (TextBox)row.Cells[4].FindControl("txtCumClassesAttended");
                TextBox txtCumClassesPercentage = (TextBox)row.Cells[5].FindControl("txtCumPercentage");

                txtCumClassesPercentage.Text = ((Convert.ToDouble(txtCumClassesAttended.Text) * 100) / (Convert.ToDouble(txtCumClassesHeld.Text))).ToString("0.00");
            }
        }
    }
}