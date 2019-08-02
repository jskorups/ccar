using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ccar.Models
{
    public class MeetingMinutesModel
    {
        public int id { get; set; }
        public string Contents { get; set; }
        public int CategoryId { get; set; }




        // List of meetings
        public static List<MeetingMinutesModel> GetListOfFromDB(List<meetingMinutes> mList)
        {
            List<MeetingMinutesModel> meetingList = mList.Select(x => new MeetingMinutesModel() { id = x.id, CategoryId = x.CategoryId, Contents = x.Contents }).ToList();
            return meetingList;
        }
        public static List<MeetingMinutesModel> getMinutesList()
        {
            ccarEntities ent = new ccarEntities();
            return GetListOfFromDB(ent.meetingMinutes.ToList());
        }



    }


  
}