using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Przychodnia.Models
{
    public partial class RECEPTA
    {
        public int ID_RECEPTA { get; set; }
        public Nullable<System.DateTime> DATA_WYKORZYSTANIA { get; set; }
        public string NAZWA_LEKU { get; set; }
        public string UWAGI { get; set; }
    }
}