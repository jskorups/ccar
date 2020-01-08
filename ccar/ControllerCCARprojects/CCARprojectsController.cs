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

        // GET: Projects
        public ActionResult General(int id)
        {
            GeneralModel mod = new GeneralModel();
            mod.Id = id;
            return View(mod);
        }


        [HttpGet]
        public ActionResult GetData(int id)
        {
            using (ccarEntities ent = new ccarEntities())
            {
                List<actionViewCustom> actList = new List<actionViewCustom>();

                actList = ActionModel.fromLayoutActionsCustomDB(ent.actionViewCustom.Where(x => x.idReason == id).ToList());
                return Json(new { data = actList }, JsonRequestBehavior.AllowGet);
            }
        }
    }


    public class GeneralModel
    {
        public int Id { get; set; }
    }

}