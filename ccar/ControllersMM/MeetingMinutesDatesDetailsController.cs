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

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        //get widok tabeli ze spotkaniami
        [HttpGet]
        public ActionResult GetData()
        {
            using (ccarMeetingMinutesEntities ent = new ccarMeetingMinutesEntities())
            {
                List<MeetingsView> mmDlist = new List<MeetingsView>();
                var test = ent.MeetingsView.ToList();
                mmDlist = MeetingModel.FromMMDatesView(ent.MeetingsView.ToList());
                return Json(new { data = mmDlist }, JsonRequestBehavior.AllowGet);
            }
        }

    }
    
}