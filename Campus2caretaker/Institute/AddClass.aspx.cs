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
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;

namespace Campus2caretaker.Institute
{
    public partial class AddClass : System.Web.UI.Page
    {
        private String m_strSortExp;
        private SortDirection m_SortDirection = SortDirection.Ascending;

        protected void Page_Load(object sender, EventArgs e)
        {
            gvClasses.Columns[0].HeaderText = HttpContext.Current.Session["InstituteType"].ToString() == "S" ? "Class Id" : "Branch Id";
            gvClasses.Columns[1].HeaderText = HttpContext.Current.Session["InstituteType"].ToString() == "S" ? "Class Name" : "Branch Name";

            if (!IsPostBack)
            {
                Response.Cache.SetNoStore();
                m_strSortExp = String.Empty;

                clear();
                RefreshGridView();

                btnAddClass.Text = HttpContext.Current.Session["InstituteType"].ToString() == "S" ? "Add Class" : "Add Branch";
                btnRemoveClass.Text = HttpContext.Current.Session["InstituteType"].ToString() == "S" ? "Remove Class" : "Remove Branch";
            }

           
            if (null != ViewState["_SortExp_"])
            {
                m_strSortExp = ViewState["_SortExp_"] as String;
            }

            if (null != ViewState["_Direction_"])
            {
                m_SortDirection = (SortDirection)ViewState["_Direction_"];
            }

            lnkpdfdownload.ServerClick += new EventHandler(lnkpdfdownload_Click);
            lnkexceldownload.ServerClick += new EventHandler(lnkexceldownload_Click);

        }

        private void lnkexceldownload_Click(object sender, EventArgs e)
        {
            gvClasses.AllowPaging = false;
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
            HttpContext.Current.Response.AddHeader("content-disposition", String.Format("attachment;filename={0}.xls", String.Concat("ClassDetails", DateTime.Now.Ticks)));
            gvClasses.GridLines = GridLines.Both;
            gvClasses.HeaderStyle.Font.Bold = true;
            gvClasses.RenderControl(htmltextwrtter);
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
                    //To Export all pages
                    gvClasses.AllowPaging = false;
                    this.RefreshGridView();

                    gvClasses.RenderControl(hw);
                    StringReader sr = new StringReader(sw.ToString());
                    Document pdfDoc = new Document(PageSize.A4, 5f, 5f, 5f, 0f);
                    HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                    PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                    pdfDoc.Open();
                    htmlparser.Parse(sr);
                    pdfDoc.Close();

                    Response.ContentType = "application/pdf";
                    Response.AddHeader("content-disposition", String.Format("attachment;filename={0}.pdf", String.Concat("ClassDetails", DateTime.Now.Ticks)));
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    Response.Write(pdfDoc);
                    Response.End();
                }
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

        void AddSortImage(GridViewRow headerRow)
        {
            Int32 iCol = GetSortColumnIndex(m_strSortExp);
            if (-1 == iCol)
            {
                return;
            }
            // Create the sorting image based on the sort direction.
            System.Web.UI.WebControls.Image sortImage = new System.Web.UI.WebControls.Image();
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
            if (Page.IsValid)
            {
                try
                {
                    DTOPersonalizeApplication tOPApplication = new DTOPersonalizeApplication();
                    tOPApplication.InstituteId = int.Parse(Session["InstituteID"].ToString());
                    tOPApplication.Classes = lstClasses.Items.Cast<System.Web.UI.WebControls.ListItem>().Select(x => x.Value).ToArray();

                    if (new BOPersonalizeApplication().SaveClasses(tOPApplication))
                    {
                        string script = @"document.getElementById('" + divStatus.ClientID + "').innerHTML='Record inserted';var elem = document.createElement('img');elem.setAttribute('src', 'tick.jpg');document.getElementById('" + divStatus.ClientID + "').appendChild(elem);document.getElementById('" + divStatus.ClientID + "').style.color = 'Green';document.getElementById('" + divStatus.ClientID + "').style.fontSize = '1em' ;document.getElementById('" + divStatus.ClientID + "').style.fontWeight = 'bold' ;setTimeout(function(){document.getElementById('" + divStatus.ClientID + "').style.display='none';},4500);";
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

        protected void gvClasses_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvClasses.PageIndex = e.NewPageIndex;
            RefreshGridView();
        }

    }
}