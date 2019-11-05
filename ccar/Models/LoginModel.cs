using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ccar.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Field can't be empty")]
        public string firstname { get; set; }

        [Required(ErrorMessage = "Field can't be empty")]
        public string surname { get; set; }

        [Required(ErrorMessage = "Field can't be empty")]
        [RegularExpression(@"^\w+([-+.']\w+)*@grupoantolin.com$", ErrorMessage = "Incorrect email")]
        public string email { get; set; }

        [Required(ErrorMessage = "Field can't be empty")]
   
        [DataType(DataType.Password)]
        public string password { get; set; }

        [Required(ErrorMessage = "Field can't be empty")]
        //[Compare("password")]
        public string confirmPassword { get; set; } // walsiciowsc tylko w modelu
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

        public bool checkIfExistEmail(string email)
        {
            ccarEntities ent = new ccarEntities();
            int intIfExist = ent.users.Count(x => x.email == email);
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