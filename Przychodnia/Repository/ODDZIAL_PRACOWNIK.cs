namespace Przychodnia.Repository
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class ODDZIAL_PRACOWNIK
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ODDZIAL_PRACOWNIK()
        {
            this.PRACOWNICY = new HashSet<PRACOWNIK>();
        } 

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_ODDZIAL_PRACOWNIK { get; set; }
        public Nullable<int> ID_PRACOWNIK { get; set; }
        public Nullable<int> ID_ODDZIAL { get; set; }
    
        public virtual ODDZIAL ODDZIAL { get; set; }
        public virtual PRACOWNIK PRACOWNIK { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PRACOWNIK> PRACOWNICY { get; set; }
    }
}
