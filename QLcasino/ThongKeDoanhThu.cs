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
    
    public partial class ThongKeDoanhThu
    {
        public int MaThongKe { get; set; }
        public int MaKhuVuc { get; set; }
        public Nullable<int> MaTroChoi { get; set; }
        public System.DateTime Ngay { get; set; }
        public decimal TongDoanhThu { get; set; }
        public Nullable<int> Thang { get; set; }
        public Nullable<int> Nam { get; set; }
    
        public virtual KhuVuc KhuVuc { get; set; }
        public virtual TroChoi TroChoi { get; set; }
    }
}