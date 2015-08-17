using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataTransferObject;
using BusinessObjects;

namespace Campus2caretaker.Institute
{
    public partial class AddSubjects : System.Web.UI.Page
    {
        private String m_strSortExp_;
        private SortDirection m_SortDirection_ = SortDirection.Ascending;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Response.Cache.SetNoStore();
                m_strSortExp_ = String.Empty;

                clearSubjects();
                RefreshClasses();

                RefreshGridView_();
            }

            if (null != ViewState["_SortExp__"])
            {
                m_strSortExp_ = ViewState["_SortExp__"] as String;
            }

            if (null != ViewState["_Direction__"])
            {
                m_SortDirection_ = (SortDirection)ViewState["_Direction__"];
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
                validator.ValidationGroup = "Subject";
                validator.ForeColor = System.Drawing.Color.Red;
                validator.InitialValue = "Select";
                validator.ToolTip = "Semester Selection is required.";

                this.Form.FindControl("ContentPlaceHolder1").Controls.Add(validator);
            }
        }


        int GetSortColumnIndex_(String strCol)
        {
            foreach (DataControlField field in gvSubjects.Columns)
            {
                if (field.SortExpression == strCol)
                {
                    return gvSubjects.Columns.IndexOf(field);
                }
            }

            return -1;
        }

        private void RefreshGridView_()
        {
            DataTable dt = new BOPersonalizeApplication().GetSubjectsList(Session["InstituteID"].ToString());

            string strSort = String.Empty;
            if (ViewState.Keys.Count > 0)
            {
                strSort = String.Format("{0} {1}", m_strSortExp_, (m_SortDirection_ == SortDirection.Descending) ? "DESC" : "ASC");
                dt.DefaultView.Sort = strSort;
            }
            DataView dv = new DataView(dt, String.Empty, strSort, DataViewRowState.CurrentRows);

            gvSubjects.DataSource = dv;
            gvSubjects.DataBind();
        }

        void AddSortImage_(GridViewRow headerRow)
        {
            Int32 iCol = GetSortColumnIndex_(m_strSortExp_);
            if (-1 == iCol)
            {
                return;
            }
            // Create the sorting image based on the sort direction.
            Image sortImage = new Image();
            if (SortDirection.Ascending == m_SortDirection_)
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

        protected void gvSubjects_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                if (String.Empty != m_strSortExp_)
                {
                    AddSortImage_(e.Row);
                }
            }
        }

        protected void gvSubjects_Sorting(object sender, GridViewSortEventArgs e)
        {
            // There seems to be a bug in GridView sorting implementation. Value of
            // SortDirection is always set to "Ascending". Now we will have to play
            // little trick here to switch the direction ourselves.
            if (String.Empty != m_strSortExp_)
            {
                if (String.Compare(e.SortExpression, m_strSortExp_, true) == 0)
                {
                    m_SortDirection_ =
                        (m_SortDirection_ == SortDirection.Ascending) ? SortDirection.Descending : SortDirection.Ascending;
                }
            }
            ViewState["_Direction__"] = m_SortDirection_;
            ViewState["_SortExp__"] = m_strSortExp_ = e.SortExpression;
            this.RefreshGridView_();
        }

        private void clearSubjects()
        {
            RefreshClasses();
            txtSubjectName.Text = "";
            lstSubjectsLab.Items.Clear();
            lstSubjectsTheory.Items.Clear();
        }

        private void RefreshClasses()
        {
            dsClasses.DataBind();
            ddlClass.DataBind();

            ddlClass.Items.Insert(0, "Select");

            ddlClass.SelectedIndex = 0;
        }

        protected void btnSaveSubjects_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    DTOPersonalizeApplication tOPApplication = new DTOPersonalizeApplication();
                    tOPApplication.InstituteId = int.Parse(Session["InstituteID"].ToString());
                    tOPApplication.TheorySubjects = lstSubjectsTheory.Items.Cast<ListItem>().Select(x => x.Value).ToArray();
                    tOPApplication.LabSubjects = lstSubjectsLab.Items.Cast<ListItem>().Select(x => x.Value).ToArray();
                    tOPApplication.ClassId = int.Parse(ddlClass.SelectedValue.ToString());
                    if (Session["InstituteType"].ToString() == "S")
                    {
                        tOPApplication.Semester = "0";
                    }
                    else
                    {
                        tOPApplication.Semester = ddlSemester.SelectedValue.ToString();
                    }

                    if (new BOPersonalizeApplication().SaveSubjects(tOPApplication))
                    {
                        string script = @"document.getElementById('" + divStatus.ClientID + "').innerHTML='Record inserted';var elem = document.createElement('img');elem.setAttribute('src', 'tick.jpg');document.getElementById('" + divStatus.ClientID + "').appendChild(elem);document.getElementById('" + divStatus.ClientID + "').style.color = 'Green';document.getElementById('" + divStatus.ClientID + "').style.fontSize = '1em' ;document.getElementById('" + divStatus.ClientID + "').style.fontWeight = 'bold' ;setTimeout(function(){document.getElementById('" + divStatus.ClientID + "').style.display='none';},4500);";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "script", script, true);

                        RefreshGridView_();
                        clearSubjects();
                        RefreshClasses();
                    }
                    else
                    {
                        string script = @"document.getElementById('" + divStatus.ClientID + "').innerHTML='Error';var elem = document.createElement('img');elem.setAttribute('src', 'cross.jpg');document.getElementById('" + divStatus.ClientID + "').appendChild(elem);document.getElementById('" + divStatus.ClientID + "').style.color = 'Red';document.getElementById('" + divStatus.ClientID + "').style.fontSize = '1em' ;document.getElementById('" + divStatus.ClientID + "').style.fontWeight = 'bold' ;setTimeout(function(){document.getElementById('" + divStatus.ClientID + "').style.display='none';},4500);";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "script", script, true);
                    }
                }
                catch
                {

                }
            }
        }

        protected void btnClearSubjects_Click(object sender, EventArgs e)
        {
            clearSubjects();
            RefreshClasses();
        }

        protected void btnAddSubjectLab_Click(object sender, EventArgs e)
        {
            lstSubjectsLab.Items.Add(txtSubjectName.Text);

        }

        protected void btnAddSubjectTheory_Click(object sender, EventArgs e)
        {
            lstSubjectsTheory.Items.Add(txtSubjectName.Text);
        }

        protected void btnRemoveSubject_Click(object sender, EventArgs e)
        {
            if (lstSubjectsTheory.SelectedIndex > -1)
            {
                lstSubjectsTheory.Items.Remove(txtSubjectName.Text);
            }
        }

        protected void gvSubjects_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvSubjects.PageIndex = e.NewPageIndex;
            RefreshGridView_();
        }
    }
}