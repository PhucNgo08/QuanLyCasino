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
    
    public partial class LichLamViec
    {
        public int MaLichLam { get; set; }
        public int MaNV { get; set; }
        public System.DateTime Ngay { get; set; }
        public string CaLam { get; set; }
        public Nullable<int> MaKhuVuc { get; set; }
    
        public virtual KhuVuc KhuVuc { get; set; }
        public virtual NhanVien NhanVien { get; set; }
    }
}