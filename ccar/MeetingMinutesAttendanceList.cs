//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ccar
{
    using System;
    using System.Collections.Generic;
    
    public partial class MeetingMinutesAttendanceList
    {
        public int id { get; set; }
        public int muserId { get; set; }
        public int meetingId { get; set; }
        public int statusId { get; set; }
    
        public virtual MeetingMinutesAttendanceStatus MeetingMinutesAttendanceStatus { get; set; }
        public virtual meetingMinutesDates meetingMinutesDates { get; set; }
        public virtual mMusers mMusers { get; set; }
    }
}
