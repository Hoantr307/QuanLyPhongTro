using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DKDichVu
    {
        public string maCTHD { get; set; }
        public string maDichVu { get; set; }
        public DateTime ngayDK { get; set; }
        public DateTime ngayKT { get; set; }
        public DKDichVu() { }
        public DKDichVu(string maCTHD, string maDichVu, DateTime ngayDK, DateTime ngayKT)
        {
            this.maCTHD = maCTHD;
            this.maDichVu = maDichVu;
            this.ngayDK = ngayDK;
            this.ngayKT = ngayKT;
        }
    }
}
