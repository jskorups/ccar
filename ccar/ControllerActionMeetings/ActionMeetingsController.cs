using ccar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ccar.ControllerActionMeetings
{
    public class ActionMeetingsController : Controller
    {
        #region Index & GetData
        // GET: ActionMeetings
        public ActionResult Index()
        {
            return View();        
        }
        [HttpGet]
        public ActionResult GetData()
        {
            using (ccarEntities ent = new ccarEntities())
            {
                List<ActionMeetingsModel> actList = new List<ActionMeetingsModel>();
                //actList = ent.actionView.ToList();
                actList = ActionMeetingsModel.fromActions(ent.actionsMeetings.ToList());
                return Json(new { data = actList }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion
        #region Row Details
        // get details for row
        [HttpGet]
        public ActionResult RowDetailsPartial(int id)
        {
            ccarEntities ent = new ccarEntities();
            actionsMeetings rowDetail = ent.actionsMeetings.Where(x => x.id == id).FirstOrDefault();
            return View(ActionMeetingsModel.ConvertFromEFtoModel(rowDetail));
        }
        #endregion

        #region Add or Edit - GET
        // get edit or add
        [HttpGet]
        [Authorize]
        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                return View(new ActionMeetingsModel());
            }
            else
            {
                ccarEntities ent = new ccarEntities();
                actionsMeetings act = ent.actionsMeetings.Where(x => x.id == id).FirstOrDefault();
                return View(ActionMeetingsModel.ConvertFromEFtoModel(act));
            }
        }
        #endregion
        #region Add or Edit

        // post do add or edit
        [Authorize]
        [HttpPost]
        public ActionResult AddOrEdit(ActionMeetingsModel Act)
        {
            if (Act.id == 0)
            {
                //try
                //{
                    Act.Save();
                    
                //}
                //catch (Exception ex)
                //{
                //    return Json(new { succes = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
                //}
            }
            //else if (Act.id != 0)
            //{
            //    try
            //    {
            //        Act.Save();

            //    }
            //    catch (Exception ex)
            //    {
            //        return Json(new { succes = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            //    }
            //}

            return Json(new { succes = true, message = "Saved sucesfully" }, JsonRequestBehavior.AllowGet);
        }


        #endregion
    }
}