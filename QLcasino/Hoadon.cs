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
    
    public partial class Hoadon
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Hoadon()
        {
            this.DanhThu = new HashSet<DanhThu>();
        }
    
        public int MaHoadon { get; set; }
        public Nullable<int> MaTrangThai { get; set; }
        public string LoaiGiaoDich { get; set; }
        public Nullable<System.DateTime> NgayGiaoDich { get; set; }
        public Nullable<decimal> SoTien { get; set; }
        public Nullable<int> MaKhachhang { get; set; }
        public Nullable<int> MaDV { get; set; }
        public Nullable<int> MaKM { get; set; }
        public Nullable<System.DateTime> NgayThanhToan { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DanhThu> DanhThu { get; set; }
        public virtual DichVu DichVu { get; set; }
        public virtual Khachhang Khachhang { get; set; }
        public virtual KhuyenMai KhuyenMai { get; set; }
        public virtual TrangThai TrangThai { get; set; }
    }
}
