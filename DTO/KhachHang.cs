using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class KhachHang
    {
        public string maKhachHang { get; set; }
        public string tenKhachHang { get; set; }
        public string gioiTinh { get; set; }
        public DateTime ngaySinh { get; set; }
        public string queQuan { get; set; }
        public string dienThoai { get; set; }
        public string ngheNghiep { get; set; }
        public string cCCD { get; set; }

        public KhachHang() { }
        public KhachHang(string maKhachHang, string tenKhachHang, string gioiTinh, DateTime ngaySinh, string queQuan, string dienThoai, string ngheNghiep, string cCCD)
        {
            this.maKhachHang = maKhachHang;
            this.tenKhachHang = tenKhachHang;
            this.gioiTinh = gioiTinh;
            this.ngaySinh = ngaySinh;
            this.queQuan = queQuan;
            this.dienThoai = dienThoai;
            this.ngheNghiep = ngheNghiep;
            this.cCCD = cCCD;
        }
    }
}
