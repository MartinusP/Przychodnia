using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Przychodnia.Models
{
    public class PracownikOddzialViewModel
    {
        public int ID_PRACOWNIK { get; set; }
        public string IMIE { get; set; }
        public string NAZWISKO { get; set; }
        public string ADRES { get; set; }
        public string EMAIL_KONTAKTOWY { get; set; }
        //public List<CheckBoxViewModel> Specjalizacje { get; set; }
        public List<CheckBoxViewModel> Oddzialy { get; set; }
    }
}