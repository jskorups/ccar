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
       
        //[HttpGet]
        //[Authorize]
        //public ActionResult AddOrEdit(int id = 0)
        //{
        //    if (id == 0)
        //    {
        //        return View(new MeetingMinutesDatesDetails());
        //    }
        //    else
        //    {
        //        ccarMeetingMinutesEntities ent = new ccarMeetingMinutesEntities();
        //        meetingMinutesDates test = ent.meetingMinutesDates.Where(x => x.id == id).FirstOrDefault();
        //        return View(MeetingMinutesDatesModel.convertFromModelToDb(test));
        //    }

        //}
        //[Authorize]
        //[HttpPost]
        //public ActionResult AddOrEdit(MeetingMinutesDatesModel mmD)
        //{
        //    try
        //    {
        //        mmD.Save();
        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(new { succes = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
        //    }
        //    return Json(new { succes = true, message = "Saved sucesfully" }, JsonRequestBehavior.AllowGet);

        //}
    }
}