using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Przychodnia.Models
{
    [Table("PLACOWKA")]
    public partial class PLACOWKA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        /*
        public PLACOWKA()
        {
            this.ODDZIALY = new HashSet<ODDZIAL>();
        }
        */
        [Key]
        public int ID_PLACOWKA { get; set; }
        [Required]
        public string NAZWA { get; set; }
        [Required]
        public string MIEJSCOWOSC { get; set; }
        [Required]
        public string ADRES { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<ODDZIAL> ODDZIALY { get; set; }
    }
}