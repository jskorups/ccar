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

    }
}