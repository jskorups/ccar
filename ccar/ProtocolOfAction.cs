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
    
    public partial class ProtocolOfAction
    {
        public int id { get; set; }
        public int projectId { get; set; }
        public Nullable<int> priorityId { get; set; }
        public Nullable<System.DateTime> originationDate { get; set; }
        public Nullable<int> typeOfSubjectId { get; set; }
        public string Subject { get; set; }
        public Nullable<int> responsibleId { get; set; }
        public string supportId { get; set; }
        public Nullable<System.DateTime> targetDate { get; set; }
        public Nullable<int> idProgress { get; set; }
        public string comments { get; set; }
        public Nullable<int> meetingId { get; set; }
    
        public virtual Meeting Meeting { get; set; }
        public virtual Priority Priority { get; set; }
        public virtual ProgressOfAction ProgressOfAction { get; set; }
        public virtual Projects Projects { get; set; }
        public virtual TypeOfSubject TypeOfSubject { get; set; }
    }
}
