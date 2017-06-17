using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Przychodnia.Models
{
    public class AuthorToBook2
    {
        [Key]
        public int ID_ODDZIAL_PRACOWNIK { get; set; }
        public int ID_PRACOWNIK { get; set; }
        public int ID_ODDZIAL { get; set; }


        public virtual Author Author2 { get; set; }
        public virtual Book2 Book2 { get; set; }
    }
}