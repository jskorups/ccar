using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ccar.Models
{
    public class LoginModel
    {

        public string firstname { get; set; }
        public string surname { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string guid  { get; set; }
        public bool active { get; set; }


        public void SaveToDataBase()
        {
            ccarEntities ent = new ccarEntities();
            users userNew = new users();
            userNew.firstname = firstname;
            userNew.surname = surname;
            userNew.password = crypto.Hash(password);
            userNew.email = email;
            userNew.guid = guid;
            userNew.active = active;
            ent.users.Add(userNew);
            ent.SaveChanges();
        }

        public bool checkIfExist(string email, string password)
        {
            ccarEntities ent = new ccarEntities();
            int intIfExist = ent.users.Count(x => x.email == email && x.password == password);
            if (intIfExist == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }

   
}