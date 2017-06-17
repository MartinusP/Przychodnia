using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Przychodnia.Models
{
    public class PRACOWNIK_SPECJALIZACJA
    {
        [Key]
        public int ID_ODDZIAL_PRACOWNIK { get; set; }
        public int ID_PRACOWNIK { get; set; }
        public int ID_ODDZIAL { get; set; }


        public virtual Pracownik PRACOWNICY { get; set; }
        public virtual SPECJALIZACJA SPECJALIZACJE { get; set; }
    }
}