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
    public class MeetingModel
    {

        // wlasciwosci od meeting minutes dates
        public int Id { get; set; }
        [DataType(DataType.Date)]
        public DateTime? Date { get; set; }
        [Required(ErrorMessage = "Required")]
        public string presentUsers { get; set; }
        [Required(ErrorMessage = "Required")]
        public int? ProjectId { get; set; }

        
      
        // get meeting minutes list
        public static List<MeetingsView> FromMMDatesView(List<MeetingsView> mList)
        {
            List<MeetingsView> mmDatesList = mList.Select(x => new MeetingsView()
            {
                id = x.id,
                Date = x.Date,
                presentUsers = x.presentUsers,
                ProjectName = x.ProjectName

            }).ToList();
            return mmDatesList;
        }

        public static Meeting ConvertFromDbToMOdel(MeetingModel m)
        {
            Meeting mmD = new Meeting();
            mmD.id = m.Id;
            mmD.Date = m.Date;
            mmD.presentUsers = m.presentUsers;
            mmD.projectId = m.ProjectId;
            return mmD;
        }

        public static MeetingModel ConvertFromModelToDb(Meeting m)
        {
            MeetingModel mmD = new MeetingModel();
            mmD.Id = m.id;
            mmD.Date = m.Date;
            mmD.presentUsers = m.presentUsers;
            mmD.ProjectId = m.projectId;
            return mmD;
        }


        public void Save()
        {
            if (this.Id == 0)
            {

                ccarMeetingMinutesEntities ent = new ccarMeetingMinutesEntities();

                this.Date = DateTime.Now;

                ent.Meeting.Add(MeetingModel.ConvertFromDbToMOdel(this));
                ent.SaveChanges();
                //emailClass.sendMail(responsible.getEmailAdress(this.idResponsible), "Utworzono nowe zadanie", "Nowe zadanie");
            }
            else
            {
                ccarMeetingMinutesEntities ent = new ccarMeetingMinutesEntities();

                ent.Entry(MeetingModel.ConvertFromDbToMOdel(this)).State = EntityState.Modified;
                ent.SaveChanges();

            }
        }
    }
}



