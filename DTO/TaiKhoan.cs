using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class TaiKhoan
    {
        public string tenTaiKhoan { get; set; }
        public string matKhau { get; set; }
        public TaiKhoan() { }
        public TaiKhoan(string tenTaiKhoan, string maKhau) 
        { 
            this.tenTaiKhoan= tenTaiKhoan;
            this.matKhau= maKhau;
        }
        public TaiKhoan(DataRow row)
        {
            this.tenTaiKhoan = row["TenTaiKhoan"].ToString();
            this.matKhau = row["MatKhau"].ToString();
        }


    }
}
