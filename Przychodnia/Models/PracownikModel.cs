using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Przychodnia.Models
{
    public class PracownikModel
    {
        public int ID_Pracownik { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Adres { get; set; }
        public string Email { get; set; }

    }
}