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
    
    public partial class actionsLayout
    {
        public int Id { get; set; }
        public int IdReasonLayout { get; set; }
        public int IdInitiator { get; set; }
        public string Initiator { get; set; }
        public System.DateTime OriginationDate { get; set; }
        public string TaskDescription { get; set; }
        public int IdResponsibleLayout { get; set; }
        public Nullable<System.DateTime> TargetDate { get; set; }
        public int IdProgress { get; set; }
        public Nullable<System.DateTime> CompletionDate { get; set; }
        public int Status { get; set; }
    
        public virtual progress progress { get; set; }
        public virtual reasonsLayout reasonsLayout { get; set; }
        public virtual responsiblesLayout responsiblesLayout { get; set; }
        public virtual users users { get; set; }
    }
}
