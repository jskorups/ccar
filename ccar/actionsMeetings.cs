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
    
    public partial class actionsMeetings
    {
        public int id { get; set; }
        public int idReason { get; set; }
        public System.DateTime originationDate { get; set; }
        public int initiatorId { get; set; }
        public string attendanceList { get; set; }
    
        public virtual reasons reasons { get; set; }
    }
}
