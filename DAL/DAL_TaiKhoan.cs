using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_TaiKhoan
    {
        public DataTable GetTaiKhoan(string tenTaiKhoan)
        {
            string query = $"select * from TaiKhoan where TenTaiKhoan = '{tenTaiKhoan}'";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            return data;
        }

        public DataTable GetThongTinQL(string tenTaiKhoan)
        {
            string query = $"select * from QuanLy Where TenTaiKhoan = '{tenTaiKhoan}'"; 
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            return data;
        }
    }
}
