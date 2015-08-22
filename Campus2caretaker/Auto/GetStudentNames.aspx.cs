using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Campus2caretaker.Auto
{
    public partial class GetStudentNames : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            string reqString = "";
            if (Request["startsWith"] != null || Request["startsWith"] != String.Empty)
            {
                reqString = Request["startsWith"];
            }
            //if (Request["locationId"] != null || Request["locationId"] != String.Empty)
            //{
            //    locId = Convert.ToInt32(Request["locationId"]);
            //}
            List<StudentNames> StudentNamesList = null;

            StudentNamesList = (from i in new BOStudentRegistration().GetAutoCompleteStudentNames(reqString)
                                      select new StudentNames
                                 {
                                     value = i.StudentName,
                                     id  = i.StudentId
                                 }).ToList();

            string json = serializer.Serialize(StudentNamesList);
            Response.Clear();
            Response.ContentType = "application/json; charset=utf-8";
            Response.Write(json);
            Response.End();
        }
    }

    class StudentNames
    {
        public string value { get; set; }
        public int id { get; set; }
    }
}