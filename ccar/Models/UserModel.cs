using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ccar.Models
{
    public class UserModel
    {
        public int? id { get; set; }
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

        public static List<UserModel> fromUsers(List<users> userList)
        {
            List<UserModel> listUsers = userList.Select(x => new UserModel() { id = x.id,firstname = x.firstname, surname = x.surname,email = x.email, name = x.firstname + " " + x.surname }).ToList();
            return listUsers;
        }
        public static List<UserModel> getUsersList()
        {
            ccarEntities ent = new ccarEntities();
            return fromUsers(ent.users.ToList());
        }

        public static users ConvertFromModelToDB(UserModel u)
        {
            users us = new users();
            us.id = Convert.ToInt32(u.id == null ? 0 : u.id);
            us.firstname = u.firstname;
            us.surname = u.surname;
            us.email = u.email;

            return us;
        }
        public static UserModel ConvertFromDbToModel (users u)
        {
            UserModel mod = new UserModel();
            mod.id = u.id;
            mod.firstname = u.firstname;
            mod.surname = u.surname;
            mod.email = u.email;

            return mod;
        }

        public void Save()
        {
            if(this.id == 0)
            {
                ccarEntities ent = new ccarEntities();
                ent.users.Add(UserModel.ConvertFromModelToDB(this));
            }
        }


    }
}