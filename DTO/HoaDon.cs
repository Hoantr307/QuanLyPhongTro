using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class HoaDon
    {
        public string maHoaDon { get; set; }
        public string maQuanLy { get; set; }
        public string maKhachHang { get; set; }
        public DateTime ngayLap { get; set; }
        public DateTime ngayThanhToan { get; set; }
        public int tongTien { get; set; }
        public string loaiThanhToan { get; set; }
        public string trangThai { get; set; }

        public HoaDon() { }
        public HoaDon(string maHoaDon, string maQuanLy, string maKhachHang, DateTime ngayLap, DateTime ngayThanhToan, int tongTien, string loaiThanhToan, string trangThai)
        {
            this.maHoaDon = maHoaDon;
            this.maQuanLy = maQuanLy;
            this.maKhachHang = maKhachHang;
            this.ngayLap = ngayLap;
            this.ngayThanhToan = ngayThanhToan;
            this.tongTien = tongTien;
            this.loaiThanhToan = loaiThanhToan;
            this.trangThai = trangThai;
        }

       
    }
}
