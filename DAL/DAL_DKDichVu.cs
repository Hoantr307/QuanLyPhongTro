using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_DKDichVu
    {
        public DataTable GetDichVu()
        {
            string query = "select * from DichVu";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public DataTable GetDangKyDV()
        {
            string query = "select dk.MaCTHD, dv.TenDichVu, dv.DonGia, dk.ngayDK, dk.ngayKT from DKDichVu dk " +
                "inner join DichVu dv on dk.MaDichVu = dv.MaDichVu";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public void AddDKDichVu(DKDichVu DKDichVu)
        {
            string query = $"SP_AddDkDichVu @maCTHD , @maDichVu  , @ngayDangKy  , @ngayKetThuc  ";
            DataProvider.Instance.
                ExecuteQuery(query, new object[]
                {
                    DKDichVu.maCTHD,
                    DKDichVu.maDichVu,
                    DKDichVu.ngayDK,
                    DKDichVu.ngayKT

                });
        }

        public void EditDKDichVu(DKDichVu DKDichVu)
        {
            string query = $"SP_EditDkDichVu @maCTHD , @maDichVu  , @ngayDangKy  , @ngayKetThuc  ";
            DataProvider.Instance.
                ExecuteQuery(query, new object[]
                {
                    DKDichVu.maCTHD,
                    DKDichVu.maDichVu,
                    DKDichVu.ngayDK,
                    DKDichVu.ngayKT
                });
        }

        public void DeleteDKDichVu(string maCtHD, string maDichVu)
        {
            string query = $"SP_DeleteDkDichVu @maCTHD , @maDichVu ";
            DataProvider.Instance.ExecuteQuery(query, new object[] { maCtHD , maDichVu });
        }

        public DataTable SearchDKDichVu(string keyword)
        {
            string query = "SP_SearchDKDichVu @key ";

            return DataProvider.Instance.ExecuteQuery(query, new object[] { keyword });
        }
    }
}
