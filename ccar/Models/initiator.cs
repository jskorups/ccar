using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ccar.Models
{
    
    public class initiator
    {
        public int id { get; set; }
        public string firstname { get; set; }
        public string surname { get; set; }
        //public string name { get { return (firstname + surname); } set { }}
        public string name { get; set; }

        public static List<initiator> fromInitiators (List<users> inList)
        {
            List<initiator> listInitiator = inList.Select(x => new initiator() { id = x.id, name = x.firstname + x.surname}).ToList();
            return listInitiator;
        }
        public static List<initiator> GetInitiatorsList()
        {
            ccarEntities ent = new ccarEntities();
            return fromInitiators(ent.users.ToList());
        }
        
    }
}