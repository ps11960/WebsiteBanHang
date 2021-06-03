using System;
using System.Collections.Generic;

namespace anhmtps11960_assignmentGD2_net104.Models
{
    public partial class DanhMuc
    {
        public DanhMuc()
        {
            SanPham = new HashSet<SanPham>();
        }

        public string MaDm { get; set; }
        public string LoaiDm { get; set; }

        public ICollection<SanPham> SanPham { get; set; }
    }
}
