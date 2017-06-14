namespace Przychodnia.Repository
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class WIZYTA
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_WIZYTA { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
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
