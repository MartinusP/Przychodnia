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
        public string Nazwisko { get; set; }
        public List<CheckBoxViewModel> Oddzialy { get; set; }
    }
}