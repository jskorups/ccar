using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ccar.Models;
using ccar.ModelsMM;
using ccar.ModelsMM.MMViewModels;

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
        [HttpGet]
        public ActionResult AddOrEditMeeting()
        {
            AddMeetingViewModel adVM = new AddMeetingViewModel(3);
            return View(adVM);
        }

        [HttpPost]
        public ActionResult AddOrEditMeeting(AddMeetingViewModel model, bool[] Person, int[] PersonId)
        {
            List<int> choosenPerson = new List<int>();
            for (int i = 0; i <PersonId.Count(); i++)
            {
                if (Person[i] == true)
                {
                    choosenPerson.Add(PersonId[i]);
                }
            }
            int [] myArray =  choosenPerson.ToArray();
            model.Save(myArray);
            return Json(new { succes = true, message = "Saved sucesfully" }, JsonRequestBehavior.AllowGet);


        }
        public ActionResult RowDetailsPartial(int id)
        {
            ccarMeetingMinutesEntities ent = new ccarMeetingMinutesEntities();
            List<User> rowDetail = ent.MeetingUsers.Where(x => x.meetingId == id).Select(x => x.User).ToList();             
            return PartialView(rowDetail);
        }
       
    }
}