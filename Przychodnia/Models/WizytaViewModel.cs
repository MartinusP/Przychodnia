using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Przychodnia.Models
{
    public class WizytaViewModel
    {
        [Key]
        public int ID_WIZYTA { get; set; }
        [Required]
        public DateTime DATA_WIZYTY { get; set; }
        [Required]
        public int ID_SALA { get; set; }
        [Required]
        public int ID_PRACOWNIK { get; set; }
        [Required]
        public int ID_ODDZIAL { get; set; }
        [Required]
        public int ID_PACJENT { get; set; }
        [Required]
        public int ID_RECEPTA { get; set; }
        public string UWAGI { get; set; }

        public virtual ODDZIAL ODDZIAL { get; set; }
        public virtual PACJENT PACJENT { get; set; }
        public virtual PRACOWNIK PRACOWNIK { get; set; }
        public virtual RECEPTA RECEPTA { get; set; }
        public virtual SALA SALA { get; set; }
    }
}