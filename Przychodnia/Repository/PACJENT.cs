//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Przychodnia.Repository
{
    using System;
    using System.Collections.Generic;
    
    public partial class PACJENT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PACJENT()
        {
            this.WIZYTA = new HashSet<WIZYTA>();
        }
    
        public int ID_PACJENT { get; set; }
        public string IMIE { get; set; }
        public string NAZWISKO { get; set; }
        public string ADRES { get; set; }
        public Nullable<int> PESEL { get; set; }
        public string TELEFON_KONTAKTOWY { get; set; }
        public string EMAIL_KONTAKTOWY { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WIZYTA> WIZYTA { get; set; }
    }
}
