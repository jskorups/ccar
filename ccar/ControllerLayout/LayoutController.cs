using ccar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ccar.ControllerLayout
{
    public class LayoutController : Controller
    {
        [Authorize]

        [HttpGet]
        public ActionResult Index()
        {

            return View();
        }

        [HttpGet]
        public ActionResult IndexLayoutDone()
        {

            return View();
        }

        [Authorize]


        // get list with not done
        [HttpGet]
        public ActionResult GetData()
        {
            using (ccarEntities ent = new ccarEntities())
            {
                List<actionLayoutView> actList = new List<actionLayoutView>();

                actList = ActionModel.fromLayoutActionsDB(ent.actionLayoutView.ToList());
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

        // post do add or edit
        [Authorize]
        [HttpPost]
        public ActionResult AddOrEdit(ActionModel Act)
        {
            if (Act.id == 0)
            {
                try
                {
                    Act.idReason = 26;
                    Act.Save();
                    var email = UserModel.getEmailAdress(Act.idResponsible);
                    //emailClass.CreateMailItem(email, "Bablabla", "sdjklhsljkdjflksdf");


                    string subjectMail = "CCAR new action created for your response";
                    string path = Server.MapPath("~/Content/template/newAction.html");
                    string body = System.IO.File.ReadAllText(path);
                    var dayName = System.DateTime.Now.DayOfWeek.ToString();
                    var timeSend = DateTime.Now.ToString("dd.MM.yy");

                    body = body.Replace("{d}", $"{dayName}, {timeSend}");
                    body = body.Replace("{Initiator}", ActionModel.getNameOfInitiator(Act.idInitiator));
                    body = body.Replace("{Reason}", ReasonModel.getNameOfReason(Act.idReason));
                    body = body.Replace("{Problem}", Act.problem);
                    body = body.Replace("{ToA}", Act.TypeOfAction);
                    body = body.Replace("{Responsible}", ResponsibleModel.getNameOfResponsible(Act.idResponsible));
                    body = body.Replace("{TargetDate}", Act.targetDate.ToString());

                    emailClass.CreateMailItem(email, body, subjectMail);
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


        public PartialViewResult EditDeletePartial(int id)
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

    }
}