using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ccar.Models
{
    public class MeetingViewModel
        // poprzednio MeetingMinutesDatesDetails
    {

        // inna nazwa niz w DB
        public int meetingId { get; set; }
        [Required(ErrorMessage = "Required")]
        public DateTime? Date { get; set; }
        public int? projectId { get; set; }

        // wlasciwosci od users
        List<mmUsersModel> users { get; set; }

        // wlasciowsci od meeting minutes attendance status
        public static SelectList attendanceStatusList { get { return GetAttendanceStatusList(); } }

        // wlasciwosci od meeting minutes project list
        public static SelectList projectList { get { return GetProjectList(); } }

        
        

    }
}