//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QLcasino
{
    using System;
    using System.Collections.Generic;
    
    public partial class BanChoi
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BanChoi()
        {
            this.BanChoiNguoi = new HashSet<BanChoiNguoi>();
            this.LichSuChoi = new HashSet<LichSuChoi>();
        }
    
        public int MaBC { get; set; }
        public Nullable<int> MaTC { get; set; }
        public Nullable<int> MaKV { get; set; }
        public string LoaiChoi { get; set; }
        public Nullable<int> SoNguoi { get; set; }
        public Nullable<int> MaTrangThai { get; set; }
    
        public virtual KhuVuc KhuVuc { get; set; }
        public virtual TroChoi TroChoi { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BanChoiNguoi> BanChoiNguoi { get; set; }
        public virtual TrangThai TrangThai { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LichSuChoi> LichSuChoi { get; set; }
    }
}
