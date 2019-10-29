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
        #region Logowanie 
        //  Logowanie
        public ActionResult Logowanie()
        {
            LoginModel model = new LoginModel();
            return View(model);
        }
        [HttpPost]
        public ActionResult Logowanie(string email, string password)
        {
            LoginModel newlog = new LoginModel();
            //password = crypto.Hash(password);
            bool check = newlog.checkIfExist(email, password);
            if (check == true)
            {         
                FormsAuthentication.SetAuthCookie(email, false);
                return RedirectToAction("Index", "Home");

            }
            else
            {
                ModelState.AddModelError("email", "Nie znaleziono użytkownika");                       
                return View();
            }
        }
        #endregion
        #region Wylogowanie
        public ActionResult Wylogowanie()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Logowanie", "Login");
        }
        #endregion
        #region Rejestracja
        [HttpGet]
        public ActionResult Register()
        {
            LoginModel user = new LoginModel();
            return View(user);
        }
        [HttpPost]
        public ActionResult Register(LoginModel model)
        {
            // w parametrach przesłac model
            //
            try
            {
                if (model.password != model.confirmPassword)
                {
                    ModelState.AddModelError("confirmPassword", "Password not matched");
                }
                if (ModelState.IsValid)
                {
                    //userNew.email = email;
                    //userNew.firstname = firstname;
                    //userNew.surname = surname;
                    model.password = crypto.Hash(model.password);
                    model.active = false;
                    Guid guidPotwierdzenie = Guid.NewGuid();
                    model.guid = guidPotwierdzenie.ToString();
                    model.SaveToDataBase();

                    string url = System.Web.HttpRuntime.AppDomainAppVirtualPath + Url.Action("Aktywacja") + $"?kod={guidPotwierdzenie.ToString()}";
                    string subject = "Link aktywacyjny";

                    emailClass.CreateMailItem(model.email, url, subject);
                    //return RedirectToAction("Registered", "Login");


                    return RedirectToAction("Zarejestrowano");

                }
                else
                {
                    return View(model);
                }
            }
            catch (Exception)
            {

                throw;
            }

            //return View(userNew);
        }
        #endregion
        #region Zarejestrowano
        [HttpGet]
        public ActionResult Zarejestrowano()
        {
            return View();
        }
        #endregion
        #region Password Recovery
        [HttpGet]
        public ActionResult RecoverPassword()
        {
            PasswordResetModel prMod = new PasswordResetModel();
            return View(prMod);
        }


        [HttpPost]
        public ActionResult GenerateGuidForEmail(PasswordResetModel model)
        {
            var exist = PasswordResetModel.checkIfemailExist(model.adresEmail);
            if (exist == true)
            {
                Guid nowyGuid = Guid.NewGuid();
                PasswordResetModel.setResetCode(model.adresEmail, nowyGuid.ToString());
                // przeslanie mailem

                string subjectMail = "Twoj kod resetujacy haslo to:";
                string path = HttpContext.Server.MapPath("~/Content/template/guidMailBody.html");
                string body = System.IO.File.ReadAllText(path);
                body = body.Replace("{guid}", nowyGuid.ToString());
                emailClass.CreateMailItem(model.adresEmail, body, subjectMail);

                return View("GuidInput", model);
            }
            else 
            {
                ModelState.AddModelError("adresEmail", "Email not found");
                //byc moze trzeba zmeinic atrybuty name  na widoku
                //return View("SetNewPassword", model);
                return RedirectToAction("RecoverPassword");
            }

           
        }

        [HttpPost]
        public ActionResult AkceptacjaGuidu(PasswordResetModel model)
        {

            bool check = PasswordResetModel.checkGuid(model.guid, model.adresEmail);
            if (check == true)
            {
                return View("SetNewPassword", model);
            }
            return View("GuidInput", model);
        }

        [HttpPost]
        public ActionResult SetNewPassword(PasswordResetModel model, string newPassword, string newPasswordConfirm)
        { 
                PasswordResetModel.resetPassword(model.adresEmail, model.guid, newPasswordConfirm);
                return RedirectToAction("Logowanie");
                 
        }

        #endregion
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








    }
}