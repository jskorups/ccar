using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ccar.Models;
using System.Web.Security;
using System.Data.Entity;
using System.Globalization;
using System.Threading;
using System.Web.Mvc;

namespace ccar.Models
{
    public class MeetingMinutesDatesModel
    {

        // wlasciwosci od meeting minutes dates
        public int id { get; set; }
        [DataType(DataType.Date)]
        public DateTime? Date { get; set; }
        [Required(ErrorMessage = "Required")]
        public int? projectId { get; set; }

      
      

        // get meeting minutes list
        public static List<mmDatesView> fromMMDatesView(List<mmDatesView> mList)
        {
            List<mmDatesView> mmDatesList = mList.Select(x => new mmDatesView()
            {
                id = x.id,
                Date = x.Date,
                ProjectName = x.ProjectName



            }).ToList();
            return mmDatesList;
        }

        public static meetingMinutesDates COnvertToMMDfromDB(MeetingMinutesDatesModel m)
        {
            meetingMinutesDates mmD = new meetingMinutesDates();
            mmD.id = m.id;
            mmD.Date = m.Date;
            mmD.projectId = m.projectId;
            return mmD;
        }

        public static MeetingMinutesDatesModel ConvertFromEFtoModel(meetingMinutesDates m)
        {


            MeetingMinutesDatesModel mmD = new MeetingMinutesDatesModel();
            mmD.id = m.id;
            mmD.Date = m.Date;
            mmD.projectId = m.projectId;
            return mmD;

        }


        public void Save()
        {
            if (this.id == 0)
            {

                ccarMeetingMinutesEntities ent = new ccarMeetingMinutesEntities();

  
                this.Date = DateTime.Now;

                ent.meetingMinutesDates.Add(MeetingMinutesDatesModel.COnvertToMMDfromDB(this));
                ent.SaveChanges();
                //emailClass.sendMail(responsible.getEmailAdress(this.idResponsible), "Utworzono nowe zadanie", "Nowe zadanie");

            }
            else
            {
                ccarMeetingMinutesEntities ent = new ccarMeetingMinutesEntities();

                ent.Entry(MeetingMinutesDatesModel.COnvertToMMDfromDB(this)).State = EntityState.Modified;
                ent.SaveChanges();

            }
        }
    }
}



