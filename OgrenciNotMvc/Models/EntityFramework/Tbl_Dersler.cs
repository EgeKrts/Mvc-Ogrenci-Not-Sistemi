//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OgrenciNotMvc.Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tbl_Dersler
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tbl_Dersler()
        {
            this.Tbl_Notlar = new HashSet<Tbl_Notlar>();
        }
    
        public byte DersID { get; set; }
        public string DersAd { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_Notlar> Tbl_Notlar { get; set; }
    }
}
