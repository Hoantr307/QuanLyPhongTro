using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class QuanLy
    {

        public string maQuanLy { get; set; }
        public string hoTen { get; set; }
        public DateTime ngaySinh { get; set; }
        public string gioiTinh { get; set; }
        public string queQuan { get; set; }
        public string sDT { get; set; }
        public string email { get; set; }
        public string tenTaiKhoan { get; set; }


        public QuanLy() { }

        public QuanLy(string maQuanLy, string hoTen, DateTime ngaySinh, string gioiTinh, string queQuan, string sDT, string email, string tenTaiKhoan)
        {
            this.maQuanLy = maQuanLy;
            this.hoTen = hoTen;
            this.ngaySinh = ngaySinh;
            this.gioiTinh = gioiTinh;
            this.queQuan = queQuan;
            this.sDT = sDT;
            this.email = email;
            this.tenTaiKhoan = tenTaiKhoan;
        }
    }
}
