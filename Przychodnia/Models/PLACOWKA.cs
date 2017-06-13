using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Przychodnia.Models
{
    public partial class PLACOWKA
    {
        public int ID_PLACOWKA { get; set; }
        public string NAZWA { get; set; }
        public string MIEJSCOWOSC { get; set; }
        public string ADRES { get; set; }
        public Nullable<int> ID_ODDZIAL { get; set; }

        public virtual ODDZIAL ODDZIAL { get; set; }
    }
}