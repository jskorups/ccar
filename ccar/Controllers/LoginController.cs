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
        #region Old version
        [HttpPost]
        public ActionResult Register(Login userNew)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    userNew.active = false;
                    Guid guidPotwierdzenie = Guid.NewGuid();
                    userNew.guid = guidPotwierdzenie.ToString();
                    userNew.SaveToDataBase();

                    string url = System.Web.HttpRuntime.AppDomainAppVirtualPath + Url.Action("Aktywacja") + $"?kod={guidPotwierdzenie.ToString()}";
                    string subject = "Link aktywacyjny";

                    emailClass.sendMail(userNew.email, url, subject);
                    return View("Zarejestrowano");
                }
            }
            catch (Exception)
            {

                throw;
            }
            return View(userNew);
        }
        #endregion
        #region New version
        //[HttpPost]
        //public ActionResult Register(string email, string firstname, string surname, string password)
        //{
        //    Login userNew = new Login();
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            userNew.email = email;
        //            userNew.firstname = firstname;
        //            userNew.surname = surname;
        //            userNew.password = crypto.Hash(password);
        //            userNew.active = false;
        //            Guid guidPotwierdzenie = Guid.NewGuid();
        //            userNew.guid = guidPotwierdzenie.ToString();
        //            userNew.SaveToDataBase();

        //            string url = System.Web.HttpRuntime.AppDomainAppVirtualPath + Url.action("Aktywacja") + $"?kod={guidPotwierdzenie.ToString()}";
        //            string subject = "Link aktywacyjny";

        //            emailClass.sendMail(userNew.email, url, subject);
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

        #endregion
        #region Logowanie
        //Logowanie
        [HttpGet]
        public ActionResult Logowanie()
        {
          
            return View();
        }
        [HttpPost]
        public ActionResult Logowanie(string email, string password)
        {
            Login newlog = new Login();        
            //zakryptowac haslo
            bool check = newlog.checkIfExist(email, password);
            if (check == true)
            {
                FormsAuthentication.SetAuthCookie(email, false);
                return RedirectToAction("Index", "Action");
                
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