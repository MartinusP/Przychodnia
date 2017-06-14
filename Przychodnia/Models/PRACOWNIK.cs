using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Przychodnia.Models
{
    public partial class PRACOWNIK
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PRACOWNIK()
        {
            this.ODDZIAL_PRACOWNIK = new HashSet<ODDZIAL_PRACOWNIK>();
            this.WIZYTAs = new HashSet<WIZYTA>();
        }

        public int ID_PRACOWNIK { get; set; }
        public string IMIE { get; set; }
        public string NAZWISKO { get; set; }
        public string ADRES { get; set; }
        public string EMAIL_KONTAKTOWY { get; set; }
        public Nullable<int> ID_SPECJALIZACJA { get; set; }
        public Nullable<int> ID_ODDZIAL_PRACOWNIK { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ODDZIAL_PRACOWNIK> ODDZIAL_PRACOWNIK { get; set; }
        public virtual ODDZIAL_PRACOWNIK ODDZIAL_PRACOWNIK1 { get; set; }
        public virtual DYZUR DYZUR { get; set; }
        public virtual SPECJALIZACJA SPECJALIZACJA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WIZYTA> WIZYTAs { get; set; }
    }
}