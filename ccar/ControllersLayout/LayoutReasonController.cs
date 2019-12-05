using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ccar.ModelsLayout;



namespace ccar.ControllersLayout
{
    public class LayoutReasonController : Controller
    {


        [HttpGet]
        public ActionResult LayoutReasonList()
        {
            List<LayoutReasonModel> reas = new List<LayoutReasonModel>();
            ccarEntities ent = new ccarEntities();
            reas = LayoutReasonModel.fromReason(ent.reasonsLayout.ToList());
            return View(reas);
        }

        // Create
        [HttpGet]
        public ActionResult Create()
        {
            LayoutReasonModel r = new LayoutReasonModel();
            return View(r);
        }
        //Create post
        [HttpPost]
        public ActionResult Create(LayoutReasonModel r)
        {
            if (ModelState.IsValid)
            {
                ccarEntities ent = new ccarEntities();
                ent.reasonsLayout.Add(LayoutReasonModel.ConvertFromModelToDB(r));
                ent.SaveChanges();
                return RedirectToAction("LayoutReasonList");
            }
            return View(r);

        }
        //Edit
        public ActionResult Edit(int id)
        {
            ccarEntities ent = new ccarEntities();
            LayoutReasonModel rea = LayoutReasonModel.ConvertFromDbToModel(ent.reasonsLayout.Where(x => x.id == id).FirstOrDefault());
            return View(rea);
        }
        // Edit post
        [HttpPost]
        public ActionResult Edit(LayoutReasonModel model)
        {
            if (ModelState.IsValid)
            {
                ccarEntities ent = new ccarEntities();
                reasonsLayout rea = ent.reasonsLayout.Where(x => x.id == model.id).FirstOrDefault();

                rea.id = model.id;
                rea.reasonLayout = model.reasonLayout;
                ent.SaveChanges();
                return RedirectToAction("LayoutReasonList");
            }
            return View(model);
        }

        // Delete Get
        [HttpGet]
        public ActionResult Delete(int id)
        {
            ccarEntities ent = new ccarEntities();
            LayoutReasonModel rea = LayoutReasonModel.ConvertFromDbToModel(ent.reasonsLayout.Where(x => x.id == id).FirstOrDefault());
            return View(rea);
        }

        // Delete Post
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                ccarEntities ent = new ccarEntities();
                reasonsLayout rea = ent.reasonsLayout.Find(id);
                ent.reasonsLayout.Remove(rea);
                ent.SaveChanges();
            }
            catch (Exception)
            {
                return RedirectToAction("DeleteRefused");

            }
            return RedirectToAction("LayoutReasonList");
        }

        [HttpGet]
        public ActionResult DeleteRefused()
        {
            return View();
        }
    }
}
