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
        public static void SendEmailFromAccount(Outlook.Application application, string subject, string body, string to, string smtpAddress)
        {
            #region

            //            if (ToWho == null || ToWho == string.Empty )
            //            {
            //                return;
            //            }
            //            try
            //            {
            //                System.Configuration.Configuration config = WebConfigurationManager.OpenWebConfiguration(
            //                HttpContext.Current.Request.ApplicationPath);
            //                MailSettingsSectionGroup settings =
            //                    (MailSettingsSectionGroup)config.GetSectionGroup("system.net/mailSettings");

            //                SmtpClient client = new SmtpClient();
            //                client.Credentials = new NetworkCredential(settings.Smtp.Network.UserName, settings.Smtp.Network.Password);
            //                MailMessage msg = new MailMessage();
            //                msg.Body = Body;
            //                msg.IsBodyHtml = true;
            //                msg.Subject = subject;
            //                msg.From = new MailAddress("kowalski.jan567890@gmail.com");
            //#if DEBUG
            //                msg.To.Add("kowalski.jan567890@gmail.com");
            //#else
            //                msg.To.Add(toWho);
            //#endif
            //                client.Send(msg);
            //            }
            //            catch (Exception ex)
            //            {

            //                throw ex;
            //            }
            #endregion


            //Outlook.MailItem mailItem = (Outlook.MailItem)
            // this.Application.CreateItem(Outlook.OlItemType.olMailItem);
            Outlook.Application app = new Outlook.Application();
            Outlook.MailItem mailItem = app.CreateItem(Outlook.OlItemType.olMailItem);
            mailItem.Subject = subject;
            mailItem.To = to;
            mailItem.Body = body;
            Outlook.Account account = GetAccountForEmailAddress(application, smtpAddress);
            mailItem.SendUsingAccount = account;
            mailItem.Send();
            mailItem.Importance = Outlook.OlImportance.olImportanceHigh;
            mailItem.Display(false);
        }

        public static Outlook.Account GetAccountForEmailAddress(Outlook.Application application, string smtpAddress)
        {

            // Loop over the Accounts collection of the current Outlook session. 
            Outlook.Accounts accounts = application.Session.Accounts;
            foreach (Outlook.Account account in accounts)
            {
                // When the email address matches, return the account. 
                if (account.SmtpAddress == smtpAddress)
                {
                    return account;
                }
            }
            throw new System.Exception(string.Format("No Account with SmtpAddress: {0} exists!", smtpAddress));
        }






    }
}