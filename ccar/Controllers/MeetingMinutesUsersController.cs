using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ccar.Models;

namespace ccar.Controllers
{
    public class MeetingMinutesUsersController : Controller
    {
        // GET: Project
        public ActionResult UserstList()
        {
            List<MeetingMinutesUsersModel> proList = new List<MeetingMinutesUsersModel>();
            ccarMeetingMinutesEntities ent = new ccarMeetingMinutesEntities();
            proList = MeetingMinutesUsersModel.fromMMUsersDB(ent.mMusers.ToList());
            return View(proList);
        }




    }
}