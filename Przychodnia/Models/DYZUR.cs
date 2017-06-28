using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Przychodnia.Models
{
    public partial class DYZUR
    {
        [Key]
        public int ID_DYZUR { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime DZIEN_DYZURU { get; set; }
        public Nullable<System.DateTime> OD { get; set; }
        public Nullable<System.DateTime> DO { get; set; }
        public int ID_PRACOWNIK { get; set; }
        public Nullable<int> ID_ODDZIAL { get; set; }

        public virtual ODDZIAL ODDZIAL { get; set; }
        public virtual PRACOWNIK PRACOWNIK { get; set; }
    }
}