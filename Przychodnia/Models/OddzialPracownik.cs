using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Przychodnia.Models
{
    public partial class ODDZIAL_PRACOWNIK
    {
        [Key]
        public int ID_ODDZIAL_PRACOWNIK { get; set; }
        public Nullable<int> ID_PRACOWNIK { get; set; }
        public Nullable<int> ID_ODDZIAL { get; set; }

        public virtual ODDZIAL ODDZIAL { get; set; }
        public virtual PRACOWNIK PRACOWNIK { get; set; }
    }
}