using ccar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ccar.ControllerProjects
{
    public class CCARprojectsController : Controller
    {
        // GET: Projects
        public ActionResult Index()
        {

            return View();
        }


        // get list with not done
        [HttpGet]
        public ActionResult GetData(int id)
        {
            using (ccarEntities ent = new ccarEntities())
            {
                List<actionViewCustom> actList = new List<actionViewCustom>();

                actList = ActionModel.fromLayoutActionsCustomDB(ent.actionViewCustom.Where(x=>x.idReason == id).ToList());
                return Json(new { data = actList }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}