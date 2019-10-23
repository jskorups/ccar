using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Mail;
using System.Web.Configuration;
using System.Net.Configuration;
using System.Runtime.InteropServices;
using Outlook = Microsoft.Office.Interop.Outlook;
using Microsoft.Office.Core;

namespace ccar
{
    public class emailClass
    {

        public static void CreateMailItem(string to, string body, string subject)
        {
            try
            {
                //MailMessage mail = new MailMessage();
                //SmtpClient smtpserver = new SmtpClient("172.25.120.139", 25);

                //smtpserver.UseDefaultCredentials = false;
                //mail.From = new MailAddress("ccar@system.com");
                //mail.To.Add(to);
                //mail.Subject = subject;
                //mail.Body = body;
                //mail.Priority = MailPriority.High;
                //smtpserver.EnableSsl = false;
                //smtpserver.Timeout = 60000;
                //smtpserver.Send(mail);



                System.Configuration.Configuration config = WebConfigurationManager.OpenWebConfiguration(
                  HttpContext.Current.Request.ApplicationPath);
                MailSettingsSectionGroup settings =
                    (MailSettingsSectionGroup)config.GetSectionGroup("system.net/mailSettings");

                SmtpClient client = new SmtpClient();
                client.Credentials = new NetworkCredential(settings.Smtp.Network.UserName, settings.Smtp.Network.Password);
                MailMessage msg = new MailMessage();
                msg.Body = body;
                msg.IsBodyHtml = true;
                msg.Subject = subject;
                msg.From = new MailAddress("kowalski.jan567890@gmail.com");

                msg.To.Add("kowalski.jan567890@gmail.com");

                msg.To.Add(to);

                client.Send(msg);



            }
            catch (Exception exp)
            {
                Console.Write(exp.Message);

            }

            #region
            //Outlook.MailItem mailItem = (Outlook.MailItem)
            // this.Application.CreateItem(Outlook.OlItemType.olMailItem);
            //Outlook.Application app = new Outlook.Application();
            //    Outlook.MailItem mailItem = app.CreateItem(Outlook.OlItemType.olMailItem);
            //    mailItem.Subject = subject;
            //    mailItem.To = to;
            //    mailItem.Body = body;
            //    mailItem.Importance = Outlook.OlImportance.olImportanceHigh;
            //    mailItem.Display(false);
            //    mailItem.Send();
            #endregion
        }
    }



}