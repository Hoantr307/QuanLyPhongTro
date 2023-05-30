using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_CTHoaDon
    {
        public DataTable GetPhongTroByHdId(string maHoaDon)
        {
            string query = "GetPhongTroByHdId @maHoaDon";
            return DataProvider.Instance.ExecuteQuery(query, new object[]
            {
                maHoaDon
            });
        }

        public DataTable GetCTHoaDonById(string maCt)
        {
            string query = "select * from ChiTietHoaDon where MaCTHD = '" + maCt +"'";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public DataTable GetDonGia()
        {
            string query = "select GiaDien, GiaNuoc from DonGiaDienNuoc";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public void AddOrUpdateCTHoaDon(ChiTietHoaDon ct)
        {
            string query = "AddOrUpdateCTHoaDon @maCTHD , @maHoaDon , @maPhong , @soDien , @soNuoc ";
            DataProvider.Instance.ExecuteNonQuery(query, new object[]
            {
                ct.maCtHd,
                ct.maHoaDon,
                ct.maPhong,
                ct.soDien,
                ct.soNuoc
            });
        }

   
    }
}
