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
        // GET: MeetingMinutesUser
        public ActionResult UsersList()
        {
            List<mmUsersModel> usLIst = new List<mmUsersModel>();
            ccarMeetingMinutesEntities ent = new ccarMeetingMinutesEntities();
            usLIst = mmUsersModel.fromUsersDB(ent.mMusers.ToList());
            return View(usLIst);
        }

        //create
        [HttpGet]
        public ActionResult Create()
        {
            mmUsersModel model = new mmUsersModel();
            return View(model);
        }

        //create post
        [HttpPost]
        public ActionResult Create(mmUsersModel model)
        {
            if (ModelState.IsValid)
            {
                ccarMeetingMinutesEntities ent = new ccarMeetingMinutesEntities();
                ent.mMusers.Add(mmUsersModel.COnvertFromModelToDB(model));
                ent.SaveChanges();

                return RedirectToAction("UsersList");
            }
            return View(model);
        }

        //edit
        [HttpGet]
        public ActionResult Edit(int id)
        {
            ccarMeetingMinutesEntities ent = new ccarMeetingMinutesEntities();
            mmUsersModel mod = mmUsersModel.COnvertFromDbToModel(ent.mMusers.Where(x => x.id == id).FirstOrDefault());
            return View(mod);

        }
        //edit post
        [HttpPost]
        public ActionResult Edit(mmUsersModel model)
        {

            if (ModelState.IsValid)
            {
                ccarMeetingMinutesEntities ent = new ccarMeetingMinutesEntities();
                mmUsersModel mod = mmUsersModel.COnvertFromDbToModel(ent.mMusers.Where(x => x.id == model.id).FirstOrDefault());

                mod.id = model.id;
                mod.firstname = model.firstname;
                mod.surname = model.surname;
                mod.email = model.email;
                ent.SaveChanges();

                return RedirectToAction("UsersList");
            }
            return View(model);
        }
        //delete get
        [HttpGet]
        public ActionResult Delete(int id)
        {
            ccarMeetingMinutesEntities ent = new ccarMeetingMinutesEntities();
            mmUsersModel model = mmUsersModel.COnvertFromDbToModel(ent.mMusers.Where(x => x.id == id).FirstOrDefault());
            return View(model);
        }

        [HttpPost]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ccarMeetingMinutesEntities ent = new ccarMeetingMinutesEntities();
                    mMusers m = ent.mMusers.Find(id);
                    ent.mMusers.Remove(m);

                }
            }
            catch (Exception)
            {

                return RedirectToAction("DeleteRefused");
            }
            return RedirectToAction("UsersList");
            
            

        }

    }
}