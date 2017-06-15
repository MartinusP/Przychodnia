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
        [Display(Name = "DATA WIZYTY")]
        public Nullable<System.DateTime> DATA_WIZYTY { get; set; }
        [Display(Name = "SALA")]
        public Nullable<int> ID_SALA { get; set; }
        [Display(Name = "PRACOWNIK")]
        public Nullable<int> ID_PRACOWNIK { get; set; }
        [Display(Name = "ODDZIA£")]
        public Nullable<int> ID_ODDZIAL { get; set; }
        [Display(Name = "PACJENT")]
        public Nullable<int> ID_PACJENT { get; set; }
        public string UWAGI { get; set; }
    
        public virtual ODDZIAL ODDZIAL { get; set; }
        public virtual PACJENT PACJENT { get; set; }
        public virtual PRACOWNIK PRACOWNIK { get; set; }
        public virtual SALA SALA { get; set; }
    }
}
