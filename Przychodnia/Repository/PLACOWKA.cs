namespace Przychodnia.Repository
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("PLACOWKA")]
    public partial class PLACOWKA
    {
        [Key]
        public int ID_PLACOWKA { get; set; }
        public string NAZWA { get; set; }
        public string MIEJSCOWOSC { get; set; }
        public string ADRES { get; set; }
        public Nullable<int> ID_ODDZIAL { get; set; }
    
        public virtual ODDZIAL ODDZIAL { get; set; }
    }
}
