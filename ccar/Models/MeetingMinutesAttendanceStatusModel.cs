using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ccar.Models
{
    public class MeetingMinutesAttendanceStatusModel
    {
        public int id { get; set; }
        public string statusAttendance { get; set; }



        public static List<MeetingMinutesAttendanceStatusModel> FromAttendanceStatusDB(List<MeetingMinutesAttendanceStatus> statusList)
        {
            List<MeetingMinutesAttendanceStatusModel> statList = statusList.Select(x => new MeetingMinutesAttendanceStatusModel { id = x.id, statusAttendance = x.statusAttendance }).ToList();
            return statList;
        }
        public static List<MeetingMinutesAttendanceStatusModel> GetStatusList()
        {
            ccarMeetingMinutesEntities ent = new ccarMeetingMinutesEntities();
            return FromAttendanceStatusDB(ent.MeetingMinutesAttendanceStatus.ToList());
        }

    }


    

   
}