using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Przychodnia.Models
{
    public partial class ODDZIAL
    {
        public ODDZIAL()
        {
            this.DYZURY = new HashSet<DYZUR>();
            this.WIZYTY = new HashSet<WIZYTA>();
        }
        [Key]
        public int ID_ODDZIAL { get; set; }
        public string NAZWA { get; set; }
        public string MIEJSCOWOSC { get; set; }
        public int ID_PLACOWKA { get; set; }

        public virtual ICollection<DYZUR> DYZURY { get; set; }
        public virtual PLACOWKA PLACOWKA { get; set; }
        public virtual ICollection<ODDZIAL_PRACOWNIK> ODDZIAL_PRACOWNICY { get; set; }
        public virtual ICollection<WIZYTA> WIZYTY { get; set; }
    }
}