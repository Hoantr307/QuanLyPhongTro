using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface IKhachHangDAL
    {
        DataTable GetKhachHang();

        bool CheckKhachHang(string maKhachHang);

        bool AddKhachHang(KhachHang khachHang);

        bool EditKhachHang(KhachHang khachHang);

        bool DeleteKhachHang(string maKhachHang);

        DataTable SearchKhachHang(string keyword);
    }
}
