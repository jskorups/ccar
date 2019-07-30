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

        [HttpGet]
        public ActionResult Index2()
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

                actList = ActionModel.fromActionsDB(ent.actionView.ToList());
                return Json(new { data = actList }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult GetData2()
        {
            using (ccarEntities ent = new ccarEntities())
            {
                List<actionViewDone> actList = new List<actionViewDone>();

                actList = ActionModel.fromActionsDB2(ent.actionViewDone.ToList());
                return Json(new { data = actList }, JsonRequestBehavior.AllowGet);
            }
        }

        //[HttpGet]
        //public ActionResult GetDataWithDone()
        //{
        //    using (ccarEntities ent = new ccarEntities())
        //    {

        //    }


        //}

        [HttpGet]
        [Authorize]
        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
            {

                return View(new ActionModel());
            }
            else
            {
                ccarEntities ent = new ccarEntities();
                actions test = ent.actions.Where(x => x.id == id).FirstOrDefault();
                return View(ActionModel.ConvertFromEFtoModel(test));
            }

        }

        public PartialViewResult EditDeletePartial(int id)
        {
            ViewBag.id = id;
            return PartialView();
        }

        [Authorize]
        [HttpPost]
        public ActionResult AddOrEdit(ActionModel Act)
        {
            try
            {
                Act.Save();
                //var email = responsible.getEmailAdress(Act.idResponsible);
                //emailClass.sendMail(email, "Bablabla", "sdjklhsljkdjflksdf");
                var email = UserModel.getEmailAdress(Act.idResponsible);
                emailClass.CreateMailItem(email, "Problem: "+ Act.problem + System.Environment.NewLine + "Target date: " + Act.targetDate, "Utworzono nowe zadanie dla Ciebie w CCAR");
     
            }
            catch (Exception ex)
            {
                return Json(new { succes = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { succes = true, message = "Saved sucesfully" }, JsonRequestBehavior.AllowGet);


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