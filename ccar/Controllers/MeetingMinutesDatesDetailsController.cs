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


        // get list uzytkowników
        [HttpGet]
        public ActionResult MeetingMinutesDetails()
        {
            List<Meeting> proList = new List<Meeting>();
            ccarMeetingMinutesEntities ent = new ccarMeetingMinutesEntities();
            proList = Meeting.fromMMUsersDB(ent.mMusers.ToList());
            return View(proList);
        }
        //[HttpPost]
        //public ActionResult MeetingMinutes (Meeting model)
        //{
        //    try
        //    {
        //     // ?????
        //    }
        //    catch (Exception)
        //    {
        //        // ?????
        //        throw;
        //    }
        //}



        //get widok tabeli ze spotkaniami
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

        // edit get
        [HttpGet]
        [Authorize]
        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                return View(new Meeting());
            }
            else
            {
                ccarMeetingMinutesEntities ent = new ccarMeetingMinutesEntities();
                meetingMinutesDates test = ent.meetingMinutesDates.Where(x => x.id == id).FirstOrDefault();
                return View(MeetingMinutesDatesModel.convertFromModelToDb(test));
            }

        }

        // post do add or edit
        [Authorize]
        [HttpPost]
        public ActionResult AddOrEdit(Meeting mmDD)
        {
            try
            {
                mmDD.Save();
                //var email = responsible.getEmailAdress(Act.idResponsible);
                //emailClass.sendMail(email, "Bablabla", "sdjklhsljkdjflksdf");
                //var email = UserModel.getEmailAdress(Act.idResponsible);
                //emailClass.CreateMailItem(email, "Problem: "+ Act.problem + System.Environment.NewLine + "Target date: " + Act.targetDate, "Utworzono nowe zadanie dla Ciebie w CCAR");    
            }
            catch (Exception ex)
            {
                return Json(new { succes = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { succes = true, message = "Saved sucesfully" }, JsonRequestBehavior.AllowGet);
        }




    }
}