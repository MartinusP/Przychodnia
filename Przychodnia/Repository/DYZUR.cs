namespace Przychodnia.Repository
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class DYZUR
    {

        [Display(Name = "Employee", ResourceType = typeof(App_GlobalResources.MultiLanguage))]
        public int ID_PRACOWNIK { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "DutyDay", ResourceType = typeof(App_GlobalResources.MultiLanguage))]
        public Nullable<System.DateTime> DZIEN_DYZURU { get; set; }
        [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
        [Display(Name = "From", ResourceType = typeof(App_GlobalResources.MultiLanguage))]
        public Nullable<System.DateTime> OD { get; set; }
        [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
        [Display(Name = "To", ResourceType = typeof(App_GlobalResources.MultiLanguage))]
        public Nullable<System.DateTime> DO { get; set; }
        [Display(Name = "HospitalWard", ResourceType = typeof(App_GlobalResources.MultiLanguage))]
        public Nullable<int> ID_ODDZIAL { get; set; }
    
        public virtual ODDZIAL ODDZIAL { get; set; }
        public virtual PRACOWNIK PRACOWNIK { get; set; }
    }
}
