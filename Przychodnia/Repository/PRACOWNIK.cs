//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Przychodnia.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class PRACOWNIK
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PRACOWNIK()
        {
            this.DYZURY = new HashSet<DYZUR>();
            this.ODDZIAL_PRACOWNIK = new HashSet<ODDZIAL_PRACOWNIK>();
            this.WIZYTY = new HashSet<WIZYTA>();
        }
    
        public int ID_PRACOWNIK { get; set; }
        public string IMIE { get; set; }
        public string NAZWISKO { get; set; }
        public string ADRES { get; set; }
        public string EMAIL_KONTAKTOWY { get; set; }
        public Nullable<int> ID_SPECJALIZACJA { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DYZUR> DYZURY { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ODDZIAL_PRACOWNIK> ODDZIAL_PRACOWNIK { get; set; }
        public virtual SPECJALIZACJA SPECJALIZACJA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WIZYTA> WIZYTY { get; set; }
    }
}
