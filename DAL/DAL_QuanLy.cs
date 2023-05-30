using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_QuanLy
    {
        public DataTable GetQuanLy(string tenTaiKhoan)
        {
            string query = $"select * from QuanLy where TenTaiKhoan = '{tenTaiKhoan}'";
            return DataProvider.Instance.ExecuteQuery(query); ;
        }
    }
}
