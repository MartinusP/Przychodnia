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
    
    public partial class DYZUR
    {
        public int ID_DYZUR { get; set; }
        public Nullable<System.DateTime> DZIEN_DYZURU { get; set; }
        public Nullable<System.DateTime> OD { get; set; }
        public Nullable<System.DateTime> DO { get; set; }
        public int ID_PRACOWNIK { get; set; }
        public Nullable<int> ID_ODDZIAL { get; set; }
    
        public virtual ODDZIAL ODDZIAL { get; set; }
        public virtual PRACOWNIK PRACOWNIK { get; set; }
    }
}
