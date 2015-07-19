using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessObjects;
using DataTransferObject;

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
            }
            RefreshGridView();
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
                trSemester.Visible = false;
                trSemesterLineBreak.Visible = false;
            }
            else
            {
                trSemester.Visible = true;
                trSemesterLineBreak.Visible = true;
            }
        }

        private void clear()
        {
            //Clears all the fields and gets the form to initial state

            ddlClass.Items.Clear();
            ddlClass.SelectedIndex = 0;
            ddlSemester.SelectedIndex = 0;
            txtDOB.Text = "";
            txtFatherName.Text = "";
            txtMotherName.Text = "";
            txtParentsContactNumber.Text = "";
            txtRollNo.Text = "";
            txtStudentAddress.Text = "";
            txtStudentName.Text = "";

            RefreshClasses();

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

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {

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
            gvStudents.DataSource = dt;
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
    }
}