using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class HopDong
    {
        public string maHopDong { get; set; }
        public string maQuanLy { get; set; }
        public string maKhachHang { get; set; }
        public string maPhong { get; set; }
        public DateTime ngayBatDau { get; set; }
        public DateTime ngayKetThuc { get; set; }

        public HopDong() { }
        public HopDong(string maHopDong, string maQuanLy, string maKhachHang, string maPhong, DateTime ngayBatDau, DateTime ngayKetThuc)
        {
            this.maHopDong = maHopDong;
            this.maQuanLy = maQuanLy;
            this.maKhachHang = maKhachHang;
            this.maPhong = maPhong;
            this.ngayBatDau = ngayBatDau;
            this.ngayKetThuc = ngayKetThuc;
        }
    }
}
