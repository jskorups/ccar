using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ccar.Models;

namespace ccar.Controllers
{
    public class ActionController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

      public ActionResult GetData()
        {
            using (ccarEntities ent = new ccarEntities())
            {
                List<actions> actList = ent.actions.ToList<actions>();
                return Json(new { data = actList }, JsonRequestBehavior.AllowGet); 
            }
        }
    }
}