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
    
    public partial class actions
    {
        public int id { get; set; }
        public Nullable<int> idReason { get; set; }
        public Nullable<int> idInitiator { get; set; }
        public string Initiator { get; set; }
        public System.DateTime originationDate { get; set; }
        public Nullable<int> idTypeOfAction { get; set; }
        public string problem { get; set; }
        public string problemLong { get; set; }
        public string rootCause { get; set; }
        public string correctiveAction { get; set; }
        public Nullable<int> idResponsible { get; set; }
        public Nullable<System.DateTime> targetDate { get; set; }
        public Nullable<int> idProgress { get; set; }
        public Nullable<System.DateTime> completionDate { get; set; }
        public string measureEffic { get; set; }
        public Nullable<System.DateTime> dateOfEffic { get; set; }
        public Nullable<int> Status { get; set; }
    
        public virtual progress progress { get; set; }
        public virtual reasons reasons { get; set; }
        public virtual responsibles responsibles { get; set; }
        public virtual typeOfaction typeOfaction { get; set; }
        public virtual users users { get; set; }
    }
}
