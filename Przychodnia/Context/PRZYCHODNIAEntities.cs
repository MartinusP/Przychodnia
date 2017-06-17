using Przychodnia.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Przychodnia.Context
{

        public class PRZYCHODNIAEntities : DbContext
        {
            public PRZYCHODNIAEntities()
                : base("name=PRZYCHODNIAEntities")
            {

            }

            public DbSet<DYZUR> DYZURY { get; set; }
            public DbSet<Przychodnia.Models.ODDZIAL> ODDZIALY { get; set; }
            public DbSet<PACJENT> PACJENCI { get; set; }
            public DbSet<PLACOWKA> PLACOWKI { get; set; }
            public DbSet<Przychodnia.Models.PRACOWNIK> PRACOWNICY { get; set; }
            public DbSet<RECEPTA> RECEPTY { get; set; }
            public DbSet<SALA> SALE { get; set; }
            public DbSet<SPECJALIZACJA> SPECJALIZACJE { get; set; }
            public DbSet<Przychodnia.Models.WIZYTA> WIZYTY { get; set; }
            public DbSet<Przychodnia.Models.ODDZIAL_PRACOWNIK> ODDZIAL_PRACOWNICY { get; set; }
        public System.Data.Entity.DbSet<Przychodnia.Models.Author> Authors { get; set; }

        public System.Data.Entity.DbSet<Przychodnia.Models.Book> Books { get; set; }

        public System.Data.Entity.DbSet<Przychodnia.Models.AuthorToBook> AuthorsToBooks { get; set; }

    }
}

