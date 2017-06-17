using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Przychodnia.Models
{
    public class Author
    {
        [Key]
        public int ID_PRACOWNIK { get; set; }
        public string IMIE { get; set; }
        public string NAZWISKO { get; set; }

        public virtual ICollection<AuthorToBook> AuthorsToBooks { get; set; }
    }
}