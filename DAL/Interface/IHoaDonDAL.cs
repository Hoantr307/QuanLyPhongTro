using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface IHoaDonDAL
    {
        DataTable GetHoaDon();

        DataTable GetHoaDonByID(string maHoaDon);

        DataTable ThongKe(string keyword);

        void AddHoaDon(HoaDon hoaDon);

        void UpdateTongTien(string maHoaDon, string maCTHD, string maphong);

        void EditHoaDon(HoaDon hoaDon);

        void DeleteHoaDon(string maHoaDon);

        DataTable SearchHoaDon(string keyword);
    }
}
