using ccar.Models;
using System;
using System.Net.Mail;
using System.Text;
using System.Web.Hosting;

namespace ccar
{
    public class emailClass
    {


        public static void CreateNewMailItem(ActionModel act, string subject)
        {
            try
            {
                string path = HostingEnvironment.MapPath("~/Content/template/newAction.html");
            string bodyPath = System.IO.File.ReadAllText(path);

            bodyPath = bodyPath.Replace("{d}", $"{System.DateTime.Now.DayOfWeek.ToString()}, { DateTime.Now.ToString("dd.MM.yy")}");
            bodyPath = bodyPath.Replace("{Initiator}", ActionModel.getNameOfInitiator(act.idInitiator));
            bodyPath = bodyPath.Replace("{Reason}", ReasonModel.getNameOfReason(act.idReason));
            bodyPath = bodyPath.Replace("{Problem}", act.problem);
            bodyPath = bodyPath.Replace("{ToA}", act.TypeOfAction);
            bodyPath = bodyPath.Replace("{Responsible}", act.Responsible);
            bodyPath = bodyPath.Replace("{TargetDate}", act.targetDate.ToString());
            bodyPath = bodyPath.Replace("{ProLong}", act.problemLong.ToString());

         
                MailMessage mail = new MailMessage();
                SmtpClient smtpserver = new SmtpClient("172.25.120.139", 25);
                smtpserver.UseDefaultCredentials = false;
                mail.From = new MailAddress("ccar@system.com");
                mail.To.Add(UserModel.getEmailAdress(act.Responsible));
                mail.Subject = subject;
                mail.Body = bodyPath;
                mail.IsBodyHtml = true;
                mail.BodyEncoding = Encoding.UTF8;
                mail.Priority = MailPriority.High;
                smtpserver.EnableSsl = false;
                smtpserver.Timeout = 60000;
                smtpserver.Send(mail);
                #region gmail
                //System.Configuration.Configuration config = WebConfigurationManager.OpenWebConfiguration(
                //  HttpContext.Current.Request.ApplicationPath);
                //MailSettingsSectionGroup settings =
                //    (MailSettingsSectionGroup)config.GetSectionGroup("system.net/mailSettings");

                //SmtpClient client = new SmtpClient();
                //client.Credentials = new NetworkCredential(settings.Smtp.Network.UserName, settings.Smtp.Network.Password);
                //MailMessage msg = new MailMessage();
                //msg.Body = body;
                //msg.IsBodyHtml = true;
                //msg.Subject = subject;
                //msg.From = new MailAddress("kowalski.jan567890@gmail.com");

                //msg.To.Add("kowalski.jan567890@gmail.com");

                //msg.To.Add(to);

                //client.Send(msg);

                #endregion
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