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
        [HttpGet]
        public ActionResult Index()
        {

            return View();
        }

        [HttpGet]
        public ActionResult GetData()
        {
            using (ccarMeetingMinutesEntities ent = new ccarMeetingMinutesEntities())
            {
                List<mmDatesView> mmDlist = new List<mmDatesView>();
                var test = ent.mmDatesView.ToList();
                mmDlist = MeetingMinutesDatesModel.fromMMDatesView(ent.mmDatesView.ToList());
                return Json(new { data = mmDlist }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        [Authorize]
        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                return View(new MeetingMinutesDatesModel());
            }
            else
            {
                ccarMeetingMinutesEntities ent = new ccarMeetingMinutesEntities();
                meetingMinutesDates test = ent.meetingMinutesDates.Where(x => x.id == id).FirstOrDefault();
                return View(MeetingMinutesDatesModel.ConvertFromEFtoModel(test));
            }

        }
        [Authorize]
        [HttpPost]
        public ActionResult AddOrEdit(MeetingMinutesDatesModel mmD)
        {
            try
            {
                mmD.Save();
            }
            catch (Exception ex)
            {
                return Json(new { succes = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { succes = true, message = "Saved sucesfully" }, JsonRequestBehavior.AllowGet);

        }





    }
}