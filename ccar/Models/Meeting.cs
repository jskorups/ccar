using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ccar.Models
{
    public class Meeting
        // poprzednio MeetingMinutesDatesDetails
    {
    





        // inna nazwa niz w DB
        public int meetingId { get; set; }
        [Required(ErrorMessage = "Required")]
        public DateTime? Date { get; set; }
        public int? projectId { get; set; }

        // wlasciwosci od users
        List<MeetingMinutesUsersModel> users { get; set; }

        // wlasciowsci od meeting minutes attendance status
        public static SelectList attendanceStatusList { get { return GetAttendanceStatusList(); } }

        // wlasciwosci od meeting minutes project list
        public static SelectList projectList { get { return GetProjectList(); } }





        public Meeting()
        {
            users = MeetingMinutesUsersModel.GetUsersList();
        }

        public Meeting(int id)
        {
            this.meetingId = id;
            //users = MeetingMinutesUsersModel.GetUsersList(id);
            ////users = MeetingMinutesUsersModel.GetUsersList();
        }


        // get attendance status list
        public static SelectList GetAttendanceStatusList()
        {
            ccarMeetingMinutesEntities ent = new ccarMeetingMinutesEntities();
            var statusList = ent.MeetingMinutesAttendanceStatus.ToList();
            return new SelectList(statusList, "id", "statusAttendance");
        }


        public static List<Meeting> FromUSers (List<MeetingMinutesAttendanceList> uList)
        {
            List<Meeting> usersList = uList.Select(x => new Meeting { meetingId = x.meetingId }).ToList();
            return usersList;
        }

        //// get users list by meeting id
        //public static List<MeetingMinutesUsersModel> GetUsersList(int id)
        //{

        //}



        // get project list

        private static SelectList GetProjectList()
        {
            ccarMeetingMinutesEntities ent = new ccarMeetingMinutesEntities();
            var projectlist = ent.MeetingMinutesProjects.ToList();
            return new SelectList(projectlist, "id", "projectName");
        }



        // convert from this model to MeetingDatesModel

        public static Meeting ConvertFromModeltoDB(meetingMinutesDates m)
        {
            Meeting mmDD = new Meeting();
            mmDD.meetingId = m.id;
            mmDD.Date = m.Date;
            mmDD.projectId = m.projectId;
            return mmDD;
        }

        public static meetingMinutesDates ConvertFrom (Meeting m)
        {
            meetingMinutesDates mmDD = new meetingMinutesDates();
            mmDD.id = m.meetingId;
            mmDD.Date = m.Date;
            mmDD.projectId = m.projectId;
            return mmDD;
        }




        // List of reasons
        //public static List<Meeting> fromMMUsersDB(List<mMusers> uList)
        //{
        //    //List<Meeting> usersList = uList.Select(x => new Meeting() { meetingId = x.id, firstname = x.firstname, surname = x.surname, email = x.email }).ToList();
        //    //return usersList;
        //}
        //public static List<Meeting> GetReasonList()
        //{
        //    ccarMeetingMinutesEntities ent = new ccarMeetingMinutesEntities();
        //    //return fromMMUsersDB(ent.mMusers.ToList());
        //}


        public void Save()
        {
            //if (this.id == 0)
            //{

            //    ccarMeetingMinutesEntities ent = new ccarMeetingMinutesEntities();
            //    this.Date = DateTime.Now;

            //    ent.meetingMinutesDates.Add(Meeting.ConvertFrom(this));
            //    ent.SaveChanges();




            //    //emailClass.sendMail(responsible.getEmailAdress(this.idResponsible), "Utworzono nowe zadanie", "Nowe zadanie");
            //}
            //else
            //{
            //    //ccarMeetingMinutesEntities ent = new ccarMeetingMinutesEntities();

            //    //ent.Entry(Meeting.convertFromDbToMOdel(this)).State = EntityState.Modified;
            //    //ent.SaveChanges();

            //}
        }









    }
}