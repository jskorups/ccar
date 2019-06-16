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
                List<actionView> actList = new List<actionView>();

                actList = action.fromActionsDB(ent.actionView.ToList());
                return Json(new { data = actList }, JsonRequestBehavior.AllowGet); 
            }
        }

        [HttpGet]
       public ActionResult AddOrEdit(int id = 0)
        {
            return View(new action());
        }
        [HttpPost]
        public ActionResult AddOrEdit(action Act)
        {

            ccarEntities ent = new ccarEntities();
            ent.actions.Add(action.ConvertToActionsFromDb(Act));
            ent.SaveChanges();
            emailClass email = new emailClass();
            //emailClass.sendMail();
            return Json(new { succes = true, message = "Saved sucesfully" }, JsonRequestBehavior.AllowGet);

            /*
             1.pobrac adres mailowy na podtsawie ID act (w modelu initaiotor), get emailadress, zwraca maila
             2. sprawdzanie czy nie jest null i czy jest poprawny - w metodzie
           
             */
            
        }
    }
}