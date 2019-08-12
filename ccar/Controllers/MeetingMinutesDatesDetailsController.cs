using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ccar.Models;

namespace ccar.Controllers
{
    public class MeetingMinutesDatesDetailsController : Controller
    {
        // GET: Project
        public ActionResult MeetingMinutesDetails()
        {
            List<MeetingMinutesDatesDetails> proList = new List<MeetingMinutesDatesDetails>();
            ccarMeetingMinutesEntities ent = new ccarMeetingMinutesEntities();
            proList = MeetingMinutesDatesDetails.fromMMUsersDB(ent.mMusers.ToList());
            return View(proList);
        }




    }
}