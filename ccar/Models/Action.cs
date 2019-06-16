using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ccar.Models;

namespace ccar.Models
{
    public class Action
    {

        // 1:1 from DB
        public int id { get; set; }
        public int idReason{ get; set; }
        public int idInitiator { get; set; }
        public string originationDate { get; set; }
        public int idTypeOfAction { get; set; }
        public string problem { get; set; }
        public string rootCause { get; set; }
        public string correctiveAction { get; set; }
        public int idResponsible { get; set; }
        public string targetDate { get; set; }
        public int idProgress { get; set; }
        public string completionDate { get; set; }
        public string measureEffic { get; set; }
        public string dateOfEffic { get; set; }

   

        // saveToDatabase
        public void saveToDatabase()
        {
            ccarEntities ent = new ccarEntities();
            Action newAction = new Action();
            newAction.id = id;
            newAction.idReason = idReason;
            //newAction.idInitiator
        }

      
    }
}