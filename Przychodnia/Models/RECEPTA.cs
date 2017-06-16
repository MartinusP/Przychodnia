using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Przychodnia.Models
{
    public partial class RECEPTA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RECEPTA()
        {
            this.WIZYTY = new HashSet<WIZYTA>();
        }
        [Key]
        public int ID_RECEPTA { get; set; }
        public Nullable<System.DateTime> DATA_WYKORZYSTANIA { get; set; }
        public string NAZWA_LEKU { get; set; }
        public string UWAGI { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WIZYTA> WIZYTY { get; set; }
    }
}