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
    
    public partial class TroChoi
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TroChoi()
        {
            this.BanChoi = new HashSet<BanChoi>();
            this.LichSuChoi = new HashSet<LichSuChoi>();
            this.ThongKeDoanhThu = new HashSet<ThongKeDoanhThu>();
        }
    
        public int MaTC { get; set; }
        public string TenTC { get; set; }
        public string LoaiTC { get; set; }
        public string LuatChoi { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BanChoi> BanChoi { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LichSuChoi> LichSuChoi { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ThongKeDoanhThu> ThongKeDoanhThu { get; set; }
    }
}