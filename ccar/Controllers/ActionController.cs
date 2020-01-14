using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ccar.Models;
using System.Data.Entity;
using System.Web.Security;
using System.Text;

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
        public ActionResult GeneralDone()
        {

            return View();
        }


        [HttpGet]
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
                //actList = ent.actionView.ToList();
                //actList = ActionModel.fromActionsDB(ent.actionView.ToList());
                


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
        public ActionResult GetData2()
        {
            using (ccarEntities ent = new ccarEntities())
            {
                List<actionViewDone> actList = new List<actionViewDone>();

                actList = ActionModel.fromActionsDB2(ent.actionViewDone.ToList());
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
                return View(new ActionModel());
            }
            else
            {
                ccarEntities ent = new ccarEntities();
                actions test = ent.actions.Where(x => x.id == id).FirstOrDefault();
                return View(ActionModel.ConvertFromEFtoModel(test));
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

        // get details for row
        [HttpGet]
        public ActionResult RowDetailsPartial (int id)
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
                try
                {
                    Act.Save();
                    #region Sending mail
                    var email = UserModel.getEmailAdress(Act.idResponsible);               
                    //emailClass.CreateMailItem(email, "Bablabla", "sdjklhsljkdjflksdf");


                    string subjectMail = "CCAR new action created for your response";
                    string path = Server.MapPath("~/Content/template/newAction.html");
                    string body = System.IO.File.ReadAllText(path);
                    var dayName = System.DateTime.Now.DayOfWeek.ToString();
                    var timeSend = DateTime.Now.ToString("dd.MM.yy");

                    body = body.Replace("{d}",$"{dayName}, {timeSend}");
                    body = body.Replace("{Initiator}", ActionModel.getNameOfInitiator(Act.idInitiator));
                    body = body.Replace("{Reason}", ReasonModel.getNameOfReason(Act.idReason));
                    body = body.Replace("{Problem}", Act.problem);
                    body = body.Replace("{ToA}", Act.TypeOfAction);
                    body = body.Replace("{Responsible}", ResponsibleModel.getNameOfResponsible(Act.idResponsible));
                    body = body.Replace("{TargetDate}", Act.targetDate.ToString());
                    body = body.Replace("{ProLong}", Act.problemLong.ToString());

                    emailClass.CreateMailItem(email, body, subjectMail);
                    #endregion
                }
                catch (Exception ex)
                {
                    return Json(new { succes = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
                }
            }
            else if (Act.id != 0)
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
           
            return Json(new { succes = true, message = "Saved sucesfully" }, JsonRequestBehavior.AllowGet);
        }      
        [Authorize]
        [HttpPost]
        public ActionResult Delete (int id)
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
    }



}