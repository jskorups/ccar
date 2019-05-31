using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ccar.Models;

namespace ccar.Models
{
    public class actions
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

        // for the User

        public string fullnameReason { get; set; }
        public string fullnameInitiator { get; set; }
        public string fullnameTypeOfAction { get; set; }
        public string fullnameResponsible { get; set; }
        public string valueProgress { get; set; }

        // saveToDatabase
        public void saveToDatabase()
        {
            ccarEntities ent = new ccarEntities();
            actions newAction = new actions();
            newAction.id = id;
            newAction.idReason = idReason;
            //newAction.idInitiator
        }

        public a
    }
}