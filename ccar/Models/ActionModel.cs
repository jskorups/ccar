﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ccar.Models;
using System.Web.Security;
using System.Data.Entity;
using System.Globalization;
using System.Threading;

namespace ccar.Models
{
    public class ActionModel
    {


        // 1:1 from DB
        public int id { get; set; }

        [Range(1, float.MaxValue, ErrorMessage = "Required")]
        public int? idReason { get; set; }
        public string Reason { get; set; }
        public int? idInitiator { get; set; }
        public string Initiator { get; set; }

        [DataType(DataType.Date)]
        public DateTime originationDate { get; set; }

        [Range(1, float.MaxValue, ErrorMessage = "Required")]
        public int? idTypeOfAction { get; set; }

        public string TypeOfAction { get { return GetTypeOfAction(this.idTypeOfAction.Value); } }

        [Required(ErrorMessage = "Required")]
        [StringLength(30, ErrorMessage ="Maximum 30 characters.")]
        public string problem { get; set; }


        //[Required(ErrorMessage = "Required")]
        [StringLength(300, ErrorMessage = "Maximum 500 characters.")]
        public string problemLong { get; set; }

        //[Required(ErrorMessage = "Required")]
        [StringLength(500, ErrorMessage = "Maximum 500 characters.")]
        public string rootCause { get; set; }

        //[Required(ErrorMessage = "Required")]
        [StringLength(500, ErrorMessage = "Maximum 500 characters.")]
        public string correctiveAction { get; set; }

        [Range(1, float.MaxValue, ErrorMessage = "Required")]
        public int? idResponsible { get; set; }

        [Required(ErrorMessage = "Required")]
        public string Responsible { get; set; }



        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Required")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? targetDate { get; set; }

        [Range(1, float.MaxValue, ErrorMessage = "Required")]
        public int? idProgress { get; set; }
        [DataType(DataType.Date)]
        public DateTime? completionDate { get; set; }

      
        public string measureEffic { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Required")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? dateOfEffic { get; set; }

        public int? Status { get; set; }

        public string AttendanceList { get; set; }

        public bool? showReas { get; set; }

        // ------------------------------------------------------//

        public string GetTypeOfAction(int id)
        {
            ccarEntities ent = new ccarEntities();
            string toa = ent.typeOfaction.Where(x => x.id == id).Select(x => x.typeOfaction1).SingleOrDefault();
            return toa;
        }

        public static DateTime getDate(DateTime kok)
        {
            kok = DateTime.Now;
            var date = kok.Date;
            return date;
        }

        #region ACTION VIEW BASE 
        // ACTIONVIEW BASE

        public static List<actionView> fromActionsDB(List<actionView> aList)
        {
            List<actionView> actionList = aList.Select(x => new actionView()
            {
                id = x.id,
                reason = x.reason,
                problem = x.problem,
                Initiator = x.Initiator,
                originationDate = x.originationDate,
                /*rootCause = x.rootCause, correctiveAction = x.correctiveAction,*/
                targetDate = x.targetDate,
                completionDate = x.completionDate,
                responsible = x.responsible,
                progressValue = x.progressValue,
                Status = x.Status
                /*, measureEffic = x.measureEffic , dateOfEffic = x.dateOfEffic*/
                
            }).ToList();
            return actionList;
        }
        #endregion
        #region ACTIONVIEW DONE (100%) BASE
        // ACTIONVIEW DONE (100%) BASE
        public static List<actionViewDone> fromActionsDB2(List<actionViewDone> aList)
        {
            List<actionViewDone> actionList = aList.Select(x => new actionViewDone()
            {
                id = x.id,
                Initiator = x.Initiator,
                reason = x.reason,
                problem = x.problem,
                originationDate = x.originationDate,
                /*rootCause = x.rootCause, correctiveAction = x.correctiveAction,*/
                targetDate = x.targetDate,
                completionDate = x.completionDate,
                responsible = x.responsible,
                progressValue = x.progressValue,
                Status = x.Status
                /*, measureEffic = x.measureEffic , dateOfEffic = x.dateOfEffic*/
            }).ToList();
            return actionList;
        }
        #endregion

        #region LAYOUT ACTION VIEW BASE 
        // ACTIONVIEW BASE

        public static List<actionLayoutView> fromLayoutActionsDB(List<actionLayoutView> aList)
        {
            List<actionLayoutView> actionList = aList.Select(x => new actionLayoutView()
            {
                id = x.id,
                reason = x.reason,
                problem = x.problem,
                Initiator = x.Initiator,
                originationDate = x.originationDate,
                /*rootCause = x.rootCause, correctiveAction = x.correctiveAction,*/
                targetDate = x.targetDate,
                completionDate = x.completionDate,
                responsible = x.responsible,
                progressValue = x.progressValue,
                /*, measureEffic = x.measureEffic , dateOfEffic = x.dateOfEffic*/
               Status = x.Status
            }).ToList();
            return actionList;
        }
        #endregion
        #region  LAYOUT ACTIONVIEW DONE (100%) BASE
        // ACTIONVIEW DONE (100%) BASE
        public static List<actionViewDone> fromLayoutActionsDB2(List<actionViewDone> aList)
        {
            List<actionViewDone> actionList = aList.Select(x => new actionViewDone()
            {
                id = x.id,
                Initiator = x.Initiator,
                reason = x.reason,
                problem = x.problem,
                originationDate = x.originationDate,
                /*rootCause = x.rootCause, correctiveAction = x.correctiveAction,*/
                targetDate = x.targetDate,
                completionDate = x.completionDate,
                responsible = x.responsible,
                progressValue = x.progressValue,
                Status = x.Status
                /*, measureEffic = x.measureEffic , dateOfEffic = x.dateOfEffic*/
            }).ToList();
            return actionList;
        }
        #endregion


        //public static List<actionViewCustom> fromLayoutActionsCustomDB(List<actionViewCustom> aList)
        //{
        //    List<actionViewCustom> actionList = aList.Select(x => new actionViewCustom()
        //    {
        //        id = x.id,
        //        reason = x.reason,
        //        problem = x.problem,
        //        Initiator = x.Initiator,
        //        originationDate = x.originationDate,
        //        /*rootCause = x.rootCause, correctiveAction = x.correctiveAction,*/
        //        targetDate = x.targetDate,
        //        completionDate = x.completionDate,
        //        responsible = x.responsible,
        //        progressValue = x.progressValue,
        //        /*, measureEffic = x.measureEffic , dateOfEffic = x.dateOfEffic*/
        //        Status = x.Status
        //    }).ToList();
        //    return actionList;
        //}

        public static actions ConvertToActionsFromDb(ActionModel a)
        {
            ccarEntities ent = new ccarEntities();

            actions act = new actions();
            act.id = a.id;
         
            if (a.Reason == null)
            {
                act.idReason = a.idReason;
            }
            else
            {
                act.idReason = ent.reasons.Where(x => x.reason == a.Reason).Select(x => x.id).FirstOrDefault();
            }
          

            act.idInitiator = a.idInitiator;
            act.Initiator = a.Initiator;
            act.originationDate = a.originationDate;
            act.idTypeOfAction = a.idTypeOfAction;
            act.problem = a.problem;
            act.problemLong = a.problemLong;
            act.rootCause = a.rootCause;
            act.correctiveAction = a.correctiveAction;
            //act.idResponsible = a.idResponsible;
            act.idResponsible = ent.responsibles.Where(x => (x.FirstName+" "+ x.Lastname) == a.Responsible).Select(x => x.id).FirstOrDefault();
            act.targetDate = a.targetDate;
            act.idProgress = a.idProgress;
            act.completionDate = a.completionDate;
            act.measureEffic = a.measureEffic;
            act.dateOfEffic = a.dateOfEffic;
            act.Status = a.Status;
            return act;
        }

        public static ActionModel ConvertFromEFtoModel(actions a)
        {
            ccarEntities ent = new ccarEntities();

            ActionModel act = new ActionModel();
            act.id = a.id;
            //act.idReason = a.idReason;
            act.Reason = ent.reasons.Where(x => x.id == a.idReason).Select(x => x.reason).FirstOrDefault();
            act.idInitiator = a.idInitiator;
            act.Initiator = a.Initiator;
            act.originationDate =  a.originationDate;
            act.idTypeOfAction = a.idTypeOfAction;
            act.problem = a.problem;
            act.problemLong = a.problemLong;
            act.rootCause = a.rootCause;
            act.correctiveAction = a.correctiveAction;
            //act.idResponsible = a.idResponsible;
            act.Responsible = ent.responsibles.Where(x => x.id == a.idResponsible).Select(x => (x.FirstName + " " + x.Lastname)).FirstOrDefault();
            act.targetDate = a.targetDate;
            act.idProgress = a.idProgress;
            act.completionDate = a.completionDate;
            act.measureEffic = a.measureEffic;
            act.dateOfEffic = a.dateOfEffic;
            act.Status = a.Status;
            

          
            act.AttendanceList = ent.actionsMeetings.Where(x => x.idReason == a.idReason && x.originationDate == a.originationDate).Select(x => x.attendanceList).FirstOrDefault();
            return act;
        }

    


        public static string getNameOfInitiator(int? inititiatorId)
        {
            ccarEntities ent = new ccarEntities();
            var xo = ent.users.Where(x => x.id == inititiatorId).FirstOrDefault();
            if (xo != null)
            {
                return xo.firstname + " " + xo.surname;
            }
            else
            {
                return "";
            }

        }


        public void Save()
        {
            if (this.id == 0)
            {
                ccarEntities ent = new ccarEntities();
                this.idInitiator = ent.users.Where(x => x.email == System.Web.HttpContext.Current.User.Identity.Name).Select(x => x.id).SingleOrDefault();
                this.originationDate = DateTime.Now;
                this.Status = 0;
                string Replaced = System.Environment.UserName.Replace('.', ' ');
                CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
                TextInfo textInfo = cultureInfo.TextInfo;
                this.originationDate = DateTime.Now;
                actions act = new actions();
                act = ActionModel.ConvertToActionsFromDb(this);            
                ent.actions.Add(act);             
                ent.SaveChanges();


            }
            else
            {
                ccarEntities ent = new ccarEntities();

                if (ProgressModel.getIdByName("100%") == idProgress)
                {
                    this.Status = 1;
                    this.completionDate = DateTime.Now;
                }
                //string Replaced = System.Environment.UserName.Replace('.', ' ');
                //CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
                //TextInfo textInfo = cultureInfo.TextInfo;

                //this.Initiator = (textInfo.ToTitleCase(Replaced));

                ent.Entry(ActionModel.ConvertToActionsFromDb(this)).State = EntityState.Modified;
                    ent.SaveChanges();

                }
            }

        }
    }
