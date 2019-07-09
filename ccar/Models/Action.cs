﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ccar.Models;
using System.Web.Security;
using System.Data.Entity;


namespace ccar.Models
{
    public class action
    {


        // 1:1 from DB
        public int id { get; set; }
        [Required(ErrorMessage = "This Field is Required")]
        public int idReason { get; set; }
        public string Reason { get; set; }
        public int? idInitiator { get; set; }

        [DataType(DataType.Date)]
        public DateTime? originationDate { get; set; }
        public int? idTypeOfAction { get; set; }

        [Required(ErrorMessage = "Please enter problem")]
        public string problem { get; set; }
        public string rootCause { get; set; }
        public string correctiveAction { get; set; }
        public int? idResponsible { get; set; }
        [DataType(DataType.Date)]
        public DateTime? targetDate { get; set; }
        public int? idProgress { get; set; }
        [DataType(DataType.Date)]
        public DateTime? completionDate { get; set; }
        public string measureEffic { get; set; }
        public string dateOfEffic { get; set; }



        public static List<actionView> fromActionsDB(List<actionView> aList)
        {
            List<actionView> actionList = aList.Select(x => new actionView()
            {
                id = x.id,
                initiator = x.initiator,
                reason = x.reason,
                problem = x.problem,
                originationDate = x.originationDate,
                /*rootCause = x.rootCause, correctiveAction = x.correctiveAction,*/
                targetDate = x.targetDate,
                completionDate = x.completionDate,
                responsible = x.responsible,
                progressValue = x.progressValue
                /*, measureEffic = x.measureEffic , dateOfEffic = x.dateOfEffic*/
            }).ToList();
            return actionList;



        }
        //public Komputer(komputery comps)
        //{
        //    Firma = comps.firma;
        //    Dostawca = comps.dostawca;
        //    UzytkownikId = comps.uzykownikId;
        //    Id = comps.komputerId;
        //}

        //// saveToDatabase
        //public void saveToDatabase()
        //{
        //    ccarEntities ent = new ccarEntities();
        //    action newAction = new action();
        //    newAction.id = id;
        //    newAction.idReason = idReason;
        //    //newAction.idInitiator
        //}


        public static actions ConvertToActionsFromDb(action a)
        {
            actions act = new actions();
            act.id = a.id;
            act.idReason = a.idReason;
            act.idInitiator = a.idInitiator;
            act.originationDate = a.originationDate;
            act.idTypeOfAction = a.idTypeOfAction;
            act.problem = a.problem;
            act.rootCause = a.rootCause;
            act.correctiveAction = a.correctiveAction;
            act.idResponsible = a.idResponsible;
            act.targetDate = a.targetDate;
            act.idProgress = a.idProgress;
            act.completionDate = a.completionDate;
            act.measureEffic = a.measureEffic;
            act.dateOfEffic = a.dateOfEffic;
            return act;
        }

        public static action ConvertFromEFtoModel(actions a)
        {
   

            action act = new action();
            act.id = a.id;
            act.idReason = a.idReason;
            act.idInitiator = a.idInitiator;
            act.originationDate = a.originationDate;
            act.idTypeOfAction = a.idTypeOfAction;
            act.problem = a.problem;
            act.rootCause = a.rootCause;
            act.correctiveAction = a.correctiveAction;
            act.idResponsible = a.idResponsible;
            act.targetDate = a.targetDate;
            act.idProgress = a.idProgress;
            act.completionDate = a.completionDate;
            act.measureEffic = a.measureEffic;
            act.dateOfEffic = a.dateOfEffic;
            return act;
        }

        public void Save()
        {
            if (this.id == 0)
            {

                ccarEntities ent = new ccarEntities();

                this.idInitiator = ent.users.Where(x => x.email == System.Web.HttpContext.Current.User.Identity.Name).Select(x => x.id).SingleOrDefault();
                this.originationDate = DateTime.Now;

                ent.actions.Add(action.ConvertToActionsFromDb(this));
                ent.SaveChanges();
                //emailClass.sendMail(responsible.getEmailAdress(Act.idResponsible), "Utworzono nowe zadanie", "Nowe zadanie");

            }
            else
            {
                ccarEntities ent = new ccarEntities();

                if (this.idProgress == 5)
                {
                    this.completionDate = DateTime.Now;
                }


                ent.Entry(action.ConvertToActionsFromDb(this)).State = EntityState.Modified;
                    ent.SaveChanges();

                }
            }

        }
    }
