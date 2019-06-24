using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ccar.Models
{
    public class responsible
    {
        public int id { get; set; }
        public string firstname { get; set; }
        public string surname { get; set; }
        public string email { get; set; }
        public string name { get; set; }

        //      1.pobrac adres mailowy na podtsawie ID act(w modelu initaiotor), get emailadress, zwraca maila
        //2. sprawdzanie czy nie jest null i czy jest poprawny - w metodzie


        public static string getEmailAdress(int? userId)
        {
            ccarEntities ent = new ccarEntities();
            var xo = ent.users.Where(x => x.id == userId).FirstOrDefault();
            if (xo != null)
            {
                return xo.email;
            }
            else
            {
                return "";
            }

        }

        public static List<responsible> fromInitiators(List<users> inList)
        {
            List<responsible> listInitiator = inList.Select(x => new responsible() { id = x.id, name = x.firstname + " " + x.surname }).ToList();
            return listInitiator;
        }
        public static List<responsible> GetResponsibleList()
        {
            ccarEntities ent = new ccarEntities();
            return fromInitiators(ent.users.ToList());
        }
    }
}