using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class BUS_DKDichVu
    {
        DAL_DKDichVu daldk = new DAL_DKDichVu();
        public DataTable GetDichVu()
        {
            return daldk.GetDichVu();
        }

        public DataTable GetDangKyDV()
        {
            return daldk.GetDangKyDV();
        }

        public void AddDKDichVu(DKDichVu DKDichVu)
        {
            daldk.AddDKDichVu(DKDichVu);
        }

        public void EditDKDichVu(DKDichVu DKDichVu)
        {
            daldk.EditDKDichVu(DKDichVu);
        }

        public void DeleteDKDichVu(string maCtHD, string maDichVu)
        {
            daldk.DeleteDKDichVu(maCtHD, maDichVu);
        }

    }
}
