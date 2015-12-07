using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataTransferObject;
using System.IO;
using Excel;

namespace Campus2caretaker.Institute
{
    public partial class AddNewStudent : System.Web.UI.Page
    {
        private String m_strSortExp;
        private SortDirection m_SortDirection = SortDirection.Ascending;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Response.Cache.SetNoStore();
                m_strSortExp = String.Empty;
                clear();
                RefreshGridView();

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
                    validator.ValidationGroup = "Student";
                    validator.ForeColor = System.Drawing.Color.Red;
                    validator.InitialValue = "Select";
                    validator.ToolTip = "Semester Selection is required.";

                    this.Form.FindControl("ContentPlaceHolder1").Controls.Add(validator);
                }
            }
            lnkpdfdownload.ServerClick += new EventHandler(lnkpdfdownload_Click);
            lnkexceldownload.ServerClick += new EventHandler(lnkexceldownload_Click);
        }

        protected void lnkexceldownload_Click(object sender, EventArgs e)
        {
            gvStudents.AllowPaging = false;
            this.RefreshGridView();

            Response.Clear();
            Response.Buffer = true;
            Response.ClearContent();
            Response.ClearHeaders();
            Response.Charset = "";
            StringWriter strwritter = new StringWriter();
            HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.ms-excel";
            HttpContext.Current.Response.AddHeader("content-disposition", String.Format("attachment;filename={0}.xls", String.Concat("StudentsDetails", DateTime.Now.Ticks)));
            gvStudents.GridLines = GridLines.Both;
            gvStudents.HeaderStyle.Font.Bold = true;
            gvStudents.RenderControl(htmltextwrtter);
            Response.Write(strwritter.ToString());
            Response.End();
        }

        //override the VerifyRenderingInServerForm() to verify the control
        public override void VerifyRenderingInServerForm(Control control)
        {
            //Required to verify that the control is rendered properly on page
        }

        protected void lnkpdfdownload_Click(object sender, EventArgs e)
        {
            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                {
                    //To Export all pages
                    gvStudents.AllowPaging = false;
                    this.RefreshGridView();

                    gvStudents.RenderControl(hw);
                    StringReader sr = new StringReader(sw.ToString());
                    iTextSharp.text.Document pdfDoc = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4, 5f, 5f, 5f, 0f);
                    iTextSharp.text.html.simpleparser.HTMLWorker htmlparser = new iTextSharp.text.html.simpleparser.HTMLWorker(pdfDoc);
                    iTextSharp.text.pdf.PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                    pdfDoc.Open();
                    htmlparser.Parse(sr);
                    pdfDoc.Close();

                    Response.ContentType = "application/pdf";
                    Response.AddHeader("content-disposition", String.Format("attachment;filename={0}.pdf", String.Concat("StudentsDetails", DateTime.Now.Ticks)));
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    Response.Write(pdfDoc);
                    Response.End();
                }
            }
        }

        private void clear()
        {
            //Clears all the fields and gets the form to initial state

            txtStudentName.Text = "";
            ddlClass.Items.Clear();

            RefreshClasses();
            RefreshSemesters();

            ddlClass.SelectedIndex = 0;
            ddlSemester.SelectedIndex = 0;
            txtDOB.Text = "";
            txtFatherName.Text = "";
            txtMotherName.Text = "";
            txtParentsContactNumber.Text = "";
            txtParentsEmail.Text = "";
            txtRollNo.Text = "";
            txtStudentAddress.Text = "";
            txtStudentName.Text = "";

            btnSave.Enabled = true;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
            ddlGender.SelectedIndex = 0;
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

        int GetSortColumnIndex(String strCol)
        {
            foreach (DataControlField field in gvStudents.Columns)
            {
                if (field.SortExpression == strCol)
                {
                    return gvStudents.Columns.IndexOf(field);
                }
            }

            return -1;
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void RefreshClasses()
        {
            DataTable dt = new BOStudentRegistration().GetClassesList(Session["InstituteID"].ToString());
            ddlClass.DataSource = dt;
            ddlClass.DataBind();

            ListItem Item = new ListItem("Select", "Select");
            ddlClass.Items.Insert(0, Item);
            ddlClass.SelectedIndex = 0;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    DTOStudentRegistration tostud = new DTOStudentRegistration();
                    tostud.Address = txtStudentAddress.Text;
                    tostud.BranchId = int.Parse(ddlClass.SelectedValue);
                    tostud.DOB = DateTime.Parse(txtDOB.Text);
                    tostud.FatherName = txtFatherName.Text;
                    tostud.InstituteId = int.Parse(Session["InstituteID"].ToString());
                    tostud.MotherName = txtMotherName.Text;
                    tostud.ParentsMobileNo = txtParentsContactNumber.Text;
                    tostud.ParentsEmail = txtParentsEmail.Text;
                    tostud.RollNo = txtRollNo.Text;
                    if (Session["InstituteType"].ToString() == "S")
                    {
                        tostud.SemesterId = 0;
                    }
                    else
                    {
                        tostud.SemesterId = int.Parse(ddlSemester.SelectedValue);
                    }

                    tostud.StudentName = txtStudentName.Text;
                    tostud.Gender = ddlGender.SelectedValue;

                    if (new BOStudentRegistration().SaveStudentDetails(tostud))
                    {
                        //string script = @"document.getElementById('" + divStatus.ClientID + "').innerHTML='Record inserted';var elem = document.createElement('img');elem.setAttribute('src', 'tick.jpg');document.getElementById('" + divStatus.ClientID + "').appendChild(elem);document.getElementById('" + divStatus.ClientID + "').style.color = 'Green';document.getElementById('" + divStatus.ClientID + "').style.fontSize = '1em' ;document.getElementById('" + divStatus.ClientID + "').style.fontWeight = 'bold' ;setTimeout(function(){document.getElementById('" + divStatus.ClientID + "').style.display='none';},4500);";
                        //ScriptManager.RegisterStartupScript(this, this.GetType(), "script", script, true);

                        string alertScript = "jAlert('Student Details Saved Sucessfully', 'Campus2Caretaker');";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertScript", alertScript, true);

                        #region SMS
                        string _messageTemplate = new BOSms().GetSMSTemplate("NEWSTUDENTADDED");
                        C2CSMS.SendSMS(_messageTemplate.Replace("##STUDENTNAME##", tostud.StudentName).Replace("##InstituteName##", Session["InstituteName"].ToString()), tostud.ParentsMobileNo);
                        #endregion

                        #region E-Mail

                        //Send mail
                        if (!string.IsNullOrEmpty(tostud.ParentsEmail))
                        {
                            string s_subject = "Information From Campus2Caretaker";
                            string s_msg = String.Concat("Greetings from Campus2Caretaker.", Environment.NewLine, Environment.NewLine, _messageTemplate.Replace("##STUDENTNAME##", tostud.StudentName).Replace("##InstituteName##", Session["InstituteName"].ToString())) + Environment.NewLine + Environment.NewLine;
                            
                            C2CEmail.SendC2CMail(s_msg, s_subject, string.Empty, tostud.ParentsEmail, null, null);
                        }

                        #endregion

                        clear();
                        RefreshGridView();
                    }
                    else
                    {
                        //string script = @"document.getElementById('" + divStatus.ClientID + "').innerHTML='Error';var elem = document.createElement('img');elem.setAttribute('src', 'cross.jpg');document.getElementById('" + divStatus.ClientID + "').appendChild(elem);document.getElementById('" + divStatus.ClientID + "').style.color = 'Red';document.getElementById('" + divStatus.ClientID + "').style.fontSize = '1em' ;document.getElementById('" + divStatus.ClientID + "').style.fontWeight = 'bold' ;setTimeout(function(){document.getElementById('" + divStatus.ClientID + "').style.display='none';},4500);";
                        //ScriptManager.RegisterStartupScript(this, this.GetType(), "script", script, true);
                        string alertScript = "jAlert('Error', 'Campus2Caretaker');";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertScript", alertScript, true);
                    }
                }
                catch { }
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(hfStudentID.Value.ToString()))
            {
                //string script = @"document.getElementById('" + divStatus.ClientID + "').innerHTML='Error.Please select a student';var elem = document.createElement('img');elem.setAttribute('src', 'cross.jpg');document.getElementById('" + divStatus.ClientID + "').appendChild(elem);document.getElementById('" + divStatus.ClientID + "').style.color = 'Red';document.getElementById('" + divStatus.ClientID + "').style.fontSize = '1em' ;document.getElementById('" + divStatus.ClientID + "').style.fontWeight = 'bold' ;setTimeout(function(){document.getElementById('" + divStatus.ClientID + "').style.display='none';},4500);";
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "script", script, true);
                string alertScript = "jAlert('Please Select Student', 'Campus2Caretaker');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertScript", alertScript, true);
                return;
            }

            if (Page.IsValid)
            {
                try
                {
                    DTOStudentRegistration tostud = new DTOStudentRegistration();
                    tostud.StudentId = int.Parse(hfStudentID.Value.ToString());
                    tostud.Address = txtStudentAddress.Text;
                    tostud.BranchId = int.Parse(ddlClass.SelectedValue);
                    tostud.DOB = DateTime.Parse(txtDOB.Text);
                    tostud.FatherName = txtFatherName.Text;
                    tostud.InstituteId = int.Parse(Session["InstituteID"].ToString());
                    tostud.MotherName = txtMotherName.Text;
                    tostud.ParentsMobileNo = txtParentsContactNumber.Text;
                    tostud.ParentsEmail = txtParentsEmail.Text;
                    tostud.RollNo = txtRollNo.Text;
                    if (Session["InstituteType"].ToString() == "S")
                    {
                        tostud.SemesterId = 0;
                    }
                    else
                    {
                        tostud.SemesterId = int.Parse(ddlSemester.SelectedValue);
                    }

                    tostud.StudentName = txtStudentName.Text;
                    tostud.Gender = ddlGender.SelectedValue;

                    if (new BOStudentRegistration().UpdateStudentDetails(tostud))
                    {
                        //string script = @"document.getElementById('" + divStatus.ClientID + "').innerHTML='Record updated';var elem = document.createElement('img');elem.setAttribute('src', 'tick.jpg');document.getElementById('" + divStatus.ClientID + "').appendChild(elem);document.getElementById('" + divStatus.ClientID + "').style.color = 'Green';document.getElementById('" + divStatus.ClientID + "').style.fontSize = '1em' ;document.getElementById('" + divStatus.ClientID + "').style.fontWeight = 'bold' ;setTimeout(function(){document.getElementById('" + divStatus.ClientID + "').style.display='none';},4500);";
                        //ScriptManager.RegisterStartupScript(this, this.GetType(), "script", script, true);
                        string alertScript = "jAlert('Student Details Updated Sucessfully', 'Campus2Caretaker');";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertScript", alertScript, true);

                        clear();
                        RefreshGridView();
                    }
                    else
                    {
                        //string script = @"document.getElementById('" + divStatus.ClientID + "').innerHTML='Error';var elem = document.createElement('img');elem.setAttribute('src', 'cross.jpg');document.getElementById('" + divStatus.ClientID + "').appendChild(elem);document.getElementById('" + divStatus.ClientID + "').style.color = 'Red';document.getElementById('" + divStatus.ClientID + "').style.fontSize = '1em' ;document.getElementById('" + divStatus.ClientID + "').style.fontWeight = 'bold' ;setTimeout(function(){document.getElementById('" + divStatus.ClientID + "').style.display='none';},4500);";
                        //ScriptManager.RegisterStartupScript(this, this.GetType(), "script", script, true);
                        string alertScript = "jAlert('Error', 'Campus2Caretaker');";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertScript", alertScript, true);
                    }
                }
                catch { }
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(hfStudentID.Value.ToString()))
            {
                //string script = @"document.getElementById('" + divStatus.ClientID + "').innerHTML='Error.Please select a student';var elem = document.createElement('img');elem.setAttribute('src', 'cross.jpg');document.getElementById('" + divStatus.ClientID + "').appendChild(elem);document.getElementById('" + divStatus.ClientID + "').style.color = 'Red';document.getElementById('" + divStatus.ClientID + "').style.fontSize = '1em' ;document.getElementById('" + divStatus.ClientID + "').style.fontWeight = 'bold' ;setTimeout(function(){document.getElementById('" + divStatus.ClientID + "').style.display='none';},4500);";
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "script", script, true);
                string alertScript = "jAlert('Please Select a Student', 'Campus2Caretaker');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertScript", alertScript, true);
                return;
            }

            if (Page.IsValid)
            {
                try
                {
                    DTOStudentRegistration tostu = new DTOStudentRegistration();
                    tostu.StudentId = int.Parse(hfStudentID.Value.ToString()); ;

                    if (new BOStudentRegistration().DeleteStudentDetails(tostu))
                    {
                        //string script = @"document.getElementById('" + divStatus.ClientID + "').innerHTML='Record deleted';var elem = document.createElement('img');elem.setAttribute('src', 'tick.jpg');document.getElementById('" + divStatus.ClientID + "').appendChild(elem);document.getElementById('" + divStatus.ClientID + "').style.color = 'Green';document.getElementById('" + divStatus.ClientID + "').style.fontSize = '1em' ;document.getElementById('" + divStatus.ClientID + "').style.fontWeight = 'bold' ;setTimeout(function(){document.getElementById('" + divStatus.ClientID + "').style.display='none';},4500);";
                        //ScriptManager.RegisterStartupScript(this, this.GetType(), "script", script, true);
                        string alertScript = "jAlert('Student Details Deleted Sucessfully', 'Campus2Caretaker');";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertScript", alertScript, true);
                        RefreshGridView();
                        clear();
                    }
                    else
                    {
                        //string script = @"document.getElementById('" + divStatus.ClientID + "').innerHTML='Error';var elem = document.createElement('img');elem.setAttribute('src', 'cross.jpg');document.getElementById('" + divStatus.ClientID + "').appendChild(elem);document.getElementById('" + divStatus.ClientID + "').style.color = 'Red';document.getElementById('" + divStatus.ClientID + "').style.fontSize = '1em' ;document.getElementById('" + divStatus.ClientID + "').style.fontWeight = 'bold' ;setTimeout(function(){document.getElementById('" + divStatus.ClientID + "').style.display='none';},4500);";
                        //ScriptManager.RegisterStartupScript(this, this.GetType(), "script", script, true);
                        string alertScript = "jAlert('Error', 'Campus2Caretaker');";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertScript", alertScript, true);
                    }
                }
                catch { }
            }
        }

        private void RefreshGridView()
        {
            DataTable dt = new BOStudentRegistration().GetStudentsList(Session["InstituteID"].ToString());
            string strSort = String.Empty;
            if (ViewState.Keys.Count > 0)
            {
                strSort = String.Format("{0} {1}", m_strSortExp, (m_SortDirection == SortDirection.Descending) ? "DESC" : "ASC");
                dt.DefaultView.Sort = strSort;
            }
            DataView dv = new DataView(dt, String.Empty, strSort, DataViewRowState.CurrentRows);
            gvStudents.DataSource = dv;
            gvStudents.DataBind();
        }

        protected void gvStudents_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                if (String.Empty != m_strSortExp)
                {
                    AddSortImage(e.Row);
                }
            }
        }

        protected void gvStudents_Sorting(object sender, GridViewSortEventArgs e)
        {
            // There seems to be a bug in GridView sorting implementation. Value of
            // SortDirection is always set to "Ascending". Now we will have to play
            // little trick here to switch the direction ourselves.
            if (String.Empty != m_strSortExp)
            {
                if (String.Compare(e.SortExpression, m_strSortExp, true) == 0)
                {
                    m_SortDirection =
                        (m_SortDirection == SortDirection.Ascending) ? SortDirection.Descending : SortDirection.Ascending;
                }
            }
            ViewState["_Direction_"] = m_SortDirection;
            ViewState["_SortExp_"] = m_strSortExp = e.SortExpression;
            this.RefreshGridView();
        }

        void AddSortImage(GridViewRow headerRow)
        {
            Int32 iCol = GetSortColumnIndex(m_strSortExp);
            if (-1 == iCol)
            {
                return;
            }
            // Create the sorting image based on the sort direction.
            Image sortImage = new Image();
            if (SortDirection.Ascending == m_SortDirection)
            {
                sortImage.ImageUrl = "~/images/app/up.gif";
                sortImage.AlternateText = "Ascending Order";
            }
            else
            {
                sortImage.ImageUrl = "~/images/app/dwn.gif";
                sortImage.AlternateText = "Descending Order";
            }

            // Add the image to the appropriate header cell.
            headerRow.Cells[iCol].Controls.Add(sortImage);
        }

        protected void gvStudents_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvStudents.PageIndex = e.NewPageIndex;
            RefreshGridView();
        }

        protected void btnGetStudentInfo_Click(object sender, EventArgs e)
        {
            DTOStudentRegistration tostu = new DTOStudentRegistration();
            tostu.StudentId = int.Parse(hfStudentID.Value.ToString());
            btnSave.Enabled = false;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
            DataTable dt = new DataTable();
            dt = new BOStudentRegistration().GetStudentDetails(tostu);
            try
            {
                txtStudentName.Text = dt.Rows[0][0].ToString();
                txtFatherName.Text = dt.Rows[0][2].ToString();
                txtMotherName.Text = dt.Rows[0][3].ToString();
                txtDOB.Text = DateTime.Parse(dt.Rows[0][4].ToString()).ToString("dd MMMM, yyyy");
                if (Session["InstituteType"].ToString() != "S")
                    ddlSemester.SelectedValue = dt.Rows[0][5].ToString();
                ddlClass.SelectedValue = dt.Rows[0][6].ToString();
                txtRollNo.Text = dt.Rows[0][8].ToString();
                txtParentsContactNumber.Text = dt.Rows[0][9].ToString();
                txtStudentAddress.Text = dt.Rows[0][11].ToString();
                txtParentsEmail.Text = dt.Rows[0][12].ToString();
                ddlGender.SelectedValue = dt.Rows[0][13].ToString();
            }
            catch
            {

            }

        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            try
            {
                if (FlUploadcsv.HasFile)
                {
                    string FileName = FlUploadcsv.FileName;
                    if (FlUploadcsv.PostedFile.ContentType == "application/vnd.ms-excel" ||
                        FlUploadcsv.PostedFile.ContentType == "application/excel" ||
                        FlUploadcsv.PostedFile.ContentType == "application/x-msexcel" ||
                        FlUploadcsv.PostedFile.ContentType == "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet" //this is xlsx format
                        )
                    {
                        string path = string.Concat(Server.MapPath("~/Documents/" + FlUploadcsv.FileName));
                        FlUploadcsv.PostedFile.SaveAs(path);

                        System.Data.DataTable dt = new System.Data.DataTable();
                        dt.Columns.Add("StudentName", typeof(string));
                        dt.Columns.Add("LastName", typeof(string));
                        dt.Columns.Add("FatherName", typeof(string));
                        dt.Columns.Add("MotherName", typeof(string));
                        dt.Columns.Add("DateOfBirth", typeof(DateTime));
                        dt.Columns.Add("Semester", typeof(string));
                        dt.Columns.Add("Branch", typeof(string));
                        dt.Columns.Add("Section", typeof(string));
                        dt.Columns.Add("RollNo", typeof(string));
                        dt.Columns.Add("ParentsMobileNo", typeof(string));
                        dt.Columns.Add("StudentAddress", typeof(string));
                        dt.Columns.Add("Gender", typeof(string));
                        dt.Columns.Add("ParentsEmail", typeof(string));

                        bool isValidExcelSheet = CheckExcelSheet(FileName, dt);
                        if (isValidExcelSheet)
                        {
                            if (new BOStudentRegistration().SaveStudentRegistrationExcel(dt, Session["InstituteID"].ToString()))
                            {
                                string _messageTemplate = new BOSms().GetSMSTemplate("NEWSTUDENTADDED");

                                #region SMS
                                for (int i = 0; i < dt.Rows.Count; i++)
                                {
                                    C2CSMS.SendSMS(_messageTemplate.Replace("##STUDENTNAME##", dt.Rows[i][0].ToString()).Replace("##InstituteName##", Session["InstituteName"].ToString()), dt.Rows[i][9].ToString());
                                }
                                #endregion

                                #region E-Mail
                                for (int i = 0; i < dt.Rows.Count; i++)
                                {
                                    //Send mail
                                    if (!string.IsNullOrEmpty(dt.Rows[i][12].ToString()))
                                    {
                                        string s_subject = "Information From Campus2Caretaker";
                                        string s_msg = String.Concat("Greetings from Campus2Caretaker.", _messageTemplate.Replace("##STUDENTNAME##", dt.Rows[i][0].ToString()).Replace("##InstituteName##", Session["InstituteName"].ToString())) + Environment.NewLine + Environment.NewLine;

                                        C2CEmail.SendC2CMail(s_msg, s_subject, string.Empty, dt.Rows[i][12].ToString(), null, null);
                                    }
                                }

                                #endregion

                                //string script = @"document.getElementById('" + dvUploadStatus.ClientID + "').innerHTML='Excel uploaded successfully..';var elem = document.createElement('img');elem.setAttribute('src', 'tick.jpg');document.getElementById('" + dvUploadStatus.ClientID + "').appendChild(elem);document.getElementById('" + dvUploadStatus.ClientID + "').style.color = 'Green';document.getElementById('" + dvUploadStatus.ClientID + "').style.fontSize = '1em' ;document.getElementById('" + dvUploadStatus.ClientID + "').style.fontWeight = 'bold' ;setTimeout(function(){document.getElementById('" + dvUploadStatus.ClientID + "').style.display='none';},4500);";
                                //ScriptManager.RegisterStartupScript(this, this.GetType(), "script", script, true);
                                string alertScript = "jAlert('Excel Uploaded Successfully', 'Campus2Caretaker');";
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertScript", alertScript, true);
                            }
                            else
                            {
                                //string script = @"document.getElementById('" + dvUploadStatus.ClientID + "').innerHTML='Error in saving Excel!!';var elem = document.createElement('img');elem.setAttribute('src', 'cross.jpg');document.getElementById('" + dvUploadStatus.ClientID + "').appendChild(elem);document.getElementById('" + dvUploadStatus.ClientID + "').style.color = 'Red';document.getElementById('" + dvUploadStatus.ClientID + "').style.fontSize = '1em' ;document.getElementById('" + dvUploadStatus.ClientID + "').style.fontWeight = 'bold' ;setTimeout(function(){document.getElementById('" + dvUploadStatus.ClientID + "').style.display='none';},4500);";
                                //ScriptManager.RegisterStartupScript(this, this.GetType(), "script", script, true);
                                string alertScript = "jAlert('Error in saving Excel', 'Campus2Caretaker');";
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertScript", alertScript, true);
                                System.IO.File.Delete(Server.MapPath("~/Documents/").Replace("\\", "/") + FileName);
                            }
                        }
                        else
                        {
                            System.IO.File.Delete(Server.MapPath("~/Documents/").Replace("\\", "/") + FileName);
                        }
                    }
                    else
                    {
                        //string script = @"document.getElementById('" + dvUploadStatus.ClientID + "').innerHTML='Please select a valid excel file';var elem = document.createElement('img');elem.setAttribute('src', 'cross.jpg');document.getElementById('" + dvUploadStatus.ClientID + "').appendChild(elem);document.getElementById('" + dvUploadStatus.ClientID + "').style.color = 'Red';document.getElementById('" + dvUploadStatus.ClientID + "').style.fontSize = '1em' ;document.getElementById('" + dvUploadStatus.ClientID + "').style.fontWeight = 'bold' ;setTimeout(function(){document.getElementById('" + dvUploadStatus.ClientID + "').style.display='none';},4500);";
                        //ScriptManager.RegisterStartupScript(this, this.GetType(), "script", script, true);
                        string alertScript = "jAlert('Please Select a Valid Excel File', 'Campus2Caretaker');";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertScript", alertScript, true);
                    }
                }
                else
                {
                    //string script = @"document.getElementById('" + dvUploadStatus.ClientID + "').innerHTML='Please select the excel file';var elem = document.createElement('img');elem.setAttribute('src', 'cross.jpg');document.getElementById('" + dvUploadStatus.ClientID + "').appendChild(elem);document.getElementById('" + dvUploadStatus.ClientID + "').style.color = 'Red';document.getElementById('" + dvUploadStatus.ClientID + "').style.fontSize = '1em' ;document.getElementById('" + dvUploadStatus.ClientID + "').style.fontWeight = 'bold' ;setTimeout(function(){document.getElementById('" + dvUploadStatus.ClientID + "').style.display='none';},4500);";
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "script", script, true);
                    string alertScript = "jAlert('Please Select Excel File', 'Campus2Caretaker');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertScript", alertScript, true);
                }
            }
            catch
            {

            }
        }

        private bool CheckExcelSheet(string FileName, DataTable dt)
        {
            bool isValidExcelSheet = true;
            try
            {
                #region local variables for processing

                string StudentName = "";
                string LastName = "";
                string FatherName = "";
                string MotherName = "";
                DateTime DateOfBirth;
                int Semester;
                string Branch = "";
                string Section = "";
                string RollNo = "";
                string ParentsMobileNo = "";
                string StudentAddress = "";
                string Gender = "";
                string ParentsEmail = "";

                #endregion

                string path = string.Concat(Server.MapPath("~/Documents/" + FileName));

                FileStream stream = File.Open(path, FileMode.Open, FileAccess.Read);
                IExcelDataReader excelReader;

                switch (Path.GetExtension(path).ToLower())
                {
                    case ".xls":
                        //1. Reading from a binary Excel file ('97-2003 format; *.xls)
                        excelReader = ExcelReaderFactory.CreateBinaryReader(stream);
                        break;
                    //...
                    case ".xlsx":
                        //2. Reading from a OpenXml Excel file (2007 format; *.xlsx)
                        excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                        break;
                    //...
                    default:
                        return false;
                }
                //3. DataSet - Create column names from first row
                excelReader.IsFirstRowAsColumnNames = true;
                DataSet result = excelReader.AsDataSet();

                //5. Data Reader methods

                for (int i = 0; i < result.Tables[0].Rows.Count; i++)
                {
                    //excelReader.GetInt32(0);
                    try
                    {
                        StudentName = valid(result.Tables[0].Rows[i], 0);
                        LastName = valid(result.Tables[0].Rows[i], 1);
                        FatherName = valid(result.Tables[0].Rows[i], 2);
                        MotherName = valid(result.Tables[0].Rows[i], 3);
                        DateOfBirth = DateTime.Parse(valid(result.Tables[0].Rows[i], 4));

                        if (Session["InstituteType"].ToString() == "S")
                        {
                            Semester = 0;
                        }
                        else
                        {
                            Semester = int.Parse(valid(result.Tables[0].Rows[i], 5));
                        }

                        Branch = valid(result.Tables[0].Rows[i], 6);
                        Section = valid(result.Tables[0].Rows[i], 7);
                        RollNo = valid(result.Tables[0].Rows[i], 8);
                        ParentsMobileNo = valid(result.Tables[0].Rows[i], 9);
                        StudentAddress = valid(result.Tables[0].Rows[i], 10);
                        Gender = valid(result.Tables[0].Rows[i], 11);
                        ParentsEmail = valid(result.Tables[0].Rows[i], 12);

                        if (excelReader[0] == DBNull.Value)
                            break;
                        string BranchId = new BOStudentRegistration().GetBranchId(valid(result.Tables[0].Rows[i], 6));
                        if (BranchId == string.Empty)
                        {
                            //string script = @"document.getElementById('" + dvUploadStatus.ClientID + "').innerHTML='Invalid Branch Name found in Branch column!!; it should be number!!';var elem = document.createElement('img');elem.setAttribute('src', 'cross.jpg');document.getElementById('" + dvUploadStatus.ClientID + "').appendChild(elem);document.getElementById('" + dvUploadStatus.ClientID + "').style.color = 'Red';document.getElementById('" + dvUploadStatus.ClientID + "').style.fontSize = '1em' ;document.getElementById('" + dvUploadStatus.ClientID + "').style.fontWeight = 'bold' ;setTimeout(function(){document.getElementById('" + dvUploadStatus.ClientID + "').style.display='none';},4500);";
                            //ScriptManager.RegisterStartupScript(this, this.GetType(), "script", script, true);
                            string alertScript = "jAlert('Invalid Branch Name found in Branch column', 'Campus2Caretaker');";
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertScript", alertScript, true);
                            return false;
                        }

                        int intvalue;
                        if (!int.TryParse(Semester.ToString(), out intvalue))
                        {
                            //string script = @"document.getElementById('" + dvUploadStatus.ClientID + "').innerHTML='Invalid Semester Id found in Semester column!!; it should be numeric!!';var elem = document.createElement('img');elem.setAttribute('src', 'cross.jpg');document.getElementById('" + dvUploadStatus.ClientID + "').appendChild(elem);document.getElementById('" + dvUploadStatus.ClientID + "').style.color = 'Red';document.getElementById('" + dvUploadStatus.ClientID + "').style.fontSize = '1em' ;document.getElementById('" + dvUploadStatus.ClientID + "').style.fontWeight = 'bold' ;setTimeout(function(){document.getElementById('" + dvUploadStatus.ClientID + "').style.display='none';},4500);";
                            //ScriptManager.RegisterStartupScript(this, this.GetType(), "script", script, true); isValidExcelSheet = false;
                            string alertScript = "jAlert('Invalid Semester Id found in Semester column', 'Campus2Caretaker');";
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertScript", alertScript, true);
                            isValidExcelSheet = false;
                            break;
                        }

                        DateTime dateTimeValue;
                        if (!DateTime.TryParse(DateOfBirth.ToString(), out dateTimeValue))
                        {
                            //string script = @"document.getElementById('" + dvUploadStatus.ClientID + "').innerHTML='Invalid DOB found in DOB column!!; it should be numeric!!';var elem = document.createElement('img');elem.setAttribute('src', 'cross.jpg');document.getElementById('" + dvUploadStatus.ClientID + "').appendChild(elem);document.getElementById('" + dvUploadStatus.ClientID + "').style.color = 'Red';document.getElementById('" + dvUploadStatus.ClientID + "').style.fontSize = '1em' ;document.getElementById('" + dvUploadStatus.ClientID + "').style.fontWeight = 'bold' ;setTimeout(function(){document.getElementById('" + dvUploadStatus.ClientID + "').style.display='none';},4500);";
                            //ScriptManager.RegisterStartupScript(this, this.GetType(), "script", script, true);
                            string alertScript = "jAlert('Invalid DOB found in DOB column', 'Campus2Caretaker');";
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertScript", alertScript, true);
                            isValidExcelSheet = false;
                            break;
                        }

                        string genderValue = valid(result.Tables[0].Rows[i], 11);
                        if (genderValue == string.Empty || (genderValue != "Male" && genderValue != "Female"))
                        {
                            //string script = @"document.getElementById('" + dvUploadStatus.ClientID + "').innerHTML='Invalid Gender found in Gender column!!; it should be Male or Female!!';var elem = document.createElement('img');elem.setAttribute('src', 'cross.jpg');document.getElementById('" + dvUploadStatus.ClientID + "').appendChild(elem);document.getElementById('" + dvUploadStatus.ClientID + "').style.color = 'Red';document.getElementById('" + dvUploadStatus.ClientID + "').style.fontSize = '1em' ;document.getElementById('" + dvUploadStatus.ClientID + "').style.fontWeight = 'bold' ;setTimeout(function(){document.getElementById('" + dvUploadStatus.ClientID + "').style.display='none';},4500);";
                            //ScriptManager.RegisterStartupScript(this, this.GetType(), "script", script, true);
                            string alertScript = "jAlert('Invalid Gender found in Gender column', 'Campus2Caretaker');";
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertScript", alertScript, true);
                            return false;
                        }

                        string parentsEmailValue = valid(result.Tables[0].Rows[i], 12);
                        RegexUtilities util = new RegexUtilities();
                        if (parentsEmailValue != string.Empty)
                        {
                            if (!util.IsValidEmail(parentsEmailValue))
                            {
                                //string script = @"document.getElementById('" + dvUploadStatus.ClientID + "').innerHTML='Invalid email found in parents email column!!';var elem = document.createElement('img');elem.setAttribute('src', 'cross.jpg');document.getElementById('" + dvUploadStatus.ClientID + "').appendChild(elem);document.getElementById('" + dvUploadStatus.ClientID + "').style.color = 'Red';document.getElementById('" + dvUploadStatus.ClientID + "').style.fontSize = '1em' ;document.getElementById('" + dvUploadStatus.ClientID + "').style.fontWeight = 'bold' ;setTimeout(function(){document.getElementById('" + dvUploadStatus.ClientID + "').style.display='none';},4500);";
                                //ScriptManager.RegisterStartupScript(this, this.GetType(), "script", script, true);
                                string alertScript = "jAlert('Invalid email found in parents email column', 'Campus2Caretaker');";
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertScript", alertScript, true);
                                return false;
                            }
                        }
                        //Here using this method we are inserting the data into a temporary DataTable
                        dt.Rows.Add(StudentName, LastName, FatherName, MotherName, DateOfBirth, Semester, BranchId, Section, RollNo, ParentsMobileNo, StudentAddress, Gender, ParentsEmail);
                    }

                    catch (Exception err)
                    {
                        //string script = @"document.getElementById('" + dvUploadStatus.ClientID + "').innerHTML='Invalid data found in uploaded excel!!';var elem = document.createElement('img');elem.setAttribute('src', 'cross.jpg');document.getElementById('" + dvUploadStatus.ClientID + "').appendChild(elem);document.getElementById('" + dvUploadStatus.ClientID + "').style.color = 'Red';document.getElementById('" + dvUploadStatus.ClientID + "').style.fontSize = '1em' ;document.getElementById('" + dvUploadStatus.ClientID + "').style.fontWeight = 'bold' ;setTimeout(function(){document.getElementById('" + dvUploadStatus.ClientID + "').style.display='none';},4500);";
                        //ScriptManager.RegisterStartupScript(this, this.GetType(), "script", script, true); isValidExcelSheet = false;
                        string alertScript = "jAlert('Invalid data found in uploaded excel', 'Campus2Caretaker');";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertScript", alertScript, true);
                        isValidExcelSheet = false;
                        break;
                    }
                }
                //6. Free resources (IExcelDataReader is IDisposable)
                excelReader.Close();

            }
            catch (DataException ee)
            {
                //string script = @"document.getElementById('" + dvUploadStatus.ClientID + "').innerHTML='" + ee.Message + "';var elem = document.createElement('img');elem.setAttribute('src', 'cross.jpg');document.getElementById('" + dvUploadStatus.ClientID + "').appendChild(elem);document.getElementById('" + dvUploadStatus.ClientID + "').style.color = 'Red';document.getElementById('" + dvUploadStatus.ClientID + "').style.fontSize = '1em' ;document.getElementById('" + dvUploadStatus.ClientID + "').style.fontWeight = 'bold' ;setTimeout(function(){document.getElementById('" + dvUploadStatus.ClientID + "').style.display='none';},4500);";
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "script", script, true);
                string alertScript = "jAlert('"+ ee.Message +"', 'Campus2Caretaker');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertScript", alertScript, true);
                isValidExcelSheet = false;
            }
            finally
            {

            }

            return isValidExcelSheet;
        }

        protected string valid(DataRow row, int stval)
        {
            //if any columns are found null then they are replaced by zero
            object val = row[stval];
            if (val != DBNull.Value)
                return val.ToString();
            else
                return Convert.ToString("");
        }
    }
}