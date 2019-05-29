using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ccar.Models;

namespace ccar.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }


        #region Rejestracja
        [HttpGet]
        public ActionResult Register()
        {
            Login user = new Login();
            return View(user);
        }
        [HttpPost]
        public ActionResult Register(Login userNew)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    userNew.SaveToDataBase();
                    return RedirectToAction("Logowanie");
                }
            }
            catch (Exception)
            {

                throw;
            }
            return View(userNew);
        }
        #endregion
        #region Logowanie
        //Logowanie
        [HttpGet]
        public ActionResult Logowanie()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Logowanie(string login, string password)
        {
            Login newlog = new Login();
            password = crypto.Hash(password);
            bool check = newlog.checkIfExist(login, password);
            if (check == true)
            {
                FormsAuthentication.SetAuthCookie(login, false);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }
        #endregion
        #region Wylogowanie
        public ActionResult Wylogowanie()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
        #endregion
    }
}