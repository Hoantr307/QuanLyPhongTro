using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.Interface
{
    public interface IHoaDonBUS
    {
        DataTable GetHoaDon();

        DataTable ThongKe(string keyword);

        void AddHoaDon(HoaDon hoaDon);

        void EditHoaDon(HoaDon hoaDon);

        void UpdateTongTien(string maHoaDon, string maCTHD, string maphong);

        void DeleteHoaDon(string maHoaDon);

        DataTable SearchHoaDon(string keyword);

        void KetXuatWord(string exportPath);

        void XuatExcel(string filePath);
    }
}
