using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Przychodnia.Models
{
    [Table("RECEPTA_LEK")]
    public class ReceptaLek
    {

            [Key]
            public int ID_RECEPTA_LEK { get; set; }
            public int ID_RECEPTA { get; set; }
            public int ID_LEK { get; set; }

            public virtual RECEPTA RECEPTA { get; set; }
            public virtual LEK LEK { get; set; }


    }
}