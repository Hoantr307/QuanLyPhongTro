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
    public class BUS_CTHoaDon
    {
        DAL_CTHoaDon dalct =  new DAL_CTHoaDon();
        DAL_HoaDon dalHd =new DAL_HoaDon();
        public DataTable GetPhongTroByHdId(string maHoaDon)
        {
            return dalct.GetPhongTroByHdId(maHoaDon);
        }

        public DataTable GetCTHoaDonById(string maCt)
        {
            return dalct.GetCTHoaDonById(maCt);
        }

        public DataTable GetDonGia()
        {
            return dalct.GetDonGia();
        }

        public void AddOrUpdateCTHoaDon(ChiTietHoaDon ct)
        {
            dalct.AddOrUpdateCTHoaDon(ct);
        }

        public DataTable TaoBangHoaDon(int soDien, int soNuoc, int tienPhong)
        {
            // Tạo DataTable và thêm cột
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("NoiDung");
            dataTable.Columns.Add("SoLuong");
            dataTable.Columns.Add("DonGia");
            dataTable.Columns.Add("ThanhTien");

            int donGiaDien = (int)GetDonGia().Rows[0][0];
            int donGiaNuoc = (int)GetDonGia().Rows[0][1];

            dataTable.Rows.Add( "Tiền điện", soDien, donGiaDien, soDien * donGiaDien );
            dataTable.Rows.Add( "Tiền nước", soNuoc, donGiaNuoc, soNuoc * donGiaNuoc );
            dataTable.Rows.Add( "Tiền phòng", null, tienPhong, tienPhong );

            return dataTable;
        }


        public void KetXuatWord(string exportPath , List<int> gia, string maHoaDon)
        {
            int tongTien = (int)dalHd.GetHoaDonByID(maHoaDon).Rows[0][5];
            WordHelper.ExportToWord2(TaoBangHoaDon(gia[0], gia[1], gia[2]), "Template\\PhieuHoaDon_Template.docx", exportPath, tongTien);
        }



    }
}
