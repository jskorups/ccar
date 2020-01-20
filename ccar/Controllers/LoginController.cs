using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI;
using ccar.Models;

namespace ccar.Controllers
{
    public class LoginController : Controller
    {
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
            try
            {
                LoginModel mod = new LoginModel();
                if (model.password != model.confirmPassword)
                {
                    ModelState.AddModelError("confirmPassword", "Password not matched");
                    return View(model);
                }
                else if(mod.checkIfExistEmail(model.email))
                {
                    ModelState.AddModelError("email", "Email already exist");
                    return View(model);
                }
               else if (ModelState.IsValid)
                {                 
                    model.password = crypto.Hash(model.password);
                    model.active = false;
                    Guid guidPotwierdzenie = Guid.NewGuid();
                    model.guid = guidPotwierdzenie.ToString();
                    model.SaveToDataBase();
                    string url3 = HttpContext.Request.Url.AbsoluteUri;
                    string urlFinal = url3.Replace("Login/Register", "");
                    string url =urlFinal + Url.Action("Aktywacja") + $"?kod={guidPotwierdzenie.ToString()}";

                    string subjectMail = "CCAR activation link";
                    string path = Server.MapPath("~/Content/template/activationMailBody.html");
                    string body = System.IO.File.ReadAllText(path);
                    body = body.Replace("{link}", url);
                    emailClass.CreateMailItem(model.email, body, subjectMail);
                    return RedirectToAction("Registered", "Login");

                    //string subject = "Link aktywacyjny";
                    //emailClass.CreateMailItem(model.email, url, subject);


                    //return RedirectToAction("Registered");
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
        #region Aktywacja
        public ActionResult Aktywacja(string kod)
        {
            ccarEntities ent = new ccarEntities();
            var user = ent.users.Where(x => x.guid == kod).FirstOrDefault();
            if (user != null)
            {
                user.active = true;
                ent.SaveChanges();
                return View("Activation");
            }
            else
            {
                return View("ActivationFail");
            }
        }
        #endregion
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
            password = crypto.Hash(password);
            bool check = newlog.checkIfExist(email, password);
            if (check == true)
            {
                FormsAuthentication.SetAuthCookie(email, false);
                return RedirectToAction("Index", "Home");

            }
            else
            {
                ModelState.AddModelError("password", "Incorrect email or password.");
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
        #region Zarejestrowano
        [HttpGet]
        public ActionResult Registered()
        {
            return View();
        }
        #endregion
        #region Zmieniono hasło
        [HttpGet]
        public ActionResult PasswordChanged()
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
        public ActionResult RecoverPassword(PasswordResetModel model)
        {
            var exist = PasswordResetModel.checkIfemailExist(model.adresEmail);
            if (exist == true)
            {
                Guid nowyGuid = Guid.NewGuid();
                PasswordResetModel.setResetCode(model.adresEmail, nowyGuid.ToString());

              
                // przeslanie mailem

                string subjectMail = "CCAR recovery password code";
                string path = Server.MapPath("~/Content/template/guidMailBody.html");
                string body = System.IO.File.ReadAllText(path);



                body = body.Replace("{guid}", nowyGuid.ToString());
                emailClass.CreateMailItem(model.adresEmail, body, subjectMail);

                return RedirectToAction("GuidInput", model);
                //return View("GuidInput", model);
            }
            else
            {
                ModelState.AddModelError("adresEmail", "Email not found");
                //byc moze trzeba zmeinic atrybuty name  na widoku
                //return View("SetNewPassword", model);
                return View(model);
            }
        }
        [HttpGet]
        public ActionResult GuidInput(PasswordResetModel model)
        {
            return View(model);
        }

        [HttpGet]
        public ActionResult Breakdown()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GuidInput2(PasswordResetModel model)
        {

            bool check = PasswordResetModel.checkGuid(model.guid, model.adresEmail);
            if (check == true)
            {
                return View("SetNewPassword", model);
            }
            else
            {
                ModelState.AddModelError("guid", "Please input correct code.");
                return View("GuidInput", model);
            }
           
        }

        [HttpPost]
        public ActionResult SetNewPassword(PasswordResetModel model, string newPassword, string newPasswordConfirm)
        {
               
            if (newPassword != newPasswordConfirm) {
                ModelState.AddModelError("newPasswordConfirm", "Confirm password not matched");             
            }
            else if (string.IsNullOrEmpty(newPassword) )
            {
                ModelState.AddModelError("newPassword", "Please input new password.");
            }
            else if (string.IsNullOrEmpty(newPasswordConfirm))
            {
                ModelState.AddModelError("newPasswordConfirm", "Please input confirm password");
            }
            else if (newPassword == newPasswordConfirm)
            {
                PasswordResetModel.resetPassword(model.adresEmail, model.guid, newPasswordConfirm);
                return RedirectToAction("PasswordChanged");
            }
            return View("SetNewPassword", model);

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