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
    public partial class PromoteStudents : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Response.Cache.SetNoStore();

                clear();
                RefreshClasses();
            }

            if (Session["InstituteType"].ToString() == "S")
            {
                dvSemester.Visible = false;
            }
            else
            {
                dvSemester.Visible = true;

                RequiredFieldValidator validator = new RequiredFieldValidator();
                validator.ID = "FromSemesterRequired";
                validator.ControlToValidate = ((DropDownList)this.Form.FindControl("ContentPlaceHolder1").FindControl("ddlFromSemester")).ID;
                validator.EnableClientScript = true;
                validator.ErrorMessage = "From Semester Selection is required.";
                validator.Text = "*";
                validator.ValidationGroup = "PromoteStudents";
                validator.ForeColor = System.Drawing.Color.Red;
                validator.InitialValue = "Select";
                validator.ToolTip = "From Semester Selection is required.";

                RequiredFieldValidator validator1 = new RequiredFieldValidator();
                validator1.ID = "ToSemesterRequired";
                validator1.ControlToValidate = ((DropDownList)this.Form.FindControl("ContentPlaceHolder1").FindControl("ddlToSemester")).ID;
                validator1.EnableClientScript = true;
                validator1.ErrorMessage = "To Semester Selection is required.";
                validator1.Text = "*";
                validator1.ValidationGroup = "PromoteStudents";
                validator1.ForeColor = System.Drawing.Color.Red;
                validator1.InitialValue = "Select";
                validator1.ToolTip = "To Semester Selection is required.";

                this.Form.FindControl("ContentPlaceHolder1").Controls.Add(validator);
                this.Form.FindControl("ContentPlaceHolder1").Controls.Add(validator1);
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
            HttpContext.Current.Response.AddHeader("content-disposition", String.Format("attachment;filename={0}.xls", String.Concat("PromoteStudentDetails", DateTime.Now.Ticks)));
            gvPromoteStudents.GridLines = GridLines.Both;
            gvPromoteStudents.HeaderStyle.Font.Bold = true;
            gvPromoteStudents.RenderControl(htmltextwrtter);
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
                    gvPromoteStudents.RenderControl(hw);
                    StringReader sr = new StringReader(sw.ToString());
                    iTextSharp.text.Document pdfDoc = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4, 5f, 5f, 5f, 0f);
                    iTextSharp.text.html.simpleparser.HTMLWorker htmlparser = new iTextSharp.text.html.simpleparser.HTMLWorker(pdfDoc);
                    iTextSharp.text.pdf.PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                    pdfDoc.Open();
                    htmlparser.Parse(sr);
                    pdfDoc.Close();

                    Response.ContentType = "application/pdf";
                    Response.AddHeader("content-disposition", String.Format("attachment;filename={0}.pdf", String.Concat("PromoteStudentDetails", DateTime.Now.Ticks)));
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    Response.Write(pdfDoc);
                    Response.End();
                }
            }
        }

        private void RefreshClasses()
        {
            DataTable dt = new BOStudentRegistration().GetClassesList(Session["InstituteID"].ToString());
            ddlFromClass.DataSource = dt;
            ddlToClass.DataSource = dt;

            ddlFromClass.DataBind();
            ddlToClass.DataBind();

            System.Web.UI.WebControls.ListItem Item = new System.Web.UI.WebControls.ListItem("Select", "Select");
            ddlFromClass.Items.Insert(0, Item);
            ddlFromClass.SelectedIndex = 0;

            ddlToClass.Items.Insert(0, Item);
            ddlToClass.SelectedIndex = 0;
        }

        private void clear()
        {
            ddlFromClass.Items.Clear();
            ddlToClass.Items.Clear();
            RefreshClasses();
            ddlToClass.SelectedIndex = 0;
            ddlFromClass.SelectedIndex = 0;

            RefreshSemesters();

            ViewState["CurrentTable"] = null;
            SetInitialRow();
        }

        private void SetInitialRow()
        {
            DataTable dt = new DataTable();
            DataRow dr = null;
            dt.Columns.Add(new DataColumn("Column1", typeof(string)));
            dt.Columns.Add(new DataColumn("Column2", typeof(string)));
            dt.Columns.Add(new DataColumn("Column3", typeof(string)));

            dr = dt.NewRow();
            dr["Column1"] = string.Empty;
            dr["Column2"] = string.Empty;
            dr["Column3"] = string.Empty;

            dt.Rows.Add(dr);

            ViewState["CurrentTable"] = dt;

            gvPromoteStudents.DataSource = dt;
            gvPromoteStudents.DataBind();
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
                        Label lbl1 = (Label)gvPromoteStudents.Rows[rowIndex].Cells[1].FindControl("lblStudentName");
                        Label lbl2 = (Label)gvPromoteStudents.Rows[rowIndex].Cells[2].FindControl("lblRollNo");
                        Label lbl3 = (Label)gvPromoteStudents.Rows[rowIndex].Cells[3].FindControl("lblStudentID");

                        drCurrentRow = dtCurrentTable.NewRow();

                        lbl1.Text = dtStudents.Rows[p]["colStudentName"].ToString();
                        lbl2.Text = dtStudents.Rows[p]["colRollNo"].ToString();
                        lbl3.Text = dtStudents.Rows[p]["colStudentId"].ToString();

                        dtCurrentTable.Rows[i]["Column1"] = lbl1.Text;
                        dtCurrentTable.Rows[i]["Column2"] = lbl2.Text;
                        dtCurrentTable.Rows[i]["Column3"] = lbl3.Text;
                        rowIndex++;
                    }


                    dtCurrentTable.Rows.Add(drCurrentRow);
                    ViewState["CurrentTable"] = dtCurrentTable;

                    gvPromoteStudents.DataSource = dtCurrentTable;
                    gvPromoteStudents.DataBind();
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
                        Label lbl1 = (Label)gvPromoteStudents.Rows[rowIndex].Cells[1].FindControl("lblStudentName");
                        Label lbl2 = (Label)gvPromoteStudents.Rows[rowIndex].Cells[2].FindControl("lblRollNo");
                        Label lbl3 = (Label)gvPromoteStudents.Rows[rowIndex].Cells[3].FindControl("lblStudentID");


                        lbl1.Text = dt.Rows[i]["Column1"].ToString();
                        lbl2.Text = dt.Rows[i]["Column2"].ToString();
                        lbl3.Text = dt.Rows[i]["Column3"].ToString();

                        rowIndex++;
                    }
                }
            }
        }

        private void RefreshSemesters()
        {
            ddlFromSemester.Items.Clear();
            ddlToSemester.Items.Clear();
            List<System.Web.UI.WebControls.ListItem> items = GetSemesters.GetSemester(Session["InstituteType"].ToString());

            for (int i = 0; i < items.Count; i++)
            {
                System.Web.UI.WebControls.ListItem Item = new System.Web.UI.WebControls.ListItem(items[i].Text, items[i].Value);
                ddlFromSemester.Items.Add(Item);
                ddlToSemester.Items.Add(Item);
            }

            System.Web.UI.WebControls.ListItem SelectItem = new System.Web.UI.WebControls.ListItem("Select", "Select");
            ddlFromSemester.Items.Insert(0, SelectItem);
            ddlFromSemester.SelectedIndex = 0;

            ddlToSemester.Items.Insert(0, SelectItem);
            ddlToSemester.SelectedIndex = 0;
        }

        protected void btnSavePromoteStudents_Click(object sender, EventArgs e)
        {
            for (int index = 0; index < gvPromoteStudents.Rows.Count - 1; index++)
            {
                if (((CheckBox)gvPromoteStudents.Rows[index].FindControl("chkSelect")).Checked)
                {
                    Label lblStudentID = (Label)gvPromoteStudents.Rows[index].FindControl("lblStudentID");

                    int _studentId = int.Parse(lblStudentID.Text);
                    int _toClass = int.Parse(ddlToClass.SelectedValue);
                    int _toSemester;
                    if (Session["InstituteType"].ToString() == "S")
                    {
                        _toSemester = 0;
                    }
                    else
                    {
                        _toSemester = int.Parse(ddlToSemester.SelectedValue);
                    }

                    if (new BOStudentRegistration().SavePromoteStudents(_studentId, _toClass, _toSemester))
                    {
                        //string script = @"document.getElementById('" + divStatus.ClientID + "').innerHTML='Record updated';var elem = document.createElement('img');elem.setAttribute('src', 'tick.jpg');document.getElementById('" + divStatus.ClientID + "').appendChild(elem);document.getElementById('" + divStatus.ClientID + "').style.color = 'Green';document.getElementById('" + divStatus.ClientID + "').style.fontSize = '1em' ;document.getElementById('" + divStatus.ClientID + "').style.fontWeight = 'bold' ;setTimeout(function(){document.getElementById('" + divStatus.ClientID + "').style.display='none';},4500);";
                        //ScriptManager.RegisterStartupScript(this, this.GetType(), "script", script, true);
                        string alertScript = "jAlert('Students Promoted Successfully', 'Campus2Caretaker');";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertScript", alertScript, true);
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
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            clear();
        }

        protected void btnGetStudents_Click(object sender, EventArgs e)
        {
            int _branchId = int.Parse(ddlFromClass.SelectedValue);
            int _semesterId = 0;
            if (Session["InstituteType"].ToString() == "S")
            {
                _semesterId = 0;
            }
            else
            {
                _semesterId = int.Parse(ddlFromSemester.SelectedValue);
            }
            int _instituteId = int.Parse(Session["InstituteID"].ToString());
            ViewState["CurrentTable"] = null;
            SetInitialRow();
            AddRowsToGrid(new BOStudentRegistration().GetStudentsListPromotion(_instituteId, _semesterId, _branchId));
        }

        protected void gvPromoteStudents_DataBound(object sender, EventArgs e)
        {

        }
    }
}