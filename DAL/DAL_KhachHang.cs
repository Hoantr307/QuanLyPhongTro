using DAL.Interface;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_KhachHang : IKhachHangDAL
    {
        public DataTable GetKhachHang()
        {
            string query = $"SP_GetKhachHang";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public bool CheckKhachHang(string maKhachHang)
        {
            return DataProvider.Instance
                .ExecuteQuery("select * from KhachHang where MaKhachHang = '"+ maKhachHang +"'").Rows.Count > 0;
        }

        public bool AddKhachHang(KhachHang khachHang)
        {
            string query = $"SP_AddKhachHang @maKhachHang , @tenKhachHang , @gioiTinh , @ngaySinh , @queQuan ,  @dienThoai , @ngheNghiep , @cCCD ";
            return DataProvider.Instance.
                ExecuteNonQuery(query, new object[]
                {
                    khachHang.maKhachHang,
                    khachHang.tenKhachHang,
                    khachHang.gioiTinh,
                    khachHang.ngaySinh,
                    khachHang.queQuan,
                    khachHang.dienThoai,
                    khachHang.ngheNghiep,
                    khachHang.cCCD
                }) > 0;
        }

        public bool EditKhachHang(KhachHang khachHang)
        {
            string query = $"SP_EditKhachHang @maKhachHang , @tenKhachHang , @gioiTinh , @ngaySinh , @queQuan ,  @dienThoai , @ngheNghiep , @cCCD ";
            return DataProvider.Instance.
                ExecuteNonQuery(query, new object[]
                {
                    khachHang.maKhachHang,
                    khachHang.tenKhachHang,
                    khachHang.gioiTinh,
                    khachHang.ngaySinh,
                    khachHang.queQuan,
                    khachHang.dienThoai,
                    khachHang.ngheNghiep,
                    khachHang.cCCD
                }) > 0;
        }

        public bool DeleteKhachHang(string maKhachHang)
        {
            string query = $"SP_DeleteKhachHang @maKhachHang ";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { maKhachHang }) > 0;
        }

        public DataTable SearchKhachHang(string keyword)
        {
            string query = "SP_SearchKhachHang @key ";

            return DataProvider.Instance.ExecuteQuery(query, new object[] { keyword });
        }
    }
}
