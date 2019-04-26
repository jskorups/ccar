using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ccar.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Session["date"] = DateTime.Now.ToShortDateString();
            return View();
        }

        public ActionResult About()
        {
     
            return View();
        }

        public PartialViewResult Test()
        {
          
            return PartialView();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}