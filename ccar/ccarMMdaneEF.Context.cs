﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ccarMeetingMinutesEntities : DbContext
    {
        public ccarMeetingMinutesEntities()
            : base("name=ccarMeetingMinutesEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Meeting> Meeting { get; set; }
        public virtual DbSet<MeetingUsers> MeetingUsers { get; set; }
        public virtual DbSet<Priority> Priority { get; set; }
        public virtual DbSet<ProgressOfAction> ProgressOfAction { get; set; }
        public virtual DbSet<Projects> Projects { get; set; }
        public virtual DbSet<ProtocolOfAction> ProtocolOfAction { get; set; }
        public virtual DbSet<TypeOfSubject> TypeOfSubject { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<MeetingsView> MeetingsView { get; set; }
    }
}
