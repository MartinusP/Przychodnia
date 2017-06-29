using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Przychodnia.Models
{
    [Table("ODDZIAL_PRACOWNIK")]
    public partial class ODDZIAL_PRACOWNIK
    {
        [Key]
        public int ID_ODDZIAL_PRACOWNIK { get; set; }
        public int ID_PRACOWNIK { get; set; }
        public int ID_ODDZIAL { get; set; }

        public virtual PRACOWNIK PRACOWNIK { get; set; }
        public virtual ODDZIAL ODDZIAL { get; set; }
        
    }
}