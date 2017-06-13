namespace Przychodnia.Repository
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("RECEPTA")]
    public partial class RECEPTA
    {
        [Key]
        public int ID_RECEPTA { get; set; }
        public Nullable<System.DateTime> DATA_WYKORZYSTANIA { get; set; }
        public string NAZWA_LEKU { get; set; }
        public string UWAGI { get; set; }
    }
}
