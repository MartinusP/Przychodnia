﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Przychodnia.Repository
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class PRZYCHODNIAEntities : DbContext
    {
        public PRZYCHODNIAEntities()
            : base("name=PRZYCHODNIAEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<DYZUR> DYZURs { get; set; }
        public virtual DbSet<ODDZIAL> ODDZIALs { get; set; }
        public virtual DbSet<ODDZIAL_PRACOWNIK> ODDZIAL_PRACOWNIK { get; set; }
        public virtual DbSet<PACJENT> PACJENTs { get; set; }
        public virtual DbSet<PLACOWKA> PLACOWKAs { get; set; }
        public virtual DbSet<PRACOWNIK> PRACOWNIKs { get; set; }
        public virtual DbSet<RECEPTA> RECEPTAs { get; set; }
        public virtual DbSet<SALA> SALAs { get; set; }
        public virtual DbSet<SPECJALIZACJA> SPECJALIZACJAs { get; set; }
        public virtual DbSet<WIZYTA> WIZYTAs { get; set; }
    }
}
