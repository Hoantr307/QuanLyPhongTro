using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BUS
{
    public class BUS_QuanLy
    {
        DAL_QuanLy dalQl = new DAL_QuanLy();

        public DataTable GetQuanLy(string tenTaiKhoan)
        {
            return dalQl.GetQuanLy(tenTaiKhoan);
        }
    }
}
