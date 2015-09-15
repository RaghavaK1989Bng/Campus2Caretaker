using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Configuration;

namespace Campus2caretaker
{
    public static class C2CSMS
    {
        public static bool SendSMS(string Message, string MobileNo)
        {
            try
            {
                //string userName = WebConfigurationManager.AppSettings["SMSUserName"];
                //string password = WebConfigurationManager.AppSettings["SMSPassWord"];
                //HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://www.smsintegra.com/smsweb/desktop_sms/desktopsms.asp?uid="+userName+"&pwd="+password+"&mobile="+ MobileNo +"&msg="+ Message +"&sid=raghavak1989&dtNow='" + System.DateTime.Now.ToString() + "'");
                //HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                //Stream responseStream = response.GetResponseStream();
                //StreamReader readStream = new StreamReader(responseStream, Encoding.UTF8);
                //string strSMSResponseString = readStream.ReadToEnd();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}