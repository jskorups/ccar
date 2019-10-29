using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ccar.Models
{
    public class PasswordResetModel
    {
        public string adresEmail { get; set; }

        public string guid { get; set; }
        public string newPassword { get; set; }
        public string newPasswordConfirm { get; set; }

        public static bool checkIfemailExist (string email)
        {
            ccarEntities ent = new ccarEntities();
            users user = ent.users.Where(x => x.email == email).FirstOrDefault();

            if (user != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void setResetCode(string adresEmail, string Guid)
        {

            ccarEntities ent = new ccarEntities();
            users user = ent.users.Where(x => x.email == adresEmail).FirstOrDefault();

            if (user != null)
            {
                user.guid = Guid;
                ent.SaveChanges();
            }
            else
            {
                ///
            }

        }
        public static bool checkGuid(string guid, string email)
        {
            ccarEntities ent = new ccarEntities();
            int Count = ent.users.Where(x => x.email == email && x.guid == guid).Count();

            if (Count != 0)
            {
                return true;
            }
            return false;
        }

        public static bool resetPassword(string email, string guid, string newPassword)
        {
            ccarEntities ent = new ccarEntities();
            var user = ent.users.Where(x => x.email == email && x.guid == guid).FirstOrDefault();
            if (user != null)
            {
                //user.password = crypto.Hash(newPassword);
                user.password = newPassword;

                ent.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}