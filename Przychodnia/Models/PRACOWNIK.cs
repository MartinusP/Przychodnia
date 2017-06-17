﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Przychodnia.Models
{
    public class PRACOWNIK
    {

        [Key]
        public int ID_PRACOWNIK { get; set; }
        public string IMIE { get; set; }
        public string NAZWISKO { get; set; }

        public virtual ICollection<ODDZIAL_PRACOWNIK> ODDZIAL_PRACOWNICY { get; set; }
        public virtual ICollection<Pracownik_Specjalizacja> Pracownik_Specjalizacje { get; set; }

    }
}