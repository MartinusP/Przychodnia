namespace Przychodnia.Repository
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class ODDZIAL
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ODDZIAL()
        {
            this.DYZURY = new HashSet<DYZUR>();
            this.ODDZIAL_PRACOWNIK = new HashSet<ODDZIAL_PRACOWNIK>();
            this.PLACOWKI = new HashSet<PLACOWKA>();
            this.WIZYTY = new HashSet<WIZYTA>();
        } 

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_ODDZIAL { get; set; }
        public string NAZWA { get; set; }
        public string MIEJSCOWOSC { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DYZUR> DYZURY { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ODDZIAL_PRACOWNIK> ODDZIAL_PRACOWNIK { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PLACOWKA> PLACOWKI { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WIZYTA> WIZYTY { get; set; }
    }
}
