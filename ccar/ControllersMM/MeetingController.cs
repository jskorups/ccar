using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ccar.Models;

namespace ccar.ControllersMM
{
    public class MeetingController : Controller
    {
        // GET: Meeting
        public ActionResult Index()
        {
            return View();
        }

        //get list with not done
        [HttpGet]
        public ActionResult GetData()
        {
            using (ccarMeetingMinutesEntities ent = new ccarMeetingMinutesEntities())
            {
                List<MeetingsView> meetingsList = new List<MeetingsView>();

                meetingsList = MeetingModel.FromMMDatesView(ent.MeetingsView.ToList());
                return Json(new { data = meetingsList }, JsonRequestBehavior.AllowGet);
            }
        }


    }
}