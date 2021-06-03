using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace anhmtps11960_assignmentGD2_net104.Models
{
    public class ProductModel
    {
        private QuanLyBHContext db = new QuanLyBHContext();
        public List<SanPham> DSdt()
        {
            var ls = db.SanPham.ToList() ;
            var lsPhone = from dienthoais in ls
                          where dienthoais.MaDm == "002"
                          select dienthoais;
            return lsPhone.ToList();
        }
        public List<SanPham> DSlt()
        {
            var ls = db.SanPham.ToList();
            var lsLap = from laptops in ls
                          where laptops.MaDm == "001"
                        select laptops;
            return lsLap.ToList();
        }
        public List<SanPham> DSdh()
        {
            var ls = db.SanPham.ToList();
            var lsDH = from donghos in ls
                        where donghos.MaDm == "003"
                        select donghos;
            return lsDH.ToList();
        }
        public List<SanPham> FindAll()
        {

            var a = db.SanPham.ToList();
            return a;

        }

        public SanPham Find(int id)
        {
            var a = db.SanPham.Find(id);
            return a;
        }
    }
}
