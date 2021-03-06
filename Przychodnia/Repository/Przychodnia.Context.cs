﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Przychodnia.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class PRZYCHODNIAEntities : DbContext
    {
        public PRZYCHODNIAEntities()
            : base("name=PRZYCHODNIAEntities2")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ODDZIAL>()
                .HasKey(bc => new { bc.ID_ODDZIAL });

            modelBuilder.Entity<PRACOWNIK>()
                .HasKey(bc => new { bc.ID_PRACOWNIK });

            modelBuilder.Entity<ODDZIAL_PRACOWNIK>()
                .HasKey(bc => new { bc.ID_ODDZIAL, bc.ID_PRACOWNIK });

            modelBuilder.Entity<ODDZIAL_PRACOWNIK>()
                .HasRequired(bc => bc.ODDZIAL)
                .WithMany(b => b.ODDZIAL_PRACOWNIK)
                .HasForeignKey(bc => bc.ID_ODDZIAL);

            modelBuilder.Entity<ODDZIAL_PRACOWNIK>()
                .HasRequired(bc => bc.PRACOWNIK)
                .WithMany(c => c.ODDZIAL_PRACOWNIK)
                .HasForeignKey(bc => bc.ID_PRACOWNIK);
        }
    
        public virtual DbSet<DYZUR> DYZURY { get; set; }
        public virtual DbSet<ODDZIAL> ODDZIALY { get; set; }
        public virtual DbSet<ODDZIAL_PRACOWNIK> ODDZIAL_PRACOWNIK { get; set; }
        public virtual DbSet<PACJENT> PACJENCI { get; set; }
        public virtual DbSet<PLACOWKA> PLACOWKI { get; set; }
        public virtual DbSet<PRACOWNIK> PRACOWNICY { get; set; }
        public virtual DbSet<RECEPTA> RECEPTY { get; set; }
        public virtual DbSet<SALA> SALE { get; set; }
        public virtual DbSet<SPECJALIZACJA> SPECJALIZACJE { get; set; }
        public virtual DbSet<WIZYTA> WIZYTY { get; set; }
        
    }
}
