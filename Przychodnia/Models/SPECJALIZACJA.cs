using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Przychodnia.Models
{
    public partial class SPECJALIZACJA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SPECJALIZACJA()
        {
            this.PRACOWNIKs = new HashSet<PRACOWNIK>();
        }

        public int ID_SPECJALIZACJA { get; set; }
        public string NAZWA { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PRACOWNIK> PRACOWNIKs { get; set; }
    }
}