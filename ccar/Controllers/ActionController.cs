using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ccar.Models;
using System.Data.Entity;
using System.Web.Security;

namespace ccar.Controllers
{
    public class ActionController : Controller
    {
        [Authorize]

        [HttpGet]
        public ActionResult Index()
        {

           
            return View();
        }

        [Authorize]

        [HttpGet]
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
        [Authorize]
        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
            {

                return View(new action());
            }
            else
            {
                ccarEntities ent = new ccarEntities();
                actions test = ent.actions.Where(x => x.id == id).FirstOrDefault();
                return View(action.ConvertFromEFtoModel(test));
            }

        }


      
        [Authorize]
        [HttpPost]
        public ActionResult AddOrEdit(action Act)
        {
            try
            {
                Act.Save();

            }
            catch (Exception ex)
            {
                return Json(new { succes = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { succes = true, message = "Saved sucesfully" }, JsonRequestBehavior.AllowGet);



            //emailClass email = new emailClass();
            //emailClass.sendMail();
            /*
             1.pobrac adres mailowy na podtsawie ID act (w modelu initaiotor), get emailadress, zwraca maila
             2. sprawdzanie czy nie jest null i czy jest poprawny - w metodzie
           
             */

        }

       
        [Authorize]
        [HttpPost]
        public ActionResult Delete (int id)
        {

            ccarEntities ent = new ccarEntities();
            actions act = ent.actions.Find(id);
            ent.actions.Remove(act);
            ent.SaveChanges();
            return Json(new { succes = true, message = "Delete Sucessfully" }, JsonRequestBehavior.AllowGet);
        }
    }
}