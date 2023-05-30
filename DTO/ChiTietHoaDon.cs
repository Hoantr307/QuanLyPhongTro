using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ChiTietHoaDon
    {
        public string maCtHd { get; set; }
        public string maHoaDon { get; set; }
        public string maPhong { get; set; }
        public int soDien { get; set; }
        public int soNuoc { get; set; }

        public ChiTietHoaDon() { }
        public ChiTietHoaDon(string maCtHd, string maHoaDon, string maPhong,  int soDien, int soNuoc)
        {
            this.maCtHd = maCtHd;
            this.maHoaDon = maHoaDon;
            this.maPhong = maPhong;
            this.soDien = soDien;
            this.soNuoc = soNuoc;
        }
    }
}
