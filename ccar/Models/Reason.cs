using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ccar.Models
{
    public class Reason
    {
        // 1:1 from DB
        public int id { get; set; }
        public string reason { get; set; }

     
        // List of reasons
        public static List<Reason> fromReason (List<reasons> rList)
        {
            List<Reason> listReason = rList.Select(x => new Reason() { id = x.id, reason = x.reason }).ToList();
            return listReason;
        }
        public static List<Reason> GetReasonList()
        {
            ccarEntities ent = new ccarEntities();
            return fromReason(ent.reasons.ToList());
        }

        public static reasons ConvertToReasonsFromDb(Reason r)
        {
            reasons rea = new reasons();
            rea.id = r.id;
            rea.reason = r.reason;

            return rea;
        }




        public void Save()
        {
            if (this.id == 0)
            {
                ccarEntities ent = new ccarEntities();
                ent.reasons.Add(Reason.ConvertToReasonsFromDb(this));
            }
        }

    }

}