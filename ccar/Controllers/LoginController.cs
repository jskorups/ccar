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
        public ActionResult Logowanie()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Logowanie(string email, string password)
        {
            LoginModel newlog = new LoginModel();
            //zakryptowac haslo
            bool check = newlog.checkIfExist(email, password);
            if (check == true)
            {
                ModelState.Clear();
                ModelState.Remove("email");
                FormsAuthentication.SetAuthCookie(email, false);
                return RedirectToAction("Index", "Home");

            }
            else
            {
                ModelState.AddModelError("email", "Nie znaleziono użytkownika");                       
                return View();
            }
        }



        #region Rejestracja
        [HttpGet]
        public ActionResult Register()
        {
            LoginModel user = new LoginModel();
            return View(user);
        }
        #endregion
        [HttpGet]
        public ActionResult Registered()
        {
            return View();
        }

        #region Old version
        //[HttpPost]
        //public ActionResult Register(LoginModel userNew)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            userNew.active = false;
        //            Guid guidPotwierdzenie = Guid.NewGuid();
        //            userNew.guid = guidPotwierdzenie.ToString();
        //            userNew.SaveToDataBase();

        //            string url = System.Web.HttpRuntime.AppDomainAppVirtualPath + Url.Action("Aktywacja") + $"?kod={guidPotwierdzenie.ToString()}";
        //            string subject = "Link aktywacyjny";

        //            //emailClass.sendMail(userNew.email, url, subject);
        //            return View("Zarejestrowano");
        //        }
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //    return View(userNew);
        //}
        #endregion
        #region New version
        [HttpPost]
        public ActionResult Register(string email, string firstname, string surname, string password)
        {
            LoginModel userNew = new LoginModel();
            try
            {
                if (ModelState.IsValid)
                {
                    userNew.email = email;
                    userNew.firstname = firstname;
                    userNew.surname = surname;
                    userNew.password = crypto.Hash(password);
                    userNew.active = false;
                    Guid guidPotwierdzenie = Guid.NewGuid();
                    userNew.guid = guidPotwierdzenie.ToString();
                    userNew.SaveToDataBase();

                    string url = System.Web.HttpRuntime.AppDomainAppVirtualPath + Url.Action("Aktywacja") + $"?kod={guidPotwierdzenie.ToString()}";
                    string subject = "Link aktywacyjny";

                    emailClass.CreateMailItem(userNew.email, url, subject);
                    return RedirectToAction("Registered", "Login");

                    //return View("Zarejestrowano");
                }
            }
            catch (Exception)
            {

                throw;
            }
            return View(userNew);
        }
        #endregion


     
       
      
        #region Wylogowanie
        public ActionResult Wylogowanie()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Logowanie", "Login");
        }
        #endregion


    }
}