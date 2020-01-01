using ccar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ccar.ControllerActionMeetings
{
    public class ActionMeetingsController : Controller
    {
        // GET: ActionMeetings
        public ActionResult Index()
        {
            return View();        
        }
        [HttpGet]
        public ActionResult GetData()
        {
            using (ccarEntities ent = new ccarEntities())
            {
                List<ActionMeetingsModel> actList = new List<ActionMeetingsModel>();
                //actList = ent.actionView.ToList();
                actList = ActionMeetingsModel.fromActions(ent.actionsMeetings.ToList());
                return Json(new { data = actList }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}