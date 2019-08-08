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




        // List of reasons
        public static List<MeetingMinutesUsersModel> fromMMUsersDB(List<mMusers> uList)
        {
            List<MeetingMinutesUsersModel> usersList = uList.Select(x => new MeetingMinutesUsersModel() { id = x.id, firstname = x.firstname, surname = x.surname, email = x.email }).ToList();
            return usersList;
        }
        public static List<MeetingMinutesUsersModel> GetReasonList()
        {
            ccarMeetingMinutesEntities ent = new ccarMeetingMinutesEntities();
            return fromMMUsersDB(ent.mMusers.ToList());
        }

    }
}