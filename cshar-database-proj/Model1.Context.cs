﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace cshar_database_proj
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class SQL_QuickCarEntities : DbContext
    {
        public SQL_QuickCarEntities()
            : base("name=SQL_QuickCarEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CarInUse> CarInUse { get; set; }
        public virtual DbSet<Cars> Cars { get; set; }
        public virtual DbSet<CarsInService> CarsInService { get; set; }
        public virtual DbSet<CarsSold> CarsSold { get; set; }
        public virtual DbSet<Clients> Clients { get; set; }
        public virtual DbSet<RepairStatus> RepairStatus { get; set; }
    }
}
