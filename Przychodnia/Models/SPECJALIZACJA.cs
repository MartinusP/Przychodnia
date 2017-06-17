using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Przychodnia.Models
{
    public class SPECJALIZACJA
    {

        [Key]
        public int ID_SPECJALIZACJA { get; set; }
        public string NAZWA { get; set; }


        public virtual ICollection<Pracownik_Specjalizacja> Pracownik_Specjalizacje { get; set; }
    }
}