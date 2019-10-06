using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ccar.Models
{
    public class mmUsersModel
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

        public static List<mmUsersModel> fromUsersDB (List<mMusers> uList)
        {
            List<mmUsersModel> usersList = uList.Select(x => new mmUsersModel { id = x.id, firstname = x.firstname, surname = x.surname }).ToList();
            return usersList;
        }

        public static List<mmUsersModel> GetUsersList()
        {
            ccarMeetingMinutesEntities ent = new ccarMeetingMinutesEntities();
            return fromUsersDB(ent.mMusers.ToList());
        }

        public mmUsersModel()
        {

        }

        public static mMusers COnvertFromModelToDB (mmUsersModel mod)
        {
            mMusers m = new mMusers();
            m.id = mod.id;
            m.firstname = mod.firstname;
            m.surname = mod.surname;
            m.email = mod.email;
            return m;
        }
        public static mmUsersModel COnvertFromDbToModel(mMusers mod)
        {
            mmUsersModel m = new mmUsersModel();
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