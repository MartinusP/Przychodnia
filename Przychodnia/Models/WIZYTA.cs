using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Przychodnia.Models
{
    public partial class WIZYTA
    {
        public int ID_WIZYTA { get; set; }
        public Nullable<System.DateTime> DATA_WIZYTY { get; set; }
        public Nullable<int> ID_SALA { get; set; }
        public Nullable<int> ID_PRACOWNIK { get; set; }
        public Nullable<int> ID_ODDZIAL { get; set; }
        public Nullable<int> ID_PACJENT { get; set; }
        public string UWAGI { get; set; }

        public virtual ODDZIAL ODDZIAL { get; set; }
        public virtual PACJENT PACJENT { get; set; }
        public virtual PRACOWNIK PRACOWNIK { get; set; }
        public virtual SALA SALA { get; set; }
    }
}