using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Przychodnia.Models
{
    public class PacjentModel
    {
        public int ID_Pacjent { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Adres { get; set; }
        public string Pesel { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }

    }
}