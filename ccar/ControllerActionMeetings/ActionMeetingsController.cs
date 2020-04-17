using ccar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ccar.ControllerActionMeetings
{
    public class ActionMeetingsController : Controller
    {


        //public JsonResult InsertCustomers(List<Customer> customers)
        //{
        //    using (ccarEntities entities = new ccarEntities())
        //    {
        //        //Truncate Table to delete all old records.
        //        //entities.Database.ExecuteSqlCommand("TRUNCATE TABLE [Customers]");

        //        //Check for NULL.
        //        if (customers == null)
        //        {
        //            customers = new List<Customer>();
        //        }

        //        //Loop and insert records.
        //        foreach (Customer customer in customers)
        //        {
        //            entities.Customers.Add(customer);
        //        }
        //        int insertedRecords = entities.SaveChanges();
        //        return Json(insertedRecords);
        //    }
        //}
        #region probranie i wyfiltrowanie juz wuybranych uzytkowników
        [HttpGet]
        public ActionResult GetRowOfUsers(List<int> wybrane)
        {

            AttendanceUserRowModel AttUser = new AttendanceUserRowModel();
            ccarEntities ent = new ccarEntities();


            wybrane = wybrane ?? new List<int>();

            AttUser.UsersList = ent.users.Where(x => !wybrane.Contains(x.id)).Select(x => new SelectListItem
            {
                Text = x.firstname + " " + x.surname,
                Value = x.id.ToString(),

            }).ToList();


            return PartialView(AttUser);

            #region stara wersja
            //if (wybrane == null)
            //{
            //    AttUser.UsersList = ent.users.Select(x => new SelectListItem
            //    {
            //        Text = x.firstname + " " + x.surname,
            //        Value = x.id.ToString(),

            //    }).ToList();
            //}
            //else
            //{

            //    var us = ent.users.Select(x => x.id).ToList();
            //    var filtered = us.Except(wybrane);

            //    AttUser.UsersList = ent.users.Where(t => filtered.Contains(t.id)).Select(x => new SelectListItem
            //    {
            //        Text = x.firstname + " " + x.surname,
            //        Value = x.id.ToString(),

            //    }).ToList();
            //}
            #endregion

        }
        #endregion
        #region pobranie listwy obecnosci do wyswietlenia w detalach akcji
        [HttpGet]
        public ActionResult GetRowOfAttendanceList(int id)
        {
            AttendanceListRowModel AttList = new AttendanceListRowModel();
            ccarEntities ent = new ccarEntities();

            var query = from atm in ent.AttendanceMeetings
                        join am in ent.actionsMeetings on atm.MeetingId equals am.id
                        join u in ent.users on atm.UserId equals u.id
                        where am.id == id
                        select u.firstname + " " + u.surname + " ";
            //{
            //    name = u.firstname + " " + u.surname +" " + System.Environment.NewLine

            //};

            AttList.AttendanceListByID = query.ToList();
            return PartialView(AttList);
        }
        #endregion
        #region index & GetData
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
                actList = ActionMeetingsModel.fromActions(ent.actionsMeetings.Where(x => x.idReason == id).ToList());

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
        #region row details
        // get details for row
        //[HttpGet]
        //public ActionResult RowDetailsPartial(int id)
        //{
        //    ccarEntities ent = new ccarEntities();
        //    actionsMeetings rowDetail = ent.actionsMeetings.Where(x => x.id == id).FirstOrDefault();
        //    return View(ActionMeetingsModel.ConvertFromEFtoModel(rowDetail));
        //}
        #endregion
        #region add - GET
        // get edit or add
        [HttpGet]
        [Authorize]
        public ActionResult AddOrEdit(int id = 0)
        {
            //if (id == 0)
            //{
                return View(new ActionMeetingsModel());
            //}
            //else
            //{
            //    ccarEntities ent = new ccarEntities();
            //    actionsMeetings act = ent.actionsMeetings.Where(x => x.id == id).FirstOrDefault();
            //    return View(ActionMeetingsModel.ConvertFromEFtoModel(act));
            //}
        }
        #endregion
        #region edit Meeting - GET

        [HttpGet]
        public ActionResult Edit(int id)
        {
            ccarEntities ent = new ccarEntities();
            //EditMeetingModel eMod = new EditMeetingModel();
            var eMod = ent.actionsMeetings.Where(x => x.id == id).Select(x => new EditMeetingModel
            {
                //idReas = x.idReason,
                
                Reas = x.reasons.reason,
                AttendanceIds = x.AttendanceMeetings.Select(u => u.UserId).ToList(),
            }
            ).Single();
            eMod.reasonList = ent.reasons.Select(x => new SelectListItem
            {
                Text = x.reason,
                Value = x.id.ToString()
            }).ToList();

            eMod.usersList = ent.users.Select(x => new SelectListItem
            {
                Text = x.firstname + " " + x.surname,
                Value = x.id.ToString(),

            }).ToList();
            return View(eMod);
        }
        /* w get przychodzi id
         1. Stworz nowy model do edycji

            - dwie wlasciowsci
            - IENUM  - wybrni uzyytkownicy
            - SelectList z uzytkownikami do wyboru

          2. Na widoku

            foreach
            - ienum od intow
            - Html.Dropdown("ListaWybranychUzytkownikow", Model.SelectList, userId)

            3. Usunac liste starych uzytkownikow bez wzgledu na zmiane
            4. Dodac nowa liste
            -
        */
        #endregion
        #region old addoredit
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
        #endregion
        #region edit Meeting - POST
        [HttpPost]
        public ActionResult Edit(EditMeetingModel mod, int id)
        {
            try
            {
                ccarEntities ent = new ccarEntities();
                var x = ent.AttendanceMeetings.Where(m => m.MeetingId == id).ToList();
                ent.AttendanceMeetings.RemoveRange(x);
           
                foreach (var attendanceId in mod.AttendanceIds)
                {
                    AttendanceMeetings newMod = new AttendanceMeetings();
                    newMod.MeetingId = id;
                    newMod.UserId = attendanceId;
                    ent.AttendanceMeetings.Add(newMod);
                }
                ent.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }


            return Json(new { succes = true, message = "Saved sucesfully" }, JsonRequestBehavior.AllowGet);
            //ent.AttendanceMeetings.Select
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