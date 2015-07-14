using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessObjects;
using DataTransferObject;
using System.Data;

namespace Campus2caretaker
{
    public partial class AddNewInstitute : System.Web.UI.Page
    {
        private String m_strSortExp;
        private SortDirection m_SortDirection = SortDirection.Ascending;
        private string logobytes = "";
        public string filename = "";
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
        }

        int GetSortColumnIndex(String strCol)
        {
            foreach (DataControlField field in gvInstitutes.Columns)
            {
                if (field.SortExpression == strCol)
                {
                    return gvInstitutes.Columns.IndexOf(field);
                }
            }

            return -1;
        }

        private void clear()
        {
            //Clears all the fields and gets the form to initial state

            ddlInstituteType.SelectedIndex = 0;
            txtInstituteAddress.Text = "";
            txtInstituteEmail.Text = "";
            txtInstituteName.Text = "";
            txtInstitutePhoneNumber.Text = "";
            txtPrincipalContactNumber.Text = "";
            txtPrincipalName.Text = "";
            imgInstituteLogo.Src = null;
            txtDistrict.Text = "";
            txtState.Text = "";

            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            txtInstituteEmail.Enabled = true;
        }

        private void RefreshGridView()
        {
            dsGridview.DataBind();
            gvInstitutes.DataBind();
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (FileUpPhoto.HasFile)
            {
                int FileSize = FileUpPhoto.PostedFile.ContentLength;
                byte[] bytFileBinary = new byte[FileSize];
                FileUpPhoto.PostedFile.InputStream.Read(bytFileBinary, 0, (int)FileUpPhoto.PostedFile.ContentLength);
                imgInstituteLogo.Src = "data:image/png;base64," + Convert.ToBase64String(bytFileBinary);
                logobytes = imgInstituteLogo.Src;

                filename = Guid.NewGuid().ToString().Substring(0, 15);
                filename += System.IO.Path.GetExtension(FileUpPhoto.FileName);
                FileUpPhoto.SaveAs(Server.MapPath("~/uploaded/").Replace("\\", "/") + filename);
                Session["LogoPhoto"] = filename;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            //to Save a new employee to the db and updates it to the below gridview

            if (Page.IsValid)
            {
                try
                {
                    DTOInstituteDetails toinst = new DTOInstituteDetails();
                    toinst.InstituteName = txtInstituteName.Text;
                    toinst.InstituteEmail = txtInstituteEmail.Text;

                    if (new BOInstituteDetails().IsInstituteNameExists(toinst) || new BOInstituteDetails().IsInstituteEmailExists(toinst))
                    {
                        string script = @"document.getElementById('" + divStatus.ClientID + "').innerHTML='Institute already exists!!';var elem = document.createElement('img');elem.setAttribute('src', 'cross.jpg');document.getElementById('" + divStatus.ClientID + "').appendChild(elem);document.getElementById('" + divStatus.ClientID + "').style.color = 'Red';document.getElementById('" + divStatus.ClientID + "').style.fontSize = '1em' ;document.getElementById('" + divStatus.ClientID + "').style.fontWeight = 'bold' ;setTimeout(function(){document.getElementById('" + divStatus.ClientID + "').style.display='none';},4500);";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "script", script, true);
                        return;
                    }

                    if (imgInstituteLogo.Src != null)
                    {
                        toinst.LogoPath = Session["LogoPhoto"].ToString();
                    }
                    toinst.InstituteAddress = txtInstituteAddress.Text;
                    toinst.InstitutePhoneNo = txtInstitutePhoneNumber.Text;
                    toinst.InstituteType = ddlInstituteType.SelectedValue;
                    toinst.PrincipalContact = txtPrincipalContactNumber.Text;
                    toinst.PrincipalName = txtPrincipalName.Text;
                    toinst.State = txtState.Text;
                    toinst.District = txtDistrict.Text;

                    RandomStringGenerator randstring = new RandomStringGenerator();
                    string DefaultPwd = randstring.Generate(8);
                    toinst.InstituteDefaultPwd = PasswordEncDec.EncodePasswordToBase64(DefaultPwd);
                    toinst.InstituteUserType = "Usr";

                    if (new BOInstituteDetails().InsertInstituteDetails(toinst))
                    {
                        string script = @"document.getElementById('" + divStatus.ClientID + "').innerHTML='Record inserted';var elem = document.createElement('img');elem.setAttribute('src', 'tick.jpg');document.getElementById('" + divStatus.ClientID + "').appendChild(elem);document.getElementById('" + divStatus.ClientID + "').style.color = 'Green';document.getElementById('" + divStatus.ClientID + "').style.fontSize = '1em' ;document.getElementById('" + divStatus.ClientID + "').style.fontWeight = 'bold' ;setTimeout(function(){document.getElementById('" + divStatus.ClientID + "').style.display='none';},4500);";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "script", script, true);

                        #region E-Mail

                        //Send mail

                        string s_subject = "Institute Account Details From Campus2Caretaker";
                        string s_msg = "Hi," + Environment.NewLine + Environment.NewLine;
                        //s_msg += "You have been shared with some documents." + Environment.NewLine;
                        s_msg += "Please use the below details for managing your institute account in Campus2Caretaker." + Environment.NewLine + Environment.NewLine;


                        string s_link = "http://" + Request.ServerVariables["SERVER_NAME"] + ":" + Request.ServerVariables["SERVER_PORT"] + "/Institute/InstituteLogin.aspx";
                        s_msg += s_link + Environment.NewLine + Environment.NewLine;
                        s_msg += "Username and Password to Login to account is" + Environment.NewLine + Environment.NewLine;
                        s_msg += "Username :" + string.Empty + toinst.InstituteEmail + Environment.NewLine + Environment.NewLine;
                        s_msg += "Password :" + string.Empty + DefaultPwd + Environment.NewLine + Environment.NewLine + Environment.NewLine;


                        s_msg += "Thank You" + Environment.NewLine;

                        bool res = C2CEmail.SendC2CMail(s_msg, s_subject, string.Empty, toinst.InstituteEmail, null, null);

                        #endregion

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

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    DTOInstituteDetails toinst = new DTOInstituteDetails();
                    toinst.InstituteID = int.Parse(gvInstitutes.SelectedDataKey.Value.ToString());
                    toinst.InstituteName = txtInstituteName.Text;
                    toinst.InstituteEmail = txtInstituteEmail.Text;

                    if (imgInstituteLogo.Src != null)
                    {
                        toinst.LogoPath = Session["LogoPhoto"].ToString();
                    }

                    toinst.InstituteAddress = txtInstituteAddress.Text;
                    toinst.InstitutePhoneNo = txtInstitutePhoneNumber.Text;
                    toinst.InstituteType = ddlInstituteType.SelectedValue;
                    toinst.PrincipalContact = txtPrincipalContactNumber.Text;
                    toinst.PrincipalName = txtPrincipalName.Text;
                    toinst.State = txtState.Text;
                    toinst.District = txtDistrict.Text;

                    if (new BOInstituteDetails().UpdateInstituteDetails(toinst))
                    {
                        string script = @"document.getElementById('" + divStatus.ClientID + "').innerHTML='Record updated';var elem = document.createElement('img');elem.setAttribute('src', 'tick.jpg');document.getElementById('" + divStatus.ClientID + "').appendChild(elem);document.getElementById('" + divStatus.ClientID + "').style.color = 'Green';document.getElementById('" + divStatus.ClientID + "').style.fontSize = '1em' ;document.getElementById('" + divStatus.ClientID + "').style.fontWeight = 'bold' ;setTimeout(function(){document.getElementById('" + divStatus.ClientID + "').style.display='none';},4500);";
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

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    DTOInstituteDetails toins = new DTOInstituteDetails();
                    toins.InstituteID = int.Parse(gvInstitutes.SelectedDataKey.Value.ToString()); ;

                    if (new BOInstituteDetails().DeleteInstituteDetails(toins))
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

        protected void gvInstitutes_SelectedIndexChanged(object sender, EventArgs e)
        {
            DTOInstituteDetails toins = new DTOInstituteDetails();
            toins.InstituteID = int.Parse(gvInstitutes.SelectedDataKey.Value.ToString());
            txtInstituteEmail.Enabled = false;
            btnSave.Enabled = false;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
            DataTable dt = new DataTable();
            dt = new BOInstituteDetails().GetInstituteDetails(toins);
            try
            {
                txtInstituteName.Text = dt.Rows[0][0].ToString();
                txtInstituteEmail.Text = dt.Rows[0][7].ToString();
                Session["LogoPhoto"] = dt.Rows[0][3].ToString();
                imgInstituteLogo.Src = "~/uploaded/" + Session["LogoPhoto"].ToString();
                txtInstituteAddress.Text = dt.Rows[0][1].ToString();
                txtInstitutePhoneNumber.Text = dt.Rows[0][2].ToString();
                txtState.Text = dt.Rows[0][9].ToString();
                txtDistrict.Text = dt.Rows[0][8].ToString();
                
                if (dt.Rows[0][6].ToString().Equals("S"))
                {
                    ddlInstituteType.SelectedIndex = 1;
                }
                else if (dt.Rows[0][6].ToString().Equals("C"))
                {
                    ddlInstituteType.SelectedIndex = 2;
                }
                else if (dt.Rows[0][6].ToString().Equals("D"))
                {
                    ddlInstituteType.SelectedIndex = 3;
                }
                txtPrincipalContactNumber.Text = dt.Rows[0][5].ToString();
                txtPrincipalName.Text = dt.Rows[0][4].ToString();
            }
            catch
            {

            }
        }

        protected void gvInstitutes_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";
                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.gvInstitutes, "Select$" + e.Row.RowIndex);
            }
        }

        protected void gvInstitutes_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                if (String.Empty != m_strSortExp)
                {
                    AddSortImage(e.Row);
                }
            }
        }

        protected void gvInstitutes_Sorting(object sender, GridViewSortEventArgs e)
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