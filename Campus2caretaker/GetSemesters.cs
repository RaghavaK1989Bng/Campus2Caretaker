using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Campus2caretaker
{
    public class GetSemesters
    {
        public static List<ListItem> GetSemester(string instituteType)
        {
            List<ListItem> retList = new List<ListItem>();
            int count  = 0;
            if(instituteType == "C")
            {
                count = 2;
            }
            else if (instituteType == "D")
            {
                count = 6;
            }
            else if (instituteType == "E")
            {
                count = 8;
            }

            for(int i=1;i <= count;i++)
            {
                ListItem item = new ListItem();
                item.Text = i.ToString();
                item.Value  = i.ToString();
                retList.Add(item);
            }

            return retList;
        }
    }
}