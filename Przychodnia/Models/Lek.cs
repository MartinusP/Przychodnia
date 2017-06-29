using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Przychodnia.Models
{
    [Table("LEK")]
    public partial class LEK
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LEK()
        {
            //this.RECEPTY = new HashSet<RECEPTY>();
        }
        [Key]
        public int ID_LEKU { get; set; }
        [Required]
        public string NAZWA_LEKU { get; set; }
        public string UWAGI { get; set; }

        public virtual RECEPTA RECEPTA { get; set; }

    }
}