using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ccar.Models;

namespace ccar.Controllers
{
    public class MeetingMinutesController : Controller
    {
        // GET: MeetingMinutes
        public ActionResult MeetingMinutesList()
        {
           List<MeetingMinutesModel> meMin = new List<MeetingMinutesModel>();
            ccarEntities ent = new ccarEntities();
            meMin = MeetingMinutesModel.GetListOfFromDB(ent.meetingMinutes.ToList());
            return View(meMin);
        }
    }
}