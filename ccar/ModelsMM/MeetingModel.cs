using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ccar.ModelsMM
{
    public class MeetingModel
    {
        public int meetingId { get; set; }
        [Required(ErrorMessage ="Required")]
        public int projectId { get; set; }
        public DateTime Date { get; set; }

        // wlasciwosci od users
        List<UserModel> users { get; set; }

        // wlasciowsci od meeting minutes attendance status
        public static SelectList attendanceStatusList { get { return GetAttendanceStatusList(); } }

        // wlasciwosci od meeting minutes project list
        public static SelectList projectList { get { return GetProjectList(); } }

    }
}