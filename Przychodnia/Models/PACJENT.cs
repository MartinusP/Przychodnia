using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Przychodnia.Models
{
    [Table("PACJENT")]
    public partial class PACJENT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PACJENT()
        {
            this.WIZYTY = new HashSet<WIZYTA>();
        }
        [Key]
        public int ID_PACJENT { get; set; }
        [Required]
        public string IMIE { get; set; }
        [Required]
        public string NAZWISKO { get; set; }
        [Required]
        public string ADRES { get; set; }
        [Required]
        public long PESEL { get; set; } 
        [Phone]
        public string TELEFON_KONTAKTOWY { get; set; }
        [EmailAddress]
        public string EMAIL_KONTAKTOWY { get; set; }
        [NotMapped]
        public string NAZWA_PACJENTA => NAZWISKO + " " + IMIE;
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WIZYTA> WIZYTY { get; set; }
    }
}