using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ccar.Models
{
    public class typeAction
    {
        public int id { get; set; }
        public string typeOfAction1 { get; set; }

        public static List<typeOfaction> fromTypeOfAction(List<typeOfaction> toaList)
        {
            List<typeOfaction> listTOA = toaList.Select(x => new typeOfaction() { id = x.id, typeOfaction1 = x.typeOfaction1}).ToList();
            return listTOA;
        }
        public static List<typeOfaction> GetResponsibleList()
        {
            ccarEntities ent = new ccarEntities();
            return fromTypeOfAction(ent.typeOfaction.ToList());
        }


    }
}