using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Przychodnia.Models
{
    public class Book
    {
        [Key]
        public int ID_ODDZIAL { get; set; }
        public string NAZWA { get; set; }

        public virtual ICollection<AuthorToBook> AuthorsToBooks { get; set; }
    }
}