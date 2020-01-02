using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ccar.Models
{
    public class ActionMeetingsModel
    {

        //public int idReason { get; set; }
        public string reason { get; set; }
        public DateTime originationDate { get; set; }
        //public int initiatorId { get; set; }
        public string Initiator { get; set; }
        public string attendanceList { get; set; }


        public static actionsMeetings fromDBtoModel (ActionMeetingsModel model)
        {
            ccarEntities ent = new ccarEntities();

            actionsMeetings act = new actionsMeetings();
            model.reason = ent.reasons.Where(x => x.id == act.id).Select(x => x.reason).SingleOrDefault();
            act.originationDate = model.originationDate;
            //act.initiatorId = model.initiatorId;
            act.attendanceList = model.attendanceList;

            return act;

        }

        public static ActionMeetingsModel fromModelToDb(actionsMeetings act)
        {
            ccarEntities ent = new ccarEntities();

            ActionMeetingsModel model = new ActionMeetingsModel();
            model.reason = ent.reasons.Where(x => x.id == act.id).Select(x => x.reason).SingleOrDefault();
            model.originationDate = act.originationDate;
            //model.initiatorId = act.initiatorId;
            model.attendanceList = act.attendanceList;
            return model;
        }

        public static List<ActionMeetingsModel> fromActions(List<actionsMeetings> actList)
        {
            ccarEntities ent = new ccarEntities();
            List<ActionMeetingsModel> listActs = actList.Select(c => new ActionMeetingsModel() {Initiator = ent.users.Where(i=> i.id == c.initiatorId).Select(x=> (x.firstname + " " + x.surname)).SingleOrDefault() ,reason = ent.reasons.Where(x =>x.id == c.idReason).Select(x=> x.reason).SingleOrDefault(), originationDate = c.originationDate, attendanceList = c.attendanceList}).ToList();
            return listActs;
        }


        public void Save()
        {
            if (this.id == 0)
            {

                ccarEntities ent = new ccarEntities();


                this.idInitiator = ent.users.Where(x => x.email == System.Web.HttpContext.Current.User.Identity.Name).Select(x => x.id).SingleOrDefault();
                this.originationDate = DateTime.Now;
                this.Status = 0;

                string Replaced = System.Environment.UserName.Replace('.', ' ');
                CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
                TextInfo textInfo = cultureInfo.TextInfo;

                this.originationDate = DateTime.Now;
                //this.Initiator = (textInfo.ToTitleCase(Replaced));
                //this.idInitiator = 1;

                ent.actions.Add(ActionModel.ConvertToActionsFromDb(this));
                ent.SaveChanges();
                //emailClass.CreateMailItem(UserModel.getEmailAdress(this.idResponsible), "Utworzono nowe zadanie", "Nowe zadanie");

            }
            else
            {
                ccarEntities ent = new ccarEntities();

                if (this.idProgress == 5)
                {
                    this.completionDate = DateTime.Now;
                }

                string Replaced = System.Environment.UserName.Replace('.', ' ');
                CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
                TextInfo textInfo = cultureInfo.TextInfo;

                this.Initiator = (textInfo.ToTitleCase(Replaced));

                ent.Entry(ActionModel.ConvertToActionsFromDb(this)).State = EntityState.Modified;
                ent.SaveChanges();

            }
        }


    }

    
}