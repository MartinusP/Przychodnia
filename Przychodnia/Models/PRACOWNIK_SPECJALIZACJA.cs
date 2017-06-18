using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Przychodnia.Models
{
    public class Pracownik_Specjalizacja
    {
        [Key]
        public int ID_PRACOWNIK_SPECJALIZACJA { get; set; }
        public int ID_PRACOWNIK { get; set; }
        public int ID_SPECJALIZACJA { get; set; }


        public virtual PRACOWNIK Pracownik2 { get; set; }
        public virtual SPECJALIZACJA Specjalizacja { get; set; }
    }
}