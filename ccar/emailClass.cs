using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Mail;
using System.Web.Configuration;
using System.Net.Configuration;

namespace ccar
{
    public class emailClass
    {
        public static void sendMail(string ToWho, string Body, string subject)
        {
            try
            {
                System.Configuration.Configuration config = WebConfigurationManager.OpenWebConfiguration(
                HttpContext.Current.Request.ApplicationPath);
                MailSettingsSectionGroup settings =
                    (MailSettingsSectionGroup)config.GetSectionGroup("system.net/mailSettings");

                SmtpClient client = new SmtpClient();
                client.Credentials = new NetworkCredential(settings.Smtp.Network.UserName, settings.Smtp.Network.Password);
                MailMessage msg = new MailMessage();
                msg.Body = Body;
                msg.IsBodyHtml = true;
                msg.Subject = subject;
                msg.From = new MailAddress("kowalski.jan567890@gmail.com");
#if DEBUG
                msg.To.Add("kowalski.jan567890@gmail.com");
#else
                msg.To.Add(toWho);
#endif
                client.Send(msg);
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }



    }
}