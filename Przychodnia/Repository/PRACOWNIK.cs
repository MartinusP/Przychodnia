namespace Przychodnia.Repository
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class PRACOWNIK
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PRACOWNIK()
        {
            this.ODDZIAL_PRACOWNIK = new HashSet<ODDZIAL_PRACOWNIK>();
            this.WIZYTY = new HashSet<WIZYTA>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_PRACOWNIK { get; set; }
        public string IMIE { get; set; }
        public string NAZWISKO { get; set; }
        public string ADRES { get; set; }
        [EmailAddress]
        public string EMAIL_KONTAKTOWY { get; set; }
        [Display(Name = "SPECJALIZACJA")]
        public Nullable<int> ID_SPECJALIZACJA { get; set; }
        public Nullable<int> ID_ODDZIAL_PRACOWNIK { get; set; }

        [NotMapped]
        [Display(Name = "NAZWISKO I IMIE PRACOWNIKA")]
        public string NazwiskoImie => NAZWISKO + " " + IMIE;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ODDZIAL_PRACOWNIK> ODDZIAL_PRACOWNIK { get; set; }
        public virtual ODDZIAL_PRACOWNIK ODDZIAL_PRACOWNIK1 { get; set; }
        public virtual DYZUR DYZUR { get; set; }
        public virtual SPECJALIZACJA SPECJALIZACJA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WIZYTA> WIZYTY { get; set; }
    }
}
