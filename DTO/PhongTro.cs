using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PhongTro
    {
        public string maPhong { get; set; }
        public int soPhong { get; set; }
        public double dienTich { get; set; }
        public int giaThue { get; set; }
        public string tinhTrang { get; set; }

        public PhongTro() { }
        public PhongTro(string maPhong, int soPhong, double dienTich, int giaThue, string tinhTrang)
        {
            this.maPhong = maPhong;
            this.soPhong = soPhong;
            this.dienTich = dienTich;
            this.giaThue = giaThue;
            this.tinhTrang = tinhTrang;
        }
    }
}
