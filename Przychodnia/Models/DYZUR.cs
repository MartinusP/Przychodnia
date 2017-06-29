using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Przychodnia.Models
{
    [Table("DYZUR")]
    public partial class DYZUR
    {
        [Key]
        public int ID_DYZUR { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime DZIEN_DYZURU { get; set; }
        [Required]
        public DateTime OD { get; set; }
        [Required]
        public DateTime DO { get; set; }
        [Required]
        public int ID_PRACOWNIK { get; set; }
        public int ID_ODDZIAL { get; set; }

        public virtual ODDZIAL ODDZIAL { get; set; }
        public virtual PRACOWNIK PRACOWNIK { get; set; }
    }
}