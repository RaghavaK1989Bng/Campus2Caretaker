using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace Campus2caretaker
{
    public class C2CEmail
    {
        string _body;
        string _subject;
        string _from;
        string _to;
        Attachment _attachment = null;


        public C2CEmail(string body, string subject, string from, string to, MemoryStream pdfstream, string fname)
        {
            _body = body;   //parsetemplate(body,argumentlist);
            _subject = subject;

            _from = from;
            _to = to;
            if(pdfstream != null)
              _attachment =   new Attachment(pdfstream, fname);;
             

        }        
        
        public void SendC2CMail()
        {
            MailMessage mm = new MailMessage(_from, _to);
            mm.Body = _body;
            mm.Subject = _subject;
            mm.IsBodyHtml = true;
             if(_attachment != null)
            mm.Attachments.Add(_attachment);

            SmtpClient SMTPServer = GetSMTPServer();
            try
            {     
                SMTPServer.Send(mm);                
            }
         
            catch
            { 
              // send to mailqueue
            }
        }

        public static bool SendC2CMail(string _body, string _subject, string _from, string _to, MemoryStream _pdfstream, string _fname)
        {
            try
            {
                MailMessage msg = new MailMessage();
                if (string.IsNullOrEmpty(_from)) _from = "c2cmailer@gmail.com";
                msg.From = new MailAddress(_from);
                msg.To.Add(_to);
                msg.IsBodyHtml = true;
                msg.Body = Regex.Replace(_body, Environment.NewLine, "<br/>");
                msg.Subject = _subject;

                var client = new SmtpClient("smtp.gmail.com", 587)
                {
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential("c2cmailer@gmail.com", "uytredfgh@King55"),
                    EnableSsl = true
                };
                StringBuilder sbBody = new StringBuilder();

                //System.IO.MemoryStream imgContent = new System.IO.MemoryStream();
                //CCDaemon.Properties.Resources.CC_Logo.Save(imgContent, System.Drawing.Imaging.ImageFormat.Png);
                //System.IO.File.AppendAllText(@"E:\sam.txt", "adding FILE " + DateTime.Now.ToString() + Environment.NewLine);            

                var inlineLogo = new LinkedResource(HttpContext.Current.Server.MapPath(@"..\images\newlogo.png"));
                inlineLogo.ContentId = Guid.NewGuid().ToString();

                sbBody.Append(string.Format("<img src='cid:{0}' /><br/><br/>", inlineLogo.ContentId));
                sbBody.Append(msg.Body);
                sbBody.AppendLine("<br/>");
                sbBody.AppendLine("*****************************DISCLAIMER*****************************");
                sbBody.AppendLine("<br/>");
                sbBody.AppendLine("Some copy right information here...");

                var view = AlternateView.CreateAlternateViewFromString(sbBody.ToString(), null, "text/html");
                view.LinkedResources.Add(inlineLogo);
                msg.AlternateViews.Add(view);

                //System.IO.File.AppendAllText(@"E:\sam.txt", "READY FOR SENDING " + DateTime.Now.ToString() + Environment.NewLine);            

                client.Send(msg);
            }
            catch {
                return false;
            }
            return true;
        }

        /* these data/credentials can be read from a table in database */
        protected SmtpClient GetSMTPServer()
        {
            //string userName = "donotreply@cloudsorcerers.com";
            //string password = "MClouMNS2012";
            //SmtpClient SMTPServer = new SmtpClient("smtpout.secureserver.net", 80);

            string userName = "c2cmailer@gmail.com";
            string password = "mailer@123";
            SmtpClient SMTPServer = new SmtpClient("smtp.gmail.com", 587);
            SMTPServer.EnableSsl = true;

            SMTPServer.Credentials = new System.Net.NetworkCredential(userName, password);
            return SMTPServer;
        }
    }
}