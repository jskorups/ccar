using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ccar.Models
{
    public class TypeOfActionModel
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Required")]
        [StringLength(10, ErrorMessage = "Maximum 10 characters.")]
        public string typeOfAction1 { get; set; }


        public static List<TypeOfActionModel> fromTypeOfAction(List<typeOfaction> toaList)
        {
            List<TypeOfActionModel> listTOA = toaList.Select(x => new TypeOfActionModel() { id = x.id, typeOfAction1 = x.typeOfaction1}).ToList();
            return listTOA;
        }
        public static List<TypeOfActionModel> GetTypeOfActionList()
        {
            ccarEntities ent = new ccarEntities();
            return fromTypeOfAction(ent.typeOfaction.ToList());

        }
        public TypeOfActionModel()
        {

        }
        public TypeOfActionModel(string typeOfAction)
        {
            typeOfAction1 = typeOfAction;
        }
        public static typeOfaction ConvertFromModelToDB(TypeOfActionModel t)
        {
            typeOfaction toa = new typeOfaction();
            toa.id = t.id;
            toa.typeOfaction1 = t.typeOfAction1;
            return toa;
        }
        public static TypeOfActionModel ConvertFromDBtoModel(typeOfaction t)
        {
            TypeOfActionModel toa = new TypeOfActionModel();
            toa.id = t.id;
            toa.typeOfAction1 = t.typeOfaction1;
            return toa;
        }
        public void Save()
        {
            if (this.id == 0)
            {
                ccarEntities ent = new ccarEntities();
                ent.typeOfaction.Add(TypeOfActionModel.ConvertFromModelToDB(this));
            }
        }
    }
}