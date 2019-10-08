using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ccar.Models;

namespace ccar.contro
{
    public class MeetingMinutesProjectController : Controller
    {
        // GET: Project
        //public ActionResult ProjectList()
        //{
        //    List<mmProjectsModel> proList = new List<mmProjectsModel>();
        //    ccarMeetingMinutesEntities ent = new ccarMeetingMinutesEntities();
        //    proList = mmProjectsModel.fromProjectDB(ent.MeetingMinutesProjects.ToList());
        //    return View(proList);
        //}
        //// Create
        //[HttpGet]
        //public ActionResult Create()
        //{
        //    mmProjectsModel p = new mmProjectsModel();
        //    return View(p);
        //}
        ////Create post
        //[HttpPost]
        //public ActionResult Create(mmProjectsModel r)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        ccarMeetingMinutesEntities ent = new ccarMeetingMinutesEntities();
        //        ent.MeetingMinutesProjects.Add(mmProjectsModel.ConvertFromModelToDB(r));
        //        ent.SaveChanges();
        //        return RedirectToAction("ProjectList");
        //    }
        //    return View(r);

        //}
        ////Edit
        //public ActionResult Edit(int id)
        //{
        //    ccarMeetingMinutesEntities ent = new ccarMeetingMinutesEntities();
        //    mmProjectsModel pro = mmProjectsModel.ConvertFromDbToModel(ent.MeetingMinutesProjects.Where(x => x.id == id).FirstOrDefault());
        //    return View(pro);
        //}
        //// Edit post
        //[HttpPost]
        //public ActionResult Edit(mmProjectsModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        ccarMeetingMinutesEntities ent = new ccarMeetingMinutesEntities();
        //        MeetingMinutesProjects pro = ent.MeetingMinutesProjects.Where(x => x.id == model.id).FirstOrDefault();

        //        pro.id = model.id;
        //        pro.ProjectName = model.ProjectName;
        //        ent.SaveChanges();
        //        return RedirectToAction("ProjectList");
        //    }
        //    return View(model);
        //}

        ////delete
        //[HttpGet]
        //public ActionResult Delete(int id)
        //{
        //    ccarMeetingMinutesEntities ent = new ccarMeetingMinutesEntities();
        //    mmProjectsModel pro = mmProjectsModel.ConvertFromDbToModel(ent.MeetingMinutesProjects.Where(x=>x.id == id).FirstOrDefault());
        //    return View(pro);
        //}

        //[HttpPost][ActionName("Delete")]
        //[ValidateAntiForgeryToken]

        ////delete post
        //public ActionResult DeleteConfirmed (int id)
        //{
        //    try
        //    {
        //        ccarMeetingMinutesEntities ent = new ccarMeetingMinutesEntities();
        //        MeetingMinutesProjects pro =  ent.MeetingMinutesProjects.Find(id);
        //        ent.MeetingMinutesProjects.Remove(pro);
        //    }
        //    catch (Exception)
        //    {

        //        return RedirectToAction("DeleteRefused");
        //    }
        //    return RedirectToAction("ProjectList");
        //}
        

    }
}