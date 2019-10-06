using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ccar.ModelsMM
{
    public class UserModel
    {
        public int id { get; set; }
        public string firstname { get; set; }
        public string surname { get; set; }
        public string email { get; set; }

        public string name { get { return firstname + " " + surname; } }
        public string attendancestatus { get; set; }


        //public static List<MeetingMinutesUsersModel> fromMeetingUsers()
        //{

        //}

        public static List<UserModel> fromUsersDB(List<mMusers> uList)
        {
            List<UserModel> usersList = uList.Select(x => new UserModel { id = x.id, firstname = x.firstname, surname = x.surname }).ToList();
            return usersList;
        }

        public static List<UserModel> GetUsersList()
        {
            ccarMeetingMinutesEntities ent = new ccarMeetingMinutesEntities();
            return fromUsersDB(ent.mMusers.ToList());
        }

        public UserModel()
        {

        }

        public static mMusers COnvertFromModelToDB(UserModel mod)
        {
            mMusers m = new mMusers();
            m.id = mod.id;
            m.firstname = mod.firstname;
            m.surname = mod.surname;
            m.email = mod.email;
            return m;
        }
        public static UserModel COnvertFromDbToModel(mMusers mod)
        {
            UserModel m = new UserModel();
            m.id = mod.id;
            m.firstname = mod.firstname;
            m.surname = mod.surname;
            m.email = mod.email;
            return m;
        }

        private void Save()
        {
            if (this.id == 0)
            {
                ccarMeetingMinutesEntities ent = new ccarMeetingMinutesEntities();
                ent.mMusers.Add(COnvertFromModelToDB(this));
            }


        }
    }
}