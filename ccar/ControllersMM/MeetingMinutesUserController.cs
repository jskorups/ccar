using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ccar.Models;

namespace ccar.Controllers
{
    public class MeetingMinutesUserController : Controller
    {
        //// GET: MeetingMinutesUser
        //public ActionResult UsersList()
        //{
        //    List<UserModel> usLIst = new List<UserModel>();
        //    ccarMeetingMinutesEntities ent = new ccarMeetingMinutesEntities();
        //    usLIst = UserModel.fromUsersDB(ent.User.ToList());
        //    return View(usLIst);
        //}

        ////create
        //[HttpGet]
        //public ActionResult Create()
        //{
        //    UserModel model = new UserModel();
        //    return View(model);
        //}

        ////create post
        //[HttpPost]
        //public ActionResult Create(UserModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        ccarMeetingMinutesEntities ent = new ccarMeetingMinutesEntities();
        //        ent.User.Add(UserModel.COnvertFromModelToDB(model));
        //        ent.SaveChanges();

        //        return RedirectToAction("UsersList");
        //    }
        //    return View(model);
        //}

        ////edit
        //[HttpGet]
        //public ActionResult Edit(int id)
        //{
        //    ccarMeetingMinutesEntities ent = new ccarMeetingMinutesEntities();
        //    UserModel mod = UserModel.COnvertFromDbToModel(ent.User.Where(x => x.id == id).FirstOrDefault());
        //    return View(mod);

        //}
        ////edit post
        //[HttpPost]
        //public ActionResult Edit(UserModel model)
        //{

        //    if (ModelState.IsValid)
        //    {
        //        ccarMeetingMinutesEntities ent = new ccarMeetingMinutesEntities();
        //        UserModel mod = UserModel.COnvertFromDbToModel(ent.User.Where(x => x.id == model.id).FirstOrDefault());

        //        mod.id = model.id;
        //        mod.firstname = model.firstname;
        //        mod.surname = model.surname;
        //        mod.email = model.email;
        //        ent.SaveChanges();

        //        return RedirectToAction("UsersList");
        //    }
        //    return View(model);
        //}
        ////delete get
        //[HttpGet]
        //public ActionResult Delete(int id)
        //{
        //    ccarMeetingMinutesEntities ent = new ccarMeetingMinutesEntities();
        //    UserModel model = UserModel.COnvertFromDbToModel(ent.User.Where(x => x.id == id).FirstOrDefault());
        //    return View(model);
        //}

        //[HttpPost]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            ccarMeetingMinutesEntities ent = new ccarMeetingMinutesEntities();
        //            User m = ent.User.Find(id);
        //            ent.User.Remove(m);

        //        }
        //    }
        //    catch (Exception)
        //    {

        //        return RedirectToAction("DeleteRefused");
        //    }
        //    return RedirectToAction("UsersList");
            
            

        //}

    }
}