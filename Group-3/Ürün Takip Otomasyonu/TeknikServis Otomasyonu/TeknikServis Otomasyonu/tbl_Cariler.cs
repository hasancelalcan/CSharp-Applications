//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TeknikServis_Otomasyonu
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_Cariler
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_Cariler()
        {
            this.tbl_FaturaBilgi = new HashSet<tbl_FaturaBilgi>();
            this.tbl_UrunHaraket = new HashSet<tbl_UrunHaraket>();
            this.tbl_UrunKabul = new HashSet<tbl_UrunKabul>();
        }
    
        public int ID { get; set; }
        public string Ad { get; set; }
        public string Soyadı { get; set; }
        public string Telefon { get; set; }
        public string Mail { get; set; }
        public string Il { get; set; }
        public string Ilce { get; set; }
        public string Banka { get; set; }
        public string VergiDairesi { get; set; }
        public string VergiNo { get; set; }
        public string Statu { get; set; }
        public string Adres { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_FaturaBilgi> tbl_FaturaBilgi { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_UrunHaraket> tbl_UrunHaraket { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_UrunKabul> tbl_UrunKabul { get; set; }
    }
}
