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
    
    public partial class tbl_UrunHaraket
    {
        public int HaraketID { get; set; }
        public Nullable<int> Urun { get; set; }
        public Nullable<int> Musteri { get; set; }
        public Nullable<short> Personel { get; set; }
        public Nullable<System.DateTime> Tarih { get; set; }
        public Nullable<short> Adet { get; set; }
        public Nullable<decimal> Fiyat { get; set; }
        public string UrunSeriNo { get; set; }
    
        public virtual tbl_Cariler tbl_Cariler { get; set; }
        public virtual tbl_Personeller tbl_Personeller { get; set; }
        public virtual tbl_Urunler tbl_Urunler { get; set; }
    }
}
