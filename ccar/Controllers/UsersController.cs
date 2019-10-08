using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ccar.Models;

namespace ccar.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult UsersList()
        {
            List<UserModel> users = new List<UserModel>();
            ccarEntities ent = new ccarEntities();
            users = UserModel.fromUsers(ent.users.ToList());
            return View(users);
        }

        [HttpGet]
        public ActionResult DropDownListOfUsers()
        {
            ccarEntities ent = new ccarEntities();
            ViewBag.DepartmentList = new SelectList(ent.users.ToList(), "id", "firstname" + "surname", "department", 1);
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            UserModel us = new UserModel();
            return View(us);
        }
        [HttpPost]
        public ActionResult Create(UserModel u)
        {
            if (ModelState.IsValid)
            {
                ccarEntities ent = new ccarEntities();
                ent.users.Add(UserModel.ConvertFromModelToDB(u));
                ent.SaveChanges();
                return RedirectToAction("UsersList");
            }
            return View(u);

        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            ccarEntities ent = new ccarEntities();
            UserModel us = UserModel.ConvertFromDbToModel(ent.users.Where(x => x.id == id).FirstOrDefault());
            return View(us);
        }
        [HttpPost]
        public ActionResult Edit(UserModel us)
        {
            if (ModelState.IsValid)
            {
                ccarEntities ent = new ccarEntities();
                users user = ent.users.Where(x => x.id == us.id).FirstOrDefault();

                user.id = Convert.ToInt32(us.id == null ? 0 : us.id);
                user.firstname = us.firstname;
                user.surname = us.surname;
                user.email = us.email;
                ent.SaveChanges();
                return RedirectToAction("UsersList");
            }
            return View(us);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            ccarEntities ent = new ccarEntities();
            UserModel user = UserModel.ConvertFromDbToModel(ent.users.Where(x => x.id == id).FirstOrDefault());
            return View(user);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                ccarEntities ent = new ccarEntities();
                users user = ent.users.Find(id);
                ent.users.Remove(user);
                ent.SaveChanges();
            }
            catch (Exception)
            {
                return RedirectToAction("DeleteRefused");
            }
            return RedirectToAction("UsersList");
        }
                [HttpGet]
        public ActionResult DeleteRefused()
        {
            return View();
        }
    }




}
