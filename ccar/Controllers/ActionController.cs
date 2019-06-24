﻿using System;
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
            if (id == 0){

                return View(new action());
            }
            else
            {
                ccarEntities ent = new ccarEntities();
                actions test = ent.actions.Where(x => x.id == id).FirstOrDefault();
                return View(action.ConvertFromEFtoModel(test));
            }
           
        }
        [HttpPost]
        public ActionResult AddOrEdit(action Act)
        {
            if(Act.id == 0)
            {
          
                ccarEntities ent = new ccarEntities();
         
                ent.actions.Add(action.ConvertToActionsFromDb(Act));
                ent.SaveChanges();
                //emailClass.sendMail(responsible.getEmailAdress(Act.idResponsible), "Utworzono nowe zadanie", "Nowe zadanie");
                return Json(new { succes = true, message = "Saved sucesfully" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                ccarEntities ent = new ccarEntities();
                ent.Entry(action.ConvertToActionsFromDb(Act)).State = EntityState.Modified;
                ent.SaveChanges();
                return Json(new { succes = true, message = "Updated sucesfully" }, JsonRequestBehavior.AllowGet);
            }
         
            //emailClass email = new emailClass();
            //emailClass.sendMail();
          

            /*
             1.pobrac adres mailowy na podtsawie ID act (w modelu initaiotor), get emailadress, zwraca maila
             2. sprawdzanie czy nie jest null i czy jest poprawny - w metodzie
           
             */
            
        }
        [HttpPost]
        public ActionResult Delete (int id)
        {
            ccarEntities ent = new ccarEntities();

            actions act = ent.actions.Find(id);
            ent.actions.Remove(act);
            ent.SaveChanges();
            //action act = action.ConvertFromEFtoModel(ent.actions.Where(x => x.id == id).FirstOrDefault());
            //ent.actions.Remove(action.ConvertToActionsFromDb(act));
            return Json(new { succes = true, message = "Delete Sucessfully" }, JsonRequestBehavior.AllowGet);




            //testowaEntities ent = new testowaEntities();
            //komputery komp = ent.komputeries.Find(id);
            //ent.komputeries.Remove(komp);
            //ent.SaveChanges();
        }
    }
}