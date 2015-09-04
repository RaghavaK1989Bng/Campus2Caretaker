using BusinessObjects;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Campus2caretaker.Institute
{
    public partial class GenerateMonthlyReport : System.Web.UI.Page
    {
        string ckuser, ckpass;
        private HttpWebRequest req;
        private CookieContainer cookieCntr;
        private string strNewValue;
        public static string responseee;
        private HttpWebResponse response;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Response.Cache.SetNoStore();
                clear();            
            }
        }

        private void clear()
        {
            System.Web.UI.WebControls.ListItem selectItem = new System.Web.UI.WebControls.ListItem();
            selectItem.Text = "Select";
            selectItem.Value = "Select";
            ddlMonth.Items.Insert(0, selectItem);
            ddlYear.Items.Insert(0, selectItem);

            ddlMonth.SelectedIndex = 0;
            ddlYear.SelectedIndex = 0;
        }

        protected void btnGenerateReport_Click(object sender, EventArgs e)
        {
            // create PDF template
            MemoryStream m = CreatePDF();

            // send pdf to the browser
            Response.Clear();
            Response.ClearContent();
            Response.ClearHeaders();
            Response.ContentType = "application/pdf";
            Response.AppendHeader("Content-Disposition", "attachment;filename=monthly_report.pdf");
            Response.OutputStream.Write(m.GetBuffer(), 0, m.GetBuffer().Length);
            Response.OutputStream.Flush();
            Response.OutputStream.Close();
            Response.End();
        }

        private MemoryStream CreatePDF()
        {
            WebRequest myrequest;
            WebResponse myresponse;
            StreamReader sr;
            string strHTML;


            MemoryStream ms = new MemoryStream();
            using (Document document = new Document(PageSize.A4, 50, 50, 50, 50))
            {
                using (PdfWriter w = PdfWriter.GetInstance(document, ms))
                {
                    try
                    {
                        myrequest = WebRequest.Create(String.Format("http://" + Request.ServerVariables["SERVER_NAME"] + ":" + Request.ServerVariables["SERVER_PORT"] +"/Institute/ReportPrint.aspx?strMonth={0}&strYear={1}&strInstitute={2}", ddlMonth.SelectedValue, ddlYear.SelectedValue, Session["InstituteID"].ToString()));
                        myresponse = myrequest.GetResponse();

                        sr = new StreamReader(myresponse.GetResponseStream());
                        strHTML = sr.ReadToEnd();
                        var styles = new iTextSharp.text.html.simpleparser.StyleSheet();
                        using (StringReader strread = new StringReader(strHTML))
                        {
                            List<IElement> elements = HTMLWorker.ParseToList(strread, styles);
                            document.Open();
                            w.PageEvent = new Border();
                            foreach (IElement el in elements)
                            {
                                document.Add(el);
                            }

                        }
                        document.Close();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }


                    sr.Close();
                }
            }
            return ms;
        }

        public partial class Border : PdfPageEventHelper
        {
            public override void OnEndPage(PdfWriter writer, Document document)
            {
                base.OnEndPage(writer, document);

                var content = writer.DirectContent;
                var pageBorderRect = new Rectangle(document.PageSize);

                pageBorderRect.Left += document.LeftMargin - 10;
                pageBorderRect.Right -= document.RightMargin - 10;
                pageBorderRect.Top -= document.TopMargin - 10;
                pageBorderRect.Bottom += document.BottomMargin - 10;

                content.SetColorStroke(BaseColor.GRAY);
                content.Rectangle(pageBorderRect.Left, pageBorderRect.Bottom, pageBorderRect.Width, pageBorderRect.Height);
                content.Stroke();
            }
        }
    }
}