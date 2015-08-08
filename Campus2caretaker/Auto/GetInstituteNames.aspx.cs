using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessObjects;
using DataTransferObject;

namespace Campus2caretaker.Auto
{
    public partial class GetInstituteNames : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            string reqString = "";
            int locId = 0;
            if (Request["startsWith"] != null || Request["startsWith"] != String.Empty)
            {
                reqString = Request["startsWith"];
            }
            if (Request["locationId"] != null || Request["locationId"] != String.Empty)
            {
                locId = Convert.ToInt32(Request["locationId"]);
            }
            List<InstituteName> InstituteNameList = null;

            InstituteNameList = (from i in new BOInstituteDetails().GetAutoCompleteInstitutes(reqString)
                                 select new InstituteName
                                {
                                    value = i.InstituteName,
                                    id = i.InstituteID
                                }).ToList();
            
            string json = serializer.Serialize(InstituteNameList);
            Response.Clear();
            Response.ContentType = "application/json; charset=utf-8";
            Response.Write(json);
            Response.End();
        }
    }

    class InstituteName
    {
        public int id { get; set; }
        public string value { get; set; }
    }
}