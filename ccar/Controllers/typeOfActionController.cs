using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ccar.Models;

namespace ccar.Controllers
{
    public class typeOfActionController : Controller
    {
        // GET: typeOfAction
        public ActionResult AddOrEditToA()
        {
            return View("Create");
        }

        [HttpGet]
        public ActionResult AddOrEditToA2()
        {
            return View("AddOrEditToA");
        }

        // Type of action list
        [HttpGet]
        public ActionResult ToAlist()
        {
            List<TypeOfActionModel> toa = new List<TypeOfActionModel>();
            ccarEntities ent = new ccarEntities();
            toa = TypeOfActionModel.fromTypeOfAction(ent.typeOfaction.ToList());
            return View(toa);

        }
        //Create
        [HttpGet]
        public ActionResult Create()
        {
            TypeOfActionModel t = new TypeOfActionModel();
            return View(t);
        }

        //Create post
        [HttpPost]
        public ActionResult Create(TypeOfActionModel t)
        {
            if (ModelState.IsValid)
            {
                ccarEntities ent = new ccarEntities();
                ent.typeOfaction.Add(TypeOfActionModel.ConvertFromModelToDB(t));
                ent.SaveChanges();
                return RedirectToAction("ToAlist");
            }
            return View(t);
        }
        //Edit
        [HttpGet]
        public ActionResult Edit(int id)
        {
            ccarEntities ent = new ccarEntities();
            TypeOfActionModel toa = TypeOfActionModel.ConvertFromDBtoModel(ent.typeOfaction.Where(x => x.id == id).FirstOrDefault());
            return View(toa);
        }
        //Edit post
        [HttpPost]
        public ActionResult Edit (TypeOfActionModel model)
        {
            if (ModelState.IsValid)
            {
                ccarEntities ent = new ccarEntities();
                typeOfaction toa = ent.typeOfaction.Where(x => x.id == model.id).FirstOrDefault();

                toa.id = model.id;
                toa.typeOfaction1 = model.typeOfAction1;
                ent.SaveChanges();
                return RedirectToAction("ToAlist");
            }
            return View(model);
        }

        //Delete get
        [HttpGet]
        public ActionResult Delete(int id)
        {
            ccarEntities ent = new ccarEntities();
            TypeOfActionModel toa = TypeOfActionModel.ConvertFromDBtoModel(ent.typeOfaction.Where(x => x.id == id).FirstOrDefault());
            return View(toa);
        }

        //Delete post
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public ActionResult DeleteConfirmed (int id)
        {
            try
            {
                ccarEntities ent = new ccarEntities();
                typeOfaction toa = ent.typeOfaction.Find(id);
                ent.typeOfaction.Remove(toa);
                ent.SaveChanges();
            }
            catch (Exception)
            {

                return RedirectToAction("DeleteRefused");
            }
            return RedirectToAction("ToAlist");
        }

        [HttpGet]
        public ActionResult DeleteRefused()
        {
            return View();
        }

    }
}