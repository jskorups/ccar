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
                //Outlook.MailItem mailItem = (Outlook.MailItem)
                // this.Application.CreateItem(Outlook.OlItemType.olMailItem);
                Outlook.Application app = new Outlook.Application();
                Outlook.MailItem mailItem = app.CreateItem(Outlook.OlItemType.olMailItem);
                mailItem.Subject = subject;
                mailItem.To = to;
                mailItem.Body = body;
                mailItem.Importance = Outlook.OlImportance.olImportanceHigh;
                mailItem.Display(false);
                mailItem.Send();
            }
        }
       

    
}