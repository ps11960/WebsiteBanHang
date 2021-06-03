using System;
using System.Collections.Generic;

namespace anhmtps11960_assignmentGD2_net104.Models
{
    public class SanPham
    {
        public int MaSp { get; set; }
        public string TenSp { get; set; }
        public string GiaSp { get; set; }
        public string ThongtinSp { get; set; }
        public string Hinhanh { get; set; }
        public string LoaiSp { get; set; }
        public string MaDm { get; set; }

        public DanhMuc MaDmNavigation { get; set; }
    }
}
