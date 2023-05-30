using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_HopDong
    {
        public DataTable GetHopDong()
        {
            string query = $"SP_GetHopDong";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public bool CheckDkHopDong(string maKH)
        {
            string query = "SP_CheckDkHopDong @maKhachHang";
            return DataProvider.Instance.ExecuteQuery(query, new object[]
            {
                maKH
            }).Rows.Count > 0;
        }

        public void AddHopDong(HopDong hopDong)
        {
            string query = $"SP_AddHopDong @maHopDong , @maQuanLy , @maKhachHang , @maPhong , @ngayBatDau , @ngayKetThuc ";
            DataProvider.Instance.
                ExecuteQuery(query, new object[]
                {
                    hopDong.maHopDong,
                    hopDong.maQuanLy,
                    hopDong.maKhachHang,
                    hopDong.maPhong,
                    hopDong.ngayBatDau,
                    hopDong.ngayKetThuc,
                    
                });
        }

        public void EditHopDong(HopDong hopDong)
        {
            string query = $"SP_EditHopDong @maHopDong , @maQuanLy , @maKhachHang , @maPhong , @ngayBatDau , @ngayKetThuc ";
            DataProvider.Instance.
                ExecuteQuery(query, new object[]
                {
                    hopDong.maHopDong,
                    hopDong.maQuanLy,
                    hopDong.maKhachHang,
                    hopDong.maPhong,
                    hopDong.ngayBatDau,
                    hopDong.ngayKetThuc,
                });
        }

        public void DeleteHopDong(string maHopDong)
        {
            string query = $"SP_DeleteHopDong @maHopDong ";
            DataProvider.Instance.ExecuteQuery(query, new object[] { maHopDong });
        }

        public DataTable SearchHopDong(string keyword)
        {
            string query = "SP_SearchHopDong @key ";

            return DataProvider.Instance.ExecuteQuery(query, new object[] { keyword });
        }
    }
}
