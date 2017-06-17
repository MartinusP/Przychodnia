using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Przychodnia.Models
{
    public partial class PRACOWNIK
    {

        
        public PRACOWNIK()
        {
            this.DYZURY = new HashSet<DYZUR>();
            this.WIZYTY = new HashSet<WIZYTA>();
        }
        [Key]
        public int ID_PRACOWNIK { get; set; }
        public string IMIE { get; set; }
        public string NAZWISKO { get; set; }
        public string ADRES { get; set; }
        public string EMAIL_KONTAKTOWY { get; set; }
        public Nullable<int> ID_SPECJALIZACJA { get; set; }

        
        public virtual ICollection<DYZUR> DYZURY { get; set; }
        public virtual ICollection<WIZYTA> WIZYTY { get; set; }
        public virtual ICollection<ODDZIAL_PRACOWNIK> ODDZIAL_PRACOWNIK { get; set; }
        public virtual ICollection<Pracownik_Specjalizacja> Pracownik_Specjalizacje { get; set; }

    }
}