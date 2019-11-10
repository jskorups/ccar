using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ccar.Models;

namespace ccar.Controllers
{
    public class ResponsibleController : Controller
    {
        // GET: Users
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ResponsiblesList()
        {
            List<ResponsibleModel> responsibles = new List<ResponsibleModel>();
            ccarEntities ent = new ccarEntities();
            responsibles = ResponsibleModel.fromUsers(ent.responsibles.ToList());
            return View(responsibles);
        }

        [HttpGet]
        public ActionResult DropDownListOfResponsibles()
        {
            ccarEntities ent = new ccarEntities();
            ViewBag.DepartmentList = new SelectList(ent.responsibles.ToList(), "id", "FirstName" + "Lastname", 1);
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            ResponsibleModel res = new ResponsibleModel();
            return View(res);
        }
        [HttpPost]
        public ActionResult Create(ResponsibleModel u)
        {
            if (ModelState.IsValid)
            {
                ccarEntities ent = new ccarEntities();
                ent.responsibles.Add(ResponsibleModel.ConvertFromModelToDB(u));
                ent.SaveChanges();
                return RedirectToAction("ResponsiblesList");
            }
            return View(u);

        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            ccarEntities ent = new ccarEntities();
            ResponsibleModel us = ResponsibleModel.ConvertFromDbToModel(ent.responsibles.Where(x => x.id == id).FirstOrDefault());
            return View(us);
        }
        [HttpPost]
        public ActionResult Edit(ResponsibleModel us)
        {
            if (ModelState.IsValid)
            {
                ccarEntities ent = new ccarEntities();
                responsibles res = ent.responsibles.Where(x => x.id == us.id).FirstOrDefault();

                res.id = Convert.ToInt32(us.id == null ? 0 : us.id);
                res.FirstName = us.FirstName;
                res.Lastname = us.Lastname;
                res.email = us.email;
                ent.SaveChanges();
                return RedirectToAction("ResponsiblesList");
            }
            return View(us);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            ccarEntities ent = new ccarEntities();
            ResponsibleModel user = ResponsibleModel.ConvertFromDbToModel(ent.responsibles.Where(x => x.id == id).FirstOrDefault());
            return View(user);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                ccarEntities ent = new ccarEntities();
                responsibles user = ent.responsibles.Find(id);
                ent.responsibles.Remove(user);
                ent.SaveChanges();
            }
            catch (Exception)
            {
                return RedirectToAction("DeleteRefused");
            }
            return RedirectToAction("ResponsiblesList");
        }
        [HttpGet]
        public ActionResult DeleteRefused()
        {
            return View();
        }
    }




}
