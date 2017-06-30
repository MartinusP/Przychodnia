using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Przychodnia.Models
{
    [Table("RECEPTA")]
    public partial class RECEPTA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RECEPTA()
        {
            this.WIZYTY = new HashSet<WIZYTA>();
            this.LEKI = new HashSet<LEK>();
        }
        [Key]
        public int ID_RECEPTA { get; set; }
        [Required]
        public DateTime DATA_WYKORZYSTANIA { get; set; }
        [Required]
        public int ID_LEKU { get; set; }
        public string UWAGI { get; set; }
        public virtual LEK LEK { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WIZYTA> WIZYTY { get; set; }
        public virtual ICollection<LEK> LEKI { get; set; }

    }
}