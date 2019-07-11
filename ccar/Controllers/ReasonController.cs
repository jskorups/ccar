using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ccar.Models;

namespace ccar.Controllers
{
    public class ReasonController : Controller
    {
        //GET REASON
        [HttpGet]
        public ActionResult AddOrEditRsn()
        {
            return View("Create");
        }

        [HttpGet]
        public ActionResult AddOrEditRsn2()
        {
            return View("AddOrEditRsn");
        }


        [HttpGet]
        public ActionResult AddOrEditRsnPartial()
        {
            return View("RsnPartialAdd");
        }



        // Reason List
        [HttpGet]
        public ActionResult ReasonList()
        {
            List<ReasonModel> reas = new List<ReasonModel>();
            ccarEntities ent = new ccarEntities();
            reas = ReasonModel.fromReason(ent.reasons.ToList());
            return View(reas);
        }
        // Create
        [HttpGet]
        public ActionResult Create()
        {
            ReasonModel r = new ReasonModel();
            return View(r);
        }

        //Create post
        [HttpPost]
        public ActionResult Create(ReasonModel r)
        {
            if (ModelState.IsValid)
            {
                ccarEntities ent = new ccarEntities();
                ent.reasons.Add(ReasonModel.ConvertFromModelToDB(r));
                ent.SaveChanges();
                return RedirectToAction("ReasonList");
            }
            return View(r);
            return PartialView("NameOfPartialView");
        }
        //Edit
        public ActionResult Edit(int id)
        {
            ccarEntities ent = new ccarEntities();
            ReasonModel rea = ReasonModel.ConvertFromDbToModel(ent.reasons.Where(x => x.id == id).FirstOrDefault());
            return View(rea);
        }
        // Edit post
        [HttpPost]
        public ActionResult Edit (ReasonModel model)
        {
            if (ModelState.IsValid)
            {
                ccarEntities ent = new ccarEntities();
                reasons rea = ent.reasons.Where(x => x.id == model.id).FirstOrDefault();

                rea.id = Convert.ToInt32(model.id==null?0:model.id);
                rea.reason = model.reason;
                ent.SaveChanges();
                return RedirectToAction("ReasonList");
            }
            return View(model);
            
        }

        // Delete Get
        [HttpGet]
        public ActionResult Delete (int id)
        {
            ccarEntities ent = new ccarEntities();
            ReasonModel rea = ReasonModel.ConvertFromDbToModel(ent.reasons.Where(x => x.id == id).FirstOrDefault());
            return View(rea);
        }

        // Delete Post
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public ActionResult DeleteConfirmed (int id)
        {
            try
            {
                ccarEntities ent = new ccarEntities();
                reasons rea = ent.reasons.Find(id);
                ent.reasons.Remove(rea);
                ent.SaveChanges();
            }
            catch (Exception)
            {
                return RedirectToAction("DeleteRefused");

            }
            return RedirectToAction("ReasonList");
        }

        [HttpGet]
        public ActionResult DeleteRefused()
        {
            return View();
        }




    }



}
