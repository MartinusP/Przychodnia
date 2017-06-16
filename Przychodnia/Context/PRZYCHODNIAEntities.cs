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

            public DbSet<DYZUR> DYZURY { get; set; }
            public DbSet<ODDZIAL> ODDZIALY { get; set; }
            public DbSet<ODDZIAL_PRACOWNIK> ODDZIAL_PRACOWNIK { get; set; }
            public DbSet<PACJENT> PACJENCI { get; set; }
            public DbSet<PLACOWKA> PLACOWKI { get; set; }
            public DbSet<PRACOWNIK> PRACOWNICY { get; set; }
            public DbSet<RECEPTA> RECEPTY { get; set; }
            public DbSet<SALA> SALE { get; set; }
            public DbSet<SPECJALIZACJA> SPECJALIZACJE { get; set; }
            public DbSet<Przychodnia.Models.WIZYTA> WIZYTY { get; set; }

        }
}

