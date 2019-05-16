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

        //// Register
        //[HttpGet]
        //public ActionResult register()
        //{
        //    Login user = new Login();
        //    return View(user);
        //}
    }
}