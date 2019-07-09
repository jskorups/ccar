using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ccar.Models
{
    public class ReasonModel
    {
        // 1:1 from DB
        public int? id { get; set; }
        public string reason { get; set; }

     
        // List of reasons
        public static List<ReasonModel> fromReason (List<reasons> rList)
        {
            List<ReasonModel> listReason = rList.Select(x => new ReasonModel() { id = x.id, reason = x.reason }).ToList();
            return listReason;
        }
        public static List<ReasonModel> GetReasonList()
        {
            ccarEntities ent = new ccarEntities();
            return fromReason(ent.reasons.ToList());
        }
        public ReasonModel()
        {
       
        }
        public ReasonModel(string Reason)
        {
            reason = Reason;
        }
        public static reasons ConvertFromModelToDB(ReasonModel r)
        {
            reasons rea = new reasons();
            rea.id = Convert.ToInt32(r.id==null?0:r.id);
            rea.reason = r.reason;

            return rea;
        }
        public static ReasonModel ConvertFromDbToModel (reasons r)
        {
          
            ReasonModel rea = new ReasonModel();
            rea.id = r.id;
            rea.reason = r.reason;
            return rea;
        }

        public void Save()
        {
            if (this.id == 0)
            {
                ccarEntities ent = new ccarEntities();
                ent.reasons.Add(ReasonModel.ConvertFromModelToDB(this));
            }
        }
    }

}