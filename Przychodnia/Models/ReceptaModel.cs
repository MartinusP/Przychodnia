using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Przychodnia.Models
{
    public class ReceptaModel
    {
        public int ID_Recepta { get; set; }
        public DateTime Data_Wykorzystania { get; set; }
        public string Nazwa_Leku { get; set; }
        public string Uwagi { get; set; }
    }
}