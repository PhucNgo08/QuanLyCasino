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
    
    public partial class DanhThu
    {
        public int MaDanhThu { get; set; }
        public Nullable<int> MaHoadon { get; set; }
        public Nullable<decimal> TongTien { get; set; }
        public Nullable<System.DateTime> NgayThu { get; set; }
        public Nullable<int> MaNV { get; set; }
    
        public virtual Hoadon Hoadon { get; set; }
        public virtual NhanVien NhanVien { get; set; }
    }
}