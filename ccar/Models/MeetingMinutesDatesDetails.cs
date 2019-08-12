using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ccar.Models
{
    public class MeetingMinutesDatesDetails
    {
        public int id { get; set; }
        public string firstname { get; set; }
        public string surname { get; set; }
        public string email { get; set; }

        public string name { get { return firstname + " " + surname; } }

        // wlasciowsci od meeting minutes attendance status
        public string attendanceStatus { get; set; }
        public static SelectList attendanceStatusList { get { return GetAttendanceStatusList(); } }

        // wlasciwosci od meeting minutes project list
        public static SelectList projectList { get { return GetProjectList(); } }






        // get attendance status list
        public static SelectList GetAttendanceStatusList()
        {

            ccarMeetingMinutesEntities ent = new ccarMeetingMinutesEntities();
            var statusList = ent.MeetingMinutesAttendanceStatus.ToList();
            return new SelectList(statusList, "id", "statusAttendance");
        }

        // get project list

        private static SelectList GetProjectList()
        {
            ccarMeetingMinutesEntities ent = new ccarMeetingMinutesEntities();
            var projectlist = ent.MeetingMinutesProjects.ToList();
            return new SelectList(projectlist, "id", "projectName");
        }

        // List of reasons
        public static List<MeetingMinutesDatesDetails> fromMMUsersDB(List<mMusers> uList)
        {
            List<MeetingMinutesDatesDetails> usersList = uList.Select(x => new MeetingMinutesDatesDetails() { id = x.id, firstname = x.firstname, surname = x.surname, email = x.email }).ToList();
            return usersList;
        }
        public static List<MeetingMinutesDatesDetails> GetReasonList()
        {
            ccarMeetingMinutesEntities ent = new ccarMeetingMinutesEntities();
            return fromMMUsersDB(ent.mMusers.ToList());
        }

    }
}