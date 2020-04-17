using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ccar.Models
{
    public class ActionMeetingsModel
    {
        public int id { get; set; }
        public int idReason { get; set; }
        [Required(ErrorMessage = "Required")]
        public string reason { get; set; }
        public DateTime originationDate { get; set; }
        public int initiatorId { get; set; }
        public string Initiator { get; set; }
        //[Required(ErrorMessage = "Required")]
        //public string attendanceList { get; set; }

        public IEnumerable<int> AttendanceIds { get; set; }

        //public IEnumerable<int> AlraedyChosen { get; set; }
        //public IEnumerable<AttendanceUserRowModel> UsersList { get; set; }






        public static List<ActionMeetingsModel> fromActions(List<actionsMeetings> actList)
        {
            ccarEntities ent = new ccarEntities();
            List<ActionMeetingsModel> listActs = actList.Select(c => new ActionMeetingsModel() {id = c.id , Initiator = ent.users
                .Where(i=> i.id == c.initiatorId)
                .Select(x=> (x.firstname + " " + x.surname)).SingleOrDefault() ,reason = ent.reasons.Where(x =>x.id == c.idReason)
                .Select(x=> x.reason).SingleOrDefault(), originationDate = c.originationDate/*, attendanceList = c.attendanceList*/})
                .ToList();
            return listActs;
        }


       public static ActionMeetingsModel ConvertFromEFtoModel(actionsMeetings a)
        {
            ccarEntities ent = new ccarEntities();

            ActionMeetingsModel act = new ActionMeetingsModel();
            //act.attendanceList = a.attendanceList;
       

            act.reason = ent.reasons.Where(x => x.id == a.idReason).Select(x => x.reason).SingleOrDefault();

            //act.Initiator = ent.users.Where(i => i.id == CurrentUserId()).Select(x => (x.firstname + " " + x.surname)).SingleOrDefault();
            act.Initiator = ent.users.Where(i => i.id == a.initiatorId).Select(x => (x.firstname + " " + x.surname)).SingleOrDefault();
            act.AttendanceIds = ent.AttendanceMeetings.Where(x => x.MeetingId == a.id).Select(x => x.UserId).ToList();

            return act;
        }

        public static actionsMeetings ConvertToActionsFromDb(ActionMeetingsModel a)
        {
            ccarEntities ent = new ccarEntities();

            actionsMeetings act = new actionsMeetings();
            act.id = a.id;
            //act.attendanceList = a.attendanceList;
            act.originationDate = a.originationDate;
            act.idReason = ent.reasons.Where(x => x.reason == a.reason).Select(x => x.id).SingleOrDefault();
            act.initiatorId = ent.users.Where(x => x.email == System.Web.HttpContext.Current.User.Identity.Name).Select(x => x.id).SingleOrDefault();
           
            return act;
        }

        public static int CurrentUserId()
        {
            ccarEntities ent = new ccarEntities();
            return ent.users.Where(x => x.email == System.Web.HttpContext.Current.User.Identity.Name).Select(x => x.id).SingleOrDefault();
        }


        public void Save()
        {
            if (this.id == 0)
            {
                ccarEntities ent = new ccarEntities();

                this.originationDate = DateTime.Now;
                actionsMeetings mod = new actionsMeetings();
                mod = ActionMeetingsModel.ConvertToActionsFromDb(this);
                ent.actionsMeetings.Add(mod);

                foreach (var attendanceId in AttendanceIds.Distinct())
                {
                    AttendanceMeetings newAtt = new AttendanceMeetings();
                    newAtt.actionsMeetings = mod;
                    newAtt.UserId = attendanceId;
                    ent.AttendanceMeetings.Add(newAtt);
                }
                ent.SaveChanges();

            }
            else
            {
                ccarEntities ent = new ccarEntities();
                this.originationDate = DateTime.Now;
                ent.Entry(ActionMeetingsModel.ConvertToActionsFromDb(this)).State = EntityState.Modified;
                ent.SaveChanges();




            }
        }


    }

    
}