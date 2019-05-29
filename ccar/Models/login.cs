using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ccar.Models
{
    public class Login
    {
        public string login { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string guid  { get; set; }
        public bool active { get; set; }


        public void SaveToDataBase()
        {
            ccarEntities ent = new ccarEntities();
            users userNew = new users();
            userNew.login = login;
            userNew.password = crypto.Hash(password);
            userNew.email = email;
            userNew.guid = guid;
            userNew.active = active;
        }

        public bool checkIfExist(string login, string password)
        {
            ccarEntities ent = new ccarEntities();
            int intIfExist = ent.users.Count(x => x.login == login && x.password == password);
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