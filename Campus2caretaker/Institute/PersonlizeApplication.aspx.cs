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
    public partial class PersonlizeApplication : System.Web.UI.Page
    {
        private String m_strSortExp;
        private SortDirection m_SortDirection = SortDirection.Ascending;

        private String m_strSortExp_;
        private SortDirection m_SortDirection_ = SortDirection.Ascending;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Response.Cache.SetNoStore();
                m_strSortExp = String.Empty;
                m_strSortExp_ = String.Empty;

                clear();
                clearSubjects();
                RefreshClasses();

                RefreshGridView();
                RefreshGridView_();
            }
            if (null != ViewState["_SortExp_"])
            {
                m_strSortExp = ViewState["_SortExp_"] as String;
            }

            if (null != ViewState["_Direction_"])
            {
                m_SortDirection = (SortDirection)ViewState["_Direction_"];
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
                trSemester.Visible = false;
                trSemesterLineBreak.Visible = false;
            }
            else
            {
                trSemester.Visible = true;
                trSemesterLineBreak.Visible = true;
            }
        }


        int GetSortColumnIndex(String strCol)
        {
            foreach (DataControlField field in gvClasses.Columns)
            {
                if (field.SortExpression == strCol)
                {
                    return gvClasses.Columns.IndexOf(field);
                }
            }

            return -1;
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

        private void RefreshGridView()
        {
            DataTable dt = new BOPersonalizeApplication().GetClassesList(Session["InstituteID"].ToString());

            string strSort = String.Empty;
            if (ViewState.Keys.Count > 0)
            {
                strSort = String.Format("{0} {1}", m_strSortExp, (m_SortDirection == SortDirection.Descending) ? "DESC" : "ASC");
                dt.DefaultView.Sort = strSort;
            }
            DataView dv = new DataView(dt, String.Empty, strSort, DataViewRowState.CurrentRows);

            gvClasses.DataSource = dv;
            gvClasses.DataBind();
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

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    DTOPersonalizeApplication tOPApplication = new DTOPersonalizeApplication();
                    tOPApplication.InstituteId = int.Parse(Session["InstituteID"].ToString());
                    tOPApplication.Classes = lstClasses.Items.Cast<ListItem>().Select(x => x.Value).ToArray();

                    if (new BOPersonalizeApplication().SaveClasses(tOPApplication))
                    {
                        string script = @"document.getElementById('" + divStatus.ClientID + "').innerHTML='Record inserted';var elem = document.createElement('img');elem.setAttribute('src', 'tick.jpg');document.getElementById('" + divStatus.ClientID + "').appendChild(elem);document.getElementById('" + divStatus.ClientID + "').style.color = 'Green';document.getElementById('" + divStatus.ClientID + "').style.fontSize = '1em' ;document.getElementById('" + divStatus.ClientID + "').style.fontWeight = 'bold' ;setTimeout(function(){document.getElementById('" + divStatus.ClientID + "').style.display='none';},4500);";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "script", script, true);

                        RefreshGridView();
                        clear();
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

        protected void btnClear_Click(object sender, EventArgs e)
        {
            clear();
        }


        protected void gvClasses_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                if (String.Empty != m_strSortExp)
                {
                    AddSortImage(e.Row);
                }
            }
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

        protected void gvClasses_Sorting(object sender, GridViewSortEventArgs e)
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

        protected void btnRemoveClass_Click(object sender, EventArgs e)
        {
            if (lstClasses.SelectedIndex > -1)
            {
                lstClasses.Items.Remove(lstClasses.SelectedItem);
            }
        }

        protected void btnAddClass_Click(object sender, EventArgs e)
        {
            lstClasses.Items.Add(txtClassName.Text);
        }

        private void clear()
        {
            txtClassName.Text = "";
            lstClasses.Items.Clear();
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
    }
}