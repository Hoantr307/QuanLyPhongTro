using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_BaoTri : IBaoTriDAL
    {
        public DataTable GetBaoTri()
        {
            string query = $"DisplayBaoTri";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public void AddBaoTri(BaoTri baoTri)
        {
            string query = $"SP_AddBaoTri @maBaoTri , @maPhong , @noiDung , @ngayBaoTri , @trangThai";
            DataProvider.Instance.
                ExecuteQuery(query, new object[]
                {
                    baoTri.maBaoTri,
                    baoTri.maPhong,
                    baoTri.noiDung,
                    baoTri.ngayBaoTri,
                    baoTri.trangThai

                });
        }

        public void EditBaoTri(BaoTri baoTri)
        {
            string query = $"SP_EditBaoTri @maBaoTri , @maPhong , @noiDung , @ngayBaoTri , @trangThai";
            DataProvider.Instance.
                ExecuteQuery(query, new object[]
                {
                    baoTri.maBaoTri,
                    baoTri.maPhong,
                    baoTri.noiDung,
                    baoTri.ngayBaoTri,
                    baoTri.trangThai
                });
        }

        public void DeleteBaoTri(string maBaoTri)
        {
            string query = $"SP_DeleteBaoTri @maBaoTri ";
            DataProvider.Instance.ExecuteQuery(query, new object[] { maBaoTri });
        }

        public DataTable SearchBaoTri(string keyword)
        {
            string query = "SP_SearchBaoTri @key ";

            return DataProvider.Instance.ExecuteQuery(query, new object[] { keyword });
        }
    }
}
