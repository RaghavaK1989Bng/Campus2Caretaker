using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Campus2caretaker.Institute
{
    public partial class PersonlizeApplicationSchool : System.Web.UI.Page
    {
        private String m_strSortExp;
        private SortDirection m_SortDirection = SortDirection.Ascending;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Response.Cache.SetNoStore();
                m_strSortExp = String.Empty;
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

        private void RefreshGridView()
        {
            DataTable dt = new BOPersonalizeApplication().GetClassesList(Session["InstituteID"].ToString());
            gvClasses.DataSource = dt;
            gvClasses.DataBind();
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

        protected void btnSave_Click(object sender, EventArgs e)
        {

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {

        }

        protected void btnClear_Click(object sender, EventArgs e)
        {

        }

        protected void gvClasses_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void gvClasses_RowDataBound(object sender, GridViewRowEventArgs e)
        {

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
    }
}