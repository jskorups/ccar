using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ccar.Models
{
    public class MeetingMinutesDatesDetails
    {
        //wlasciwosc od meeting minutes dates 

            // inna nazwa niz w DB
        public int meetingId { get; set; }
        [Required(ErrorMessage = "Required")]
        public DateTime? Date { get; set; }
        public int? projectId { get; set; }

        // wlasciwosci od users
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



        // convert from this model to MeetingDatesModel

        public static MeetingMinutesDatesDetails ConvertFromModeltoDB(meetingMinutesDates m)
        {
            MeetingMinutesDatesDetails mmDD = new MeetingMinutesDatesDetails();
            mmDD.meetingId = m.id;
            mmDD.Date = m.Date;
            mmDD.projectId = m.projectId;
            return mmDD;
        }

        public static meetingMinutesDates ConvertFrom (MeetingMinutesDatesDetails m)
        {
            meetingMinutesDates mmDD = new meetingMinutesDates();
            mmDD.id = m.meetingId;
            mmDD.Date = m.Date;
            mmDD.projectId = m.projectId;
            return mmDD;
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


        public void Save()
        {
            if (this.id == 0)
            {

                ccarMeetingMinutesEntities ent = new ccarMeetingMinutesEntities();
                this.Date = DateTime.Now;

                ent.meetingMinutesDates.Add(MeetingMinutesDatesDetails.ConvertFrom(this));
                ent.SaveChanges();




                //emailClass.sendMail(responsible.getEmailAdress(this.idResponsible), "Utworzono nowe zadanie", "Nowe zadanie");
            }
            else
            {
                //ccarMeetingMinutesEntities ent = new ccarMeetingMinutesEntities();

                //ent.Entry(MeetingMinutesDatesDetails.convertFromDbToMOdel(this)).State = EntityState.Modified;
                //ent.SaveChanges();

            }
        }









    }
}