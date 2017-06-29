using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Przychodnia.Models
{
    [Table("SPECJALIZACJA")]
    public class SPECJALIZACJA
    {

        [Key]
        public int ID_SPECJALIZACJA { get; set; }
        [Required]
        public string NAZWA { get; set; }


        public virtual ICollection<Pracownik_Specjalizacja> Pracownik_Specjalizacje { get; set; }
    }
}