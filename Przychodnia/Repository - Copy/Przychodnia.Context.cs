﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Przychodnia.Repository___Copy
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
    
        public virtual DbSet<ODDZIAL> ODDZIALY { get; set; }
        public virtual DbSet<ODDZIAL_PRACOWNIK> ODDZIAL_PRACOWNIK { get; set; }
        public virtual DbSet<PACJENT> PACJENCI { get; set; }
        public virtual DbSet<PLACOWKA> PLACOWKI { get; set; }
        public virtual DbSet<PRACOWNIK> PRACOWNICY { get; set; }
        public virtual DbSet<RECEPTA> RECEPTY { get; set; }
        public virtual DbSet<SALA> SALE { get; set; }
        public virtual DbSet<SPECJALIZACJA> SPECJALIZACJE { get; set; }
        public virtual DbSet<WIZYTA> WIZYTY { get; set; }
        public virtual DbSet<DYZUR> DYZURY { get; set; }
    }
}
