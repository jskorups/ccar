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

     
        //public static List<MeetingMinutesUsersModel> fromMeetingUsers()
        //{

        //}

        public static List<UserModel> fromUsersDB(List<User> uList)
        {
            List<UserModel> usersList = uList.Select(x => new UserModel { id = x.id, firstname = x.firstname, surname = x.surname, email = x.email }).ToList();
            return usersList;
        }

        public static List<UserModel> GetUsersList()
        {
            ccarMeetingMinutesEntities ent = new ccarMeetingMinutesEntities();
            return fromUsersDB(ent.User.ToList());
        }

        //public UserModel()
        //{

        //}

        public static User COnvertFromModelToDB(UserModel mod)
        {
            User m = new User();
            m.id = mod.id;
            m.firstname = mod.firstname;
            m.surname = mod.surname;
            m.email = mod.email;
            return m;
        }
        public static UserModel COnvertFromDbToModel(User mod)
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
                ent.User.Add(COnvertFromModelToDB(this));
            }


        }
    }
}