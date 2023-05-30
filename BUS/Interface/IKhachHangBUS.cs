using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.Interface
{
    public interface IKhachHangBUS
    {
        DataTable GetKhachHang();

        bool CheckKhachHang(string maKhachHang);

        bool AddKhachHang(KhachHang khachHang);

        bool EditKhachHang(KhachHang khachHang);

        bool DeleteKhachHang(string maKhachHang);

        DataTable SearchKhachHang(string keyword);

        void KetXuatWord(string exportPath);

        void XuatExcel(string filePath);

    }
}
