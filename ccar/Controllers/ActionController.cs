using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ccar.Models;

namespace ccar.Controllers
{
    public class ActionController : Controller
    {
        [Authorize]


        [HttpGet]
        public ActionResult ProjectsIndex()
        {

            return View();
        }


        [HttpGet]
        public ActionResult Index()
        {

            return View();
        }

        [HttpGet]
        public ActionResult GeneralDone(int? id)
        {
            GeneralModel mod = new GeneralModel();
            mod.Id = id;
            return View(mod);
        }
        [HttpGet]
        //[Authorize(Roles = "user")]
        public ActionResult General(int? id)
        {
            GeneralModel mod = new GeneralModel();
            mod.Id = id;
            return View(mod);
        }

        [Authorize]

        // get list with not done
        [HttpGet]
        public ActionResult GetData(int? id)
        {
            using (ccarEntities ent = new ccarEntities())
            {
                List<actionView> actList = new List<actionView>();

                if (id != null)
                {
                    actList = ActionModel.fromActionsDB(ent.actionView.Where(x => x.idReason == id).ToList());
                }
                else
                {
                    actList = ActionModel.fromActionsDB(ent.actionView.ToList());
                }
                return Json(new { data = actList }, JsonRequestBehavior.AllowGet);
            }
        }
        // get list with done 100%
        [HttpGet]
        public ActionResult GetData2(int? id)
        {
            using (ccarEntities ent = new ccarEntities())
            {
                List<actionViewDone> actList = new List<actionViewDone>();

                if (id != null)
                {
                    actList = ActionModel.fromActionsDB2(ent.actionViewDone.Where(x => x.idReason == id).ToList());
                }
                else
                {
                    actList = ActionModel.fromActionsDB2(ent.actionViewDone.ToList());
                }
           
                return Json(new { data = actList }, JsonRequestBehavior.AllowGet);

            }
        }
        // get edit or add
        [HttpGet]
        [Authorize]
        public ActionResult AddOrEdit(int? idReas, bool? showReas, int id = 0)
        {
            if (id == 0)
            {
                ActionModel act = new ActionModel();
               
                act.showReas = showReas;
                act.idReason = idReas;
                return View(act);
            }
            else
            {
                ccarEntities ent = new ccarEntities();
                actions test = ent.actions.Where(x => x.id == id).FirstOrDefault();
                ActionModel act = ActionModel.ConvertFromEFtoModel(test);
                act.idReason = idReas;
                act.showReas = showReas;
                return View(act);
            }
        }
        // get partial view for edit or delete
        public PartialViewResult EditDeletePartial(int id)
        {
            //odkomentowac
            ccarEntities ent = new ccarEntities();
            actions act = ent.actions.Where(x => x.id == id).FirstOrDefault();
            return PartialView(act);

            //ViewBag.id = id; // zakomentowac
            //return PartialView();
        }
        public PartialViewResult EditDeletePartialDone(int id)
        {
            ViewBag.id = id;
            return PartialView();
        }
        // get details for row
        [HttpGet]
        public ActionResult RowDetailsPartial(int id)
        {
            ccarEntities ent = new ccarEntities();
            actions rowDetail = ent.actions.Where(x => x.id == id).FirstOrDefault();
            return View(ActionModel.ConvertFromEFtoModel(rowDetail));
        }
        // post do add or edit
        [Authorize]
        [HttpPost]
        public ActionResult AddOrEdit(ActionModel Act)
        {

            if (Act.id == 0)
            {    
                Act.Save();
               // send email         
                emailClass.CreateNewMailItem(Act, "CCAR - new action");        
                return Json(new { succes = true, message = "Saved sucessfully" }, JsonRequestBehavior.AllowGet);


            }
            else if (Act.id != 0)
            {
                ccarEntities ent = new ccarEntities();

                var ifReasonExist = ent.reasons.Any(x => x.reason == Act.Reason);
                if (ifReasonExist == false)
                {
                    return Json(new { succes = false, message = "Reason not exist" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    Act.Save();
                    // send mail           
                    emailClass.CreateNewMailItem(Act, "CCAR - your action has been edited");
                    return Json(new { succes = true, message = "Saved sucessfully" }, JsonRequestBehavior.AllowGet);
                }
            }
            return Json(new { succes = false, message = "Something went wrong" }, JsonRequestBehavior.AllowGet);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Delete(int id)
        {
            ccarEntities ent = new ccarEntities();
            actions act = ent.actions.Find(id);
            ent.actions.Remove(act);
            ent.SaveChanges();
            return Json(new { succes = true, message = "Delete Sucessfully" }, JsonRequestBehavior.AllowGet);
        }
    }

    public class GeneralModel
    {
        public int? Id { get; set; }
        //public bool showReason { get; set; }
    }
}