using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Przychodnia.Models
{
    public partial class SPECJALIZACJA
    {

        public SPECJALIZACJA()
        {
            this.PRACOWNICY = new HashSet<PRACOWNIK>();
        }
        [Key]
        public int ID_SPECJALIZACJA { get; set; }
        public string NAZWA { get; set; }


        public virtual ICollection<PRACOWNIK> PRACOWNICY { get; set; }
    }
}