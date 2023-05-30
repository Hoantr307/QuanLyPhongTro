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
    public class DAL_PhongTro : IPhongTroDAL
    {
        public DataTable GetPhongTro()
        {
            string query = $"Select * from PhongTro";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public void AddPhongTro(PhongTro phongTro)
        {
            string query = $"SP_AddPhongTro @maPhong , @soPhong , @dienTich , @giaThue , @tinhTrang ";
            DataProvider.Instance.
                ExecuteQuery(query, new object[]
                {
                    phongTro.maPhong,
                    phongTro.soPhong,
                    phongTro.dienTich,
                    phongTro.giaThue,
                    phongTro.tinhTrang,
                    
                });
        }

        public void EditPhongTro(PhongTro phongTro)
        {
            string query = $"SP_EditPhongTro @maPhong , @soPhong , @dienTich , @giaThue , @tinhTrang ";
            DataProvider.Instance.
                ExecuteQuery(query, new object[]
                {
                    phongTro.maPhong,
                    phongTro.soPhong,
                    phongTro.dienTich,
                    phongTro.giaThue,
                    phongTro.tinhTrang,
                });
        }

        public void DeletePhongTro(string maPhongTro)
        {
            string query = $"SP_DeletePhongTro @maPhong ";
            DataProvider.Instance.ExecuteQuery(query, new object[] { maPhongTro });
        }

        public DataTable SearchPhongTro(string keyword)
        {
            string query = "SP_SearchPhongTro @key ";

            return DataProvider.Instance.ExecuteQuery(query, new object[] { keyword });
        }
    }
}
