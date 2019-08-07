using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ccar.Models;

namespace ccar.Controllers
{
    public class ProjectController : Controller
    {
        // GET: Project
        public ActionResult ProjectList()
        {
            List<MeetingMinutesProjectModel> proList = new List<MeetingMinutesProjectModel>();
            ccarMeetingMinutesEntities ent = new ccarMeetingMinutesEntities();
            proList = MeetingMinutesProjectModel.fromProjectDB(ent.MeetingMinutesProjects.ToList());
            return View(proList);
        }

        // Create
        [HttpGet]
        public ActionResult Create()
        {
            MeetingMinutesProjectModel p = new MeetingMinutesProjectModel();
            return View(p);
        }


        //Create post
        [HttpPost]
        public ActionResult Create(MeetingMinutesProjectModel r)
        {
            if (ModelState.IsValid)
            {
                ccarMeetingMinutesEntities ent = new ccarMeetingMinutesEntities();
                ent.MeetingMinutesProjects.Add(MeetingMinutesProjectModel.ConvertFromModelToDB(r));
                ent.SaveChanges();
                return RedirectToAction("ProjectList");
            }
            return View(r);

        }


        //Edit
        public ActionResult Edit(int id)
        {
            ccarMeetingMinutesEntities ent = new ccarMeetingMinutesEntities();
            MeetingMinutesProjectModel pro = MeetingMinutesProjectModel.ConvertFromDbToModel(ent.MeetingMinutesProjects.Where(x => x.id == id).FirstOrDefault());
            return View(pro);
        }
        // Edit post
        [HttpPost]
        public ActionResult Edit(MeetingMinutesProjectModel model)
        {
            if (ModelState.IsValid)
            {
                ccarMeetingMinutesEntities ent = new ccarMeetingMinutesEntities();
                MeetingMinutesProjects pro = ent.MeetingMinutesProjects.Where(x => x.id == model.id).FirstOrDefault();

                pro.id = model.id;
                pro.ProjectName = model.ProjectName;
                ent.SaveChanges();
                return RedirectToAction("ProjectList");
            }
            return View(model);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            ccarMeetingMinutesEntities ent = new ccarMeetingMinutesEntities();
            MeetingMinutesProjectModel pro = MeetingMinutesProjectModel.ConvertFromDbToModel(ent.MeetingMinutesProjects.Where(x=>x.id == id).FirstOrDefault());
            return View(pro);
        }
        [HttpPost][ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public ActionResult DeleteConfirmed (int id)
        {
            try
            {
                ccarMeetingMinutesEntities ent = new ccarMeetingMinutesEntities();
                MeetingMinutesProjects pro =  ent.MeetingMinutesProjects.Find(id);
                ent.MeetingMinutesProjects.Remove(pro);
            }
            catch (Exception)
            {

                return RedirectToAction("DeleteRefused");
            }
            return RedirectToAction("ProjectList");
        }
        

    }
}