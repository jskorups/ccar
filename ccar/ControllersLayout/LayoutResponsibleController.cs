using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ccar.ModelsLayout;

namespace ccar.ControllersLayout
{
    public class LayoutResponsibleController : Controller
    {
      
            // GET: Users
            public ActionResult Index()
            {
                return View();
            }

            [HttpGet]
            public ActionResult LayoutResponsiblesList()
            {
                List<LayoutResponsibleModel> responsibles = new List<LayoutResponsibleModel>();
                ccarEntities ent = new ccarEntities();
                responsibles = LayoutResponsibleModel.fromUsers(ent.responsiblesLayout.ToList());
                return View(responsibles);
            }

            [HttpGet]
            public ActionResult DropDownListOfResponsibles()
            {
                ccarEntities ent = new ccarEntities();
                ViewBag.DepartmentList = new SelectList(ent.responsiblesLayout.ToList(), "id", "FirstName" + "Lastname", 1);
                return View();
            }

            [HttpGet]
            public ActionResult Create()
            {
                LayoutResponsibleModel res = new LayoutResponsibleModel();
                return View(res);
            }
            [HttpPost]
            public ActionResult Create(LayoutResponsibleModel u)
            {
                if (ModelState.IsValid)
                {
                    ccarEntities ent = new ccarEntities();
                    ent.responsiblesLayout.Add(LayoutResponsibleModel.ConvertFromModelToDB(u));
                    ent.SaveChanges();
                    return RedirectToAction("ResponsiblesList");
                }
                return View(u);

            }
            [HttpGet]
            public ActionResult Edit(int id)
            {
                ccarEntities ent = new ccarEntities();
            LayoutResponsibleModel us = LayoutResponsibleModel.ConvertFromDbToModel(ent.responsiblesLayout.Where(x => x.id == id).FirstOrDefault());
                return View(us);
            }
            [HttpPost]
            public ActionResult Edit(LayoutResponsibleModel us)
            {
                if (ModelState.IsValid)
                {
                    ccarEntities ent = new ccarEntities();
                    responsiblesLayout res = ent.responsiblesLayout.Where(x => x.id == us.id).FirstOrDefault();

                    res.id = us.id;
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
                LayoutResponsibleModel user = LayoutResponsibleModel.ConvertFromDbToModel(ent.responsiblesLayout.Where(x => x.id == id).FirstOrDefault());
                return View(user);
            }
            [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public ActionResult DeleteConfirmed(int id)
            {
                try
                {
                    ccarEntities ent = new ccarEntities();
                    responsiblesLayout user = ent.responsiblesLayout.Find(id);
                    ent.responsiblesLayout.Remove(user);
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