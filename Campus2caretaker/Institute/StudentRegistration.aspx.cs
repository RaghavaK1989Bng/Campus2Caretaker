using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessObjects;
using DataTransferObject;
using System.IO;
using Excel;

namespace Campus2caretaker.Institute
{
    public partial class StudentRegistration : System.Web.UI.Page
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
            }

            if (null != ViewState["_SortExp_"])
            {
                m_strSortExp = ViewState["_SortExp_"] as String;
            }

            if (null != ViewState["_Direction_"])
            {
                m_SortDirection = (SortDirection)ViewState["_Direction_"];
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
                validator.ValidationGroup = "Student";
                validator.ForeColor = System.Drawing.Color.Red;
                validator.InitialValue = "Select";
                validator.ToolTip = "Semester Selection is required.";

                this.Form.FindControl("ContentPlaceHolder1").Controls.Add(validator);
            }
        }

        private void clear()
        {
            //Clears all the fields and gets the form to initial state

            ddlClass.Items.Clear();

            RefreshClasses();

            ddlClass.SelectedIndex = 0;
            ddlSemester.SelectedIndex = 0;
            txtDOB.Text = "";
            txtFatherName.Text = "";
            txtMotherName.Text = "";
            txtParentsContactNumber.Text = "";
            txtRollNo.Text = "";
            txtStudentAddress.Text = "";
            txtStudentName.Text = "";

            RefreshGridView();

            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
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

                    if (new BOStudentRegistration().SaveStudentDetails(tostud))
                    {
                        string script = @"document.getElementById('" + divStatus.ClientID + "').innerHTML='Record inserted';var elem = document.createElement('img');elem.setAttribute('src', 'tick.jpg');document.getElementById('" + divStatus.ClientID + "').appendChild(elem);document.getElementById('" + divStatus.ClientID + "').style.color = 'Green';document.getElementById('" + divStatus.ClientID + "').style.fontSize = '1em' ;document.getElementById('" + divStatus.ClientID + "').style.fontWeight = 'bold' ;setTimeout(function(){document.getElementById('" + divStatus.ClientID + "').style.display='none';},4500);";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "script", script, true);

                        clear();
                        RefreshGridView();
                    }
                    else
                    {
                        string script = @"document.getElementById('" + divStatus.ClientID + "').innerHTML='Error';var elem = document.createElement('img');elem.setAttribute('src', 'cross.jpg');document.getElementById('" + divStatus.ClientID + "').appendChild(elem);document.getElementById('" + divStatus.ClientID + "').style.color = 'Red';document.getElementById('" + divStatus.ClientID + "').style.fontSize = '1em' ;document.getElementById('" + divStatus.ClientID + "').style.fontWeight = 'bold' ;setTimeout(function(){document.getElementById('" + divStatus.ClientID + "').style.display='none';},4500);";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "script", script, true);
                    }
                }
                catch { }
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    DTOStudentRegistration tostud = new DTOStudentRegistration();
                    tostud.StudentId = int.Parse(gvStudents.SelectedDataKey.Value.ToString());
                    tostud.Address = txtStudentAddress.Text;
                    tostud.BranchId = int.Parse(ddlClass.SelectedValue);
                    tostud.DOB = DateTime.Parse(txtDOB.Text);
                    tostud.FatherName = txtFatherName.Text;
                    tostud.InstituteId = int.Parse(Session["InstituteID"].ToString());
                    tostud.MotherName = txtMotherName.Text;
                    tostud.ParentsMobileNo = txtParentsContactNumber.Text;
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

                    if (new BOStudentRegistration().UpdateStudentDetails(tostud))
                    {
                        string script = @"document.getElementById('" + divStatus.ClientID + "').innerHTML='Record updated';var elem = document.createElement('img');elem.setAttribute('src', 'tick.jpg');document.getElementById('" + divStatus.ClientID + "').appendChild(elem);document.getElementById('" + divStatus.ClientID + "').style.color = 'Green';document.getElementById('" + divStatus.ClientID + "').style.fontSize = '1em' ;document.getElementById('" + divStatus.ClientID + "').style.fontWeight = 'bold' ;setTimeout(function(){document.getElementById('" + divStatus.ClientID + "').style.display='none';},4500);";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "script", script, true);

                        clear();
                        RefreshGridView();
                    }
                    else
                    {
                        string script = @"document.getElementById('" + divStatus.ClientID + "').innerHTML='Error';var elem = document.createElement('img');elem.setAttribute('src', 'cross.jpg');document.getElementById('" + divStatus.ClientID + "').appendChild(elem);document.getElementById('" + divStatus.ClientID + "').style.color = 'Red';document.getElementById('" + divStatus.ClientID + "').style.fontSize = '1em' ;document.getElementById('" + divStatus.ClientID + "').style.fontWeight = 'bold' ;setTimeout(function(){document.getElementById('" + divStatus.ClientID + "').style.display='none';},4500);";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "script", script, true);
                    }
                }
                catch { }
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    DTOStudentRegistration tostu = new DTOStudentRegistration();
                    tostu.StudentId = int.Parse(gvStudents.SelectedDataKey.Value.ToString()); ;

                    if (new BOStudentRegistration().DeleteStudentDetails(tostu))
                    {
                        string script = @"document.getElementById('" + divStatus.ClientID + "').innerHTML='Record deleted';var elem = document.createElement('img');elem.setAttribute('src', 'tick.jpg');document.getElementById('" + divStatus.ClientID + "').appendChild(elem);document.getElementById('" + divStatus.ClientID + "').style.color = 'Green';document.getElementById('" + divStatus.ClientID + "').style.fontSize = '1em' ;document.getElementById('" + divStatus.ClientID + "').style.fontWeight = 'bold' ;setTimeout(function(){document.getElementById('" + divStatus.ClientID + "').style.display='none';},4500);";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "script", script, true);
                        RefreshGridView();
                        clear();
                    }
                    else
                    {
                        string script = @"document.getElementById('" + divStatus.ClientID + "').innerHTML='Error';var elem = document.createElement('img');elem.setAttribute('src', 'cross.jpg');document.getElementById('" + divStatus.ClientID + "').appendChild(elem);document.getElementById('" + divStatus.ClientID + "').style.color = 'Red';document.getElementById('" + divStatus.ClientID + "').style.fontSize = '1em' ;document.getElementById('" + divStatus.ClientID + "').style.fontWeight = 'bold' ;setTimeout(function(){document.getElementById('" + divStatus.ClientID + "').style.display='none';},4500);";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "script", script, true);
                    }
                }
                catch { }
            }
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

            ListItem Item = new ListItem("Select", "");
            ddlClass.Items.Insert(0, Item);
            ddlClass.SelectedIndex = 0;
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

        protected void gvStudents_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";
                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.gvStudents, "Select$" + e.Row.RowIndex);
            }
        }

        protected void gvStudents_SelectedIndexChanged(object sender, EventArgs e)
        {
            DTOStudentRegistration tostu = new DTOStudentRegistration();
            tostu.StudentId = int.Parse(gvStudents.SelectedDataKey.Value.ToString());
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
            }
            catch
            {

            }
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
                        bool isValidExcelSheet = CheckOptionsExcel(FileName, dt);
                        if (isValidExcelSheet)
                        {
                            if (new BOStudentRegistration().SaveStudentRegistrationExcel(dt, Session["InstituteID"].ToString()))
                            {
                                string script = @"document.getElementById('" + divStatus.ClientID + "').innerHTML='Excel uploaded successfully..';var elem = document.createElement('img');elem.setAttribute('src', 'tick.jpg');document.getElementById('" + divStatus.ClientID + "').appendChild(elem);document.getElementById('" + divStatus.ClientID + "').style.color = 'Green';document.getElementById('" + divStatus.ClientID + "').style.fontSize = '1em' ;document.getElementById('" + divStatus.ClientID + "').style.fontWeight = 'bold' ;setTimeout(function(){document.getElementById('" + divStatus.ClientID + "').style.display='none';},4500);";
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", script, true);
                                RefreshGridView();
                            }
                            else
                            {
                                string script = @"document.getElementById('" + divStatus.ClientID + "').innerHTML='Error in saving Excel!!';var elem = document.createElement('img');elem.setAttribute('src', 'cross.jpg');document.getElementById('" + divStatus.ClientID + "').appendChild(elem);document.getElementById('" + divStatus.ClientID + "').style.color = 'Red';document.getElementById('" + divStatus.ClientID + "').style.fontSize = '1em' ;document.getElementById('" + divStatus.ClientID + "').style.fontWeight = 'bold' ;setTimeout(function(){document.getElementById('" + divStatus.ClientID + "').style.display='none';},4500);";
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", script, true);
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
                        string script = @"document.getElementById('" + divStatus.ClientID + "').innerHTML='Please select a valid excel file';var elem = document.createElement('img');elem.setAttribute('src', 'cross.jpg');document.getElementById('" + divStatus.ClientID + "').appendChild(elem);document.getElementById('" + divStatus.ClientID + "').style.color = 'Red';document.getElementById('" + divStatus.ClientID + "').style.fontSize = '1em' ;document.getElementById('" + divStatus.ClientID + "').style.fontWeight = 'bold' ;setTimeout(function(){document.getElementById('" + divStatus.ClientID + "').style.display='none';},4500);";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "script", script, true);

                    }
                }
                else
                {
                    string script = @"document.getElementById('" + divStatus.ClientID + "').innerHTML='Please select the excel file';var elem = document.createElement('img');elem.setAttribute('src', 'cross.jpg');document.getElementById('" + divStatus.ClientID + "').appendChild(elem);document.getElementById('" + divStatus.ClientID + "').style.color = 'Red';document.getElementById('" + divStatus.ClientID + "').style.fontSize = '1em' ;document.getElementById('" + divStatus.ClientID + "').style.fontWeight = 'bold' ;setTimeout(function(){document.getElementById('" + divStatus.ClientID + "').style.display='none';},4500);";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", script, true);
                }
            }
            catch
            {

            }
        }

        private bool CheckOptionsExcel(string FileName, DataTable dt)
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

                        if (excelReader[0] == DBNull.Value)
                            break;
                        string BranchId = new BOStudentRegistration().GetBranchId(valid(result.Tables[0].Rows[i], 6));
                        if (BranchId == string.Empty)
                        {
                            string script = @"document.getElementById('" + divStatus.ClientID + "').innerHTML='Invalid Branch Name found in Branch column!!; it should be number!!';var elem = document.createElement('img');elem.setAttribute('src', 'cross.jpg');document.getElementById('" + divStatus.ClientID + "').appendChild(elem);document.getElementById('" + divStatus.ClientID + "').style.color = 'Red';document.getElementById('" + divStatus.ClientID + "').style.fontSize = '1em' ;document.getElementById('" + divStatus.ClientID + "').style.fontWeight = 'bold' ;setTimeout(function(){document.getElementById('" + divStatus.ClientID + "').style.display='none';},4500);";
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", script, true);
                            return false;
                        }

                        int intvalue;
                        if (!int.TryParse(Semester.ToString(), out intvalue))
                        {
                            string script = @"document.getElementById('" + divStatus.ClientID + "').innerHTML='Invalid Semester Id found in Semester column!!; it should be numeric!!';var elem = document.createElement('img');elem.setAttribute('src', 'cross.jpg');document.getElementById('" + divStatus.ClientID + "').appendChild(elem);document.getElementById('" + divStatus.ClientID + "').style.color = 'Red';document.getElementById('" + divStatus.ClientID + "').style.fontSize = '1em' ;document.getElementById('" + divStatus.ClientID + "').style.fontWeight = 'bold' ;setTimeout(function(){document.getElementById('" + divStatus.ClientID + "').style.display='none';},4500);";
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", script, true); isValidExcelSheet = false;
                            isValidExcelSheet = false;
                            break;
                        }

                        DateTime dateTimeValue;
                        if (!DateTime.TryParse(DateOfBirth.ToString(), out dateTimeValue))
                        {
                            string script = @"document.getElementById('" + divStatus.ClientID + "').innerHTML='Invalid DOB found in DOB column!!; it should be numeric!!';var elem = document.createElement('img');elem.setAttribute('src', 'cross.jpg');document.getElementById('" + divStatus.ClientID + "').appendChild(elem);document.getElementById('" + divStatus.ClientID + "').style.color = 'Red';document.getElementById('" + divStatus.ClientID + "').style.fontSize = '1em' ;document.getElementById('" + divStatus.ClientID + "').style.fontWeight = 'bold' ;setTimeout(function(){document.getElementById('" + divStatus.ClientID + "').style.display='none';},4500);";
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", script, true); isValidExcelSheet = false;
                            isValidExcelSheet = false;
                            break;
                        }

                        //Here using this method we are inserting the data into a temporary DataTable
                        dt.Rows.Add(StudentName, LastName, FatherName, MotherName, DateOfBirth, Semester, BranchId, Section, RollNo, ParentsMobileNo, StudentAddress);
                    }
                   
                    catch (Exception err)
                    {
                        string script = @"document.getElementById('" + divStatus.ClientID + "').innerHTML='Invalid data found in uploaded excel!!';var elem = document.createElement('img');elem.setAttribute('src', 'cross.jpg');document.getElementById('" + divStatus.ClientID + "').appendChild(elem);document.getElementById('" + divStatus.ClientID + "').style.color = 'Red';document.getElementById('" + divStatus.ClientID + "').style.fontSize = '1em' ;document.getElementById('" + divStatus.ClientID + "').style.fontWeight = 'bold' ;setTimeout(function(){document.getElementById('" + divStatus.ClientID + "').style.display='none';},4500);";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "script", script, true); isValidExcelSheet = false;
                        isValidExcelSheet = false;
                        break;
                    }
                }
                //6. Free resources (IExcelDataReader is IDisposable)
                excelReader.Close();

            }
            catch (DataException ee)
            {
                string script = @"document.getElementById('" + divStatus.ClientID + "').innerHTML='" + ee.Message + "';var elem = document.createElement('img');elem.setAttribute('src', 'cross.jpg');document.getElementById('" + divStatus.ClientID + "').appendChild(elem);document.getElementById('" + divStatus.ClientID + "').style.color = 'Red';document.getElementById('" + divStatus.ClientID + "').style.fontSize = '1em' ;document.getElementById('" + divStatus.ClientID + "').style.fontWeight = 'bold' ;setTimeout(function(){document.getElementById('" + divStatus.ClientID + "').style.display='none';},4500);";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", script, true);
                isValidExcelSheet = false;
            }
            finally
            {

            }

            return isValidExcelSheet;
        }

        protected string valid( DataRow row, int stval)
        {
            //if any columns are found null then they are replaced by zero
            object val = row[stval];
            if (val != DBNull.Value)
                return val.ToString();
            else
                return Convert.ToString("");
        }

        protected void gvStudents_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //gvStudents.PageIndex = e.NewPageIndex;
            //RefreshGridView();
        }
    }
}