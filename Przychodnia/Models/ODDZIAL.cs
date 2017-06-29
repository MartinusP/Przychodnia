using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Przychodnia.Models
{
    [Table("ODDZIAL")]
    public partial class ODDZIAL
    {
        public ODDZIAL()
        {
            this.DYZURY = new HashSet<DYZUR>();
            this.WIZYTY = new HashSet<WIZYTA>();
        }
        [Key]
        public int ID_ODDZIAL { get; set; }
        [Required]
        public string NAZWA { get; set; }
        [Required]
        public string MIEJSCOWOSC { get; set; }
        public int ID_PLACOWKA { get; set; }

        public virtual ICollection<DYZUR> DYZURY { get; set; }
        public virtual PLACOWKA PLACOWKA { get; set; }
        public virtual ICollection<ODDZIAL_PRACOWNIK> ODDZIAL_PRACOWNICY { get; set; }
        public virtual ICollection<WIZYTA> WIZYTY { get; set; }
    }
}