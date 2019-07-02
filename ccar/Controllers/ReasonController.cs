using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ccar.Controllers
{
    public class ReasonController : Controller
    {
        [HttpGet]
        public ActionResult AddOrEditRsn()
        {
            return View();
        }
    }
}
