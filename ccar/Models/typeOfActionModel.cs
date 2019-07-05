using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ccar.Models
{
    public class typeOfActionModel
    {
        public int id { get; set; }
        public string typeOfAction1 { get; set; }

        public static List<typeOfActionModel> fromTypeOfAction(List<typeOfaction> toaList)
        {
            List<typeOfActionModel> listTOA = toaList.Select(x => new typeOfActionModel() { id = x.id, typeOfAction1 = x.typeOfaction1}).ToList();
            return listTOA;
        }
        public static List<typeOfActionModel> GetTypeOfActionList()
        {
            ccarEntities ent = new ccarEntities();
            return fromTypeOfAction(ent.typeOfaction.ToList());

        }
        public typeOfActionModel()
        {

        }
        public typeOfActionModel(string typeOfAction)
        {
            typeOfAction1 = typeOfAction;
        }
        public static typeOfaction ConvertFromModelToDB(typeOfActionModel t)
        {
            typeOfaction toa = new typeOfaction();
            toa.id = t.id;
            toa.typeOfaction1 = t.typeOfAction1;
            return toa;
        }
        public static typeOfActionModel ConvertFromDBtoModel(typeOfaction t)
        {
            typeOfActionModel toa = new typeOfActionModel();
            toa.id = t.id;
            toa.typeOfAction1 = t.typeOfaction1;
            return toa;
        }
        public void Save()
        {
            if (this.id == 0)
            {
                ccarEntities ent = new ccarEntities();
                ent.typeOfaction.Add(typeOfActionModel.ConvertFromModelToDB(this));
            }
        }
    }
}