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
    
    public partial class ccarEntities : DbContext
    {
        public ccarEntities()
            : base("name=ccarEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<actions> actions { get; set; }
        public virtual DbSet<actionsLayout> actionsLayout { get; set; }
        public virtual DbSet<progress> progress { get; set; }
        public virtual DbSet<reasons> reasons { get; set; }
        public virtual DbSet<reasonsLayout> reasonsLayout { get; set; }
        public virtual DbSet<responsibles> responsibles { get; set; }
        public virtual DbSet<responsiblesLayout> responsiblesLayout { get; set; }
        public virtual DbSet<typeOfaction> typeOfaction { get; set; }
        public virtual DbSet<users> users { get; set; }
        public virtual DbSet<actionLayoutDoneView> actionLayoutDoneView { get; set; }
        public virtual DbSet<actionLayoutView> actionLayoutView { get; set; }
        public virtual DbSet<actionView> actionView { get; set; }
        public virtual DbSet<actionViewDone> actionViewDone { get; set; }
    }
}
