using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ccar.ModelsLayout;

namespace ccar.ControllersLayout
{
    public class LayoutController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Index2()
        {

            return View();
        }

        // get list with not done
        [HttpGet]
        public ActionResult GetData()
        {
            using (ccarEntities ent = new ccarEntities())
            {
                List<actionLayoutView> actList = new List<actionLayoutView>();

                actList = LayoutModel.fromLayoutDB(ent.actionLayoutView.ToList());
                return Json(new { data = actList }, JsonRequestBehavior.AllowGet);
            }
        }
        // get list with done 100%
        [HttpGet]
        public ActionResult GetData2()
        {
            using (ccarEntities ent = new ccarEntities())
            {
                List<actionLayoutDoneView> actList = new List<actionLayoutDoneView>();

                actList = LayoutModel.fromLayoutDB2(ent.actionLayoutDoneView.ToList());
                return Json(new { data = actList }, JsonRequestBehavior.AllowGet);
            }
        }


        // get edit or add
        [HttpGet]
        [Authorize]
        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                return View(new LayoutModel());
            }
            else
            {
                ccarEntities ent = new ccarEntities();
                actionsLayout test = ent.actionsLayout.Where(x => x.Id == id).FirstOrDefault();
                return View(LayoutModel.ConvertFromEFtoModel(test));
            }
        }

        // get partial view for edit or delete
        public PartialViewResult EditDeletePartial(int id)
        {
            //odkomentowac
            //ccarEntities ent = new ccarEntities();
            //actions act = ent.actions.Where(x => x.id == id).FirstOrDefault();
            //return PartialView(act);

            ViewBag.id = id; // zakomentowac
            return PartialView();
        }
        public PartialViewResult EditDeletePartialDone(int id)
        {
            ViewBag.id = id;
            return PartialView();
        }


        // post do add or edit
        [Authorize]
        [HttpPost]
        public ActionResult AddOrEdit(LayoutModel lay)
        {
            if (lay.Id == 0)
            {
                try
                {
                    lay.Save();
                    //pobranie maila var email = UserModel.getEmailAdress(Act.idResponsible);
                    ////ewysyalnie maila
                }
                catch (Exception ex)
                {
                    return Json(new { succes = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
                }
            }
            else if (lay.Id != 0)
            {
                try
                {
                    lay.Save();
                }
                catch (Exception ex)
                {
                    return Json(new { succes = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
                }
            }

            return Json(new { succes = true, message = "Saved sucesfully" }, JsonRequestBehavior.AllowGet);
        }








    }
}
