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
        public int initiatorId { get; set; }
        public string attendanceList { get; set; }


        public static actionsMeetings fromDBtoModel (ActionMeetingsModel model)
        {
            ccarEntities ent = new ccarEntities();

            actionsMeetings act = new actionsMeetings();
            model.reason = ent.reasons.Where(x => x.id == act.id).Select(x => x.reason).SingleOrDefault();
            act.originationDate = model.originationDate;
            act.initiatorId = model.initiatorId;
            act.attendanceList = model.attendanceList;

            return act;

        }

        public static ActionMeetingsModel fromModelToDb(actionsMeetings act)
        {
            ccarEntities ent = new ccarEntities();

            ActionMeetingsModel model = new ActionMeetingsModel();
            model.reason = ent.reasons.Where(x => x.id == act.id).Select(x => x.reason).SingleOrDefault();
            model.originationDate = act.originationDate;
            model.initiatorId = act.initiatorId;
            model.attendanceList = act.attendanceList;
            return model;
        }


        public static List<ActionMeetingsModel> fromActions(List<actionsMeetings> actList)
        {
            ccarEntities ent = new ccarEntities();
            List<ActionMeetingsModel> listActs = actList.Select(c => new ActionMeetingsModel() { reason = ent.reasons.Where(x =>x.id == c.idReason).Select(x=> x.reason).SingleOrDefault(), originationDate = c.originationDate, attendanceList = c.attendanceList, initiatorId = c.initiatorId}).ToList();
            return listActs;
        }



    }

    
}