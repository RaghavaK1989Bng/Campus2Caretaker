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
    public partial class ImportStudents : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Response.Cache.SetNoStore();
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
                        bool isValidExcelSheet = CheckOptionsExcel(FileName, dt);
                        if (isValidExcelSheet)
                        {
                            if (new BOStudentRegistration().SaveStudentRegistrationExcel(dt, Session["InstituteID"].ToString()))
                            {
                                string script = @"document.getElementById('" + divStatus.ClientID + "').innerHTML='Excel uploaded successfully..';var elem = document.createElement('img');elem.setAttribute('src', 'tick.jpg');document.getElementById('" + divStatus.ClientID + "').appendChild(elem);document.getElementById('" + divStatus.ClientID + "').style.color = 'Green';document.getElementById('" + divStatus.ClientID + "').style.fontSize = '1em' ;document.getElementById('" + divStatus.ClientID + "').style.fontWeight = 'bold' ;setTimeout(function(){document.getElementById('" + divStatus.ClientID + "').style.display='none';},4500);";
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", script, true);
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
    }
}