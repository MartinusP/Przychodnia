using Przychodnia.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Przychodnia.Context
{

        public partial class PRZYCHODNIAEntities : DbContext
        {
            public PRZYCHODNIAEntities()
                : base("name=PRZYCHODNIAEntities")
            {

            }

            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                //modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
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

