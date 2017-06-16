using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Przychodnia.Models
{
    public class CheckBoxViewModel
    {
        [Key]
        public int ID_CheckBoxViewModel { get; set; }
        public string Nazwa { get; set; }
        public bool Zaznaczenie { get; set; }
    }
}