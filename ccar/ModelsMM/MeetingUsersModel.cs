using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ccar.ModelsMM
{
    public class MeetingUsersModel
    {
        public int id { get; set; }
        public int? meetingId { get; set; }
        public int? userId { get; set; }
        public bool? isPresent { get; set; }


        public static List<MeetingUsersModel> fromMeetingUserinDB (List<MeetingUsers> muList)
        {
            List<MeetingUsersModel> meetUsList = muList.Select(x => new MeetingUsersModel() { id = x.id, meetingId = x.meetingId, userId = x.userId, isPresent = x.isPresent }).ToList();
            return meetUsList;
        }

        public static List<MeetingUsersModel> GetMeetingUsersList()
        {
            ccarMeetingMinutesEntities ent = new ccarMeetingMinutesEntities();
            return fromMeetingUserinDB(ent.MeetingUsers.ToList());
        }

        public static MeetingUsers convertFromModelToDB(MeetingUsersModel m)
        {
            MeetingUsers mU = new MeetingUsers();
            mU.id = m.id;
            mU.meetingId = m.meetingId;
            mU.userId = m.userId;
            mU.isPresent = m.isPresent;
            return mU;
        }

        public static MeetingUsersModel ConvertFromDbToModel(MeetingUsers m)
        {

            MeetingUsersModel mU = new MeetingUsersModel();
            mU.id = m.id;
            mU.meetingId = m.meetingId;
            mU.userId = m.userId;
            mU.isPresent = m.isPresent;
            return mU;
        }

        public void Save()
        {
            if (this.id == 0)
            {
                ccarMeetingMinutesEntities ent = new ccarMeetingMinutesEntities();
                ent.MeetingUsers.Add(MeetingUsersModel.convertFromModelToDB(this));
            }
        }


    }
   


}