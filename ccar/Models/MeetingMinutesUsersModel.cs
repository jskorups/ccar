using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ccar.Models
{
    public class MeetingMinutesUsersModel
    {
        public int id { get; set; }
        public string firstname { get; set; }
        public string surname { get; set; }
        public string email { get; set; }

        public string name { get { return firstname + " " + surname; } }
        public string attendancestatus { get; set; }




        public static List<MeetingMinutesUsersModel> fromMeetingUsers()
        {

        }

        public static List<MeetingMinutesUsersModel> fromUsersDB (List<mMusers> uList)
        {
            List<MeetingMinutesUsersModel> usersList = uList.Select(x => new MeetingMinutesUsersModel { id = x.id, firstname = x.firstname, surname = x.surname }).ToList();
            return usersList;
        }

        public static List<MeetingMinutesUsersModel> GetUsersList()
        {
            ccarMeetingMinutesEntities ent = new ccarMeetingMinutesEntities();
            return fromUsersDB(ent.mMusers.ToList());
        }

        public MeetingMinutesUsersModel()
        {

        }

        public static mMusers COnvertFromModelToDB (MeetingMinutesUsersModel mod)
        {
            mMusers m = new mMusers();
            m.id = mod.id;
            m.firstname = mod.firstname;
            m.surname = mod.surname;
            m.email = mod.email;
            return m;
        }
        public static MeetingMinutesUsersModel COnvertFromDbToModel(mMusers mod)
        {
            MeetingMinutesUsersModel m = new MeetingMinutesUsersModel();
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