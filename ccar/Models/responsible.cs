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

             //      1.pobrac adres mailowy na podtsawie ID act(w modelu initaiotor), get emailadress, zwraca maila
             //2. sprawdzanie czy nie jest null i czy jest poprawny - w metodzie


        public static string  getEmailAdress (action act)
        {
            ccarEntities ent = new ccarEntities();
            var xo = ent.users.Where(x => x.id == act.id).FirstOrDefault();
             return xo.email;
        }
    }
}