using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Przychodnia.Models
{
    [Table("ODDZIAL")]
    public class OddzialModel
    {
        [Key]
        public int ID_Oddzial { get; set; }
        public string Nazwa { get; set; }
        public string Miejscowosc { get; set; }
        
    }
}