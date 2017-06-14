namespace Przychodnia.Repository
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class RECEPTA
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_RECEPTA { get; set; }
        public Nullable<System.DateTime> DATA_WYKORZYSTANIA { get; set; }
        public string NAZWA_LEKU { get; set; }
        public string UWAGI { get; set; }
    }
}
