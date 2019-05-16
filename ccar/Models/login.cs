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

        [Required]
        public string password { get; set; }

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