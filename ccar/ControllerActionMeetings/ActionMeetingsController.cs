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

        // GET: Projects
        public ActionResult General(int? id)
        {
            GeneralModel mod = new GeneralModel();
            mod.Id = id;
            return View(mod);
        }


        [HttpGet]
        public ActionResult GetData(int? id)
        {
            using (ccarEntities ent = new ccarEntities())
            {
                List<ActionMeetingsModel> actList = new List<ActionMeetingsModel>();
                //actList = ent.actionView.ToList();
                actList = ActionMeetingsModel.fromActions(ent.actionsMeetings.Where(x=>x.idReason == id).ToList());
          

           
                if (id != null)
                {
                    actList = ActionMeetingsModel.fromActions(ent.actionsMeetings.Where(x => x.idReason == id).ToList());
                }
                else
                {
                    actList = ActionMeetingsModel.fromActions(ent.actionsMeetings.ToList());
                }

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
        #region Add or Edit - POST

        // post do add or edit
        [Authorize]
        [HttpPost]
        public ActionResult AddOrEdit(ActionMeetingsModel Act)
        {
     
          //Act.Save();
          //return Json(new { succes = false }, JsonRequestBehavior.AllowGet);

            if (Act.id == 0)
            {
                try
                {
                    Act.Save();
                   
                }
                catch (Exception ex)
                {
                    return Json(new { succes = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
                }
            }
            else if (Act.id != 0)
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

            return Json(new { succes = true, message = "Saved sucesfully" }, JsonRequestBehavior.AllowGet);



        }


        #endregion

        #region  PartialView - Edit/Delete
        // get partial view for edit or delete
        public PartialViewResult EditDeletePartial(int id)
        {
            //odkomentowac
            //ccarEntities ent = new ccarEntities();
            //actionsMeetings act = ent.actionsMeetings.Where(x => x.id == id).FirstOrDefault();
            //return PartialView(act);

            ViewBag.id = id; // zakomentowac
            return PartialView();
        }
        #endregion
        #region Delete
        [Authorize]
        [HttpPost]
        public ActionResult Delete(int id)
        {
            ccarEntities ent = new ccarEntities();
            actionsMeetings act = ent.actionsMeetings.Find(id);
            ent.actionsMeetings.Remove(act);
            ent.SaveChanges();
            return Json(new { succes = true, message = "Delete Sucessfully" }, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }

    public class GeneralModel
    {
        public int? Id { get; set; }
    }


}