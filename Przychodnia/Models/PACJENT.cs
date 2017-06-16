using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Przychodnia.Models
{
    public partial class PACJENT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PACJENT()
        {
            this.WIZYTY = new HashSet<WIZYTA>();
        }
        [Key]
        public int ID_PACJENT { get; set; }
        public string IMIE { get; set; }
        public string NAZWISKO { get; set; }
        public string ADRES { get; set; }
        public Nullable<long> PESEL { get; set; }
        public string TELEFON_KONTAKTOWY { get; set; }
        public string EMAIL_KONTAKTOWY { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WIZYTA> WIZYTY { get; set; }
    }
}