using BUS.Interface;
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
    public class BUS_HoaDon : IHoaDonBUS
    {
        DAL_HoaDon dalhd = new DAL_HoaDon();
        public DataTable GetHoaDon()
        {
            return dalhd.GetHoaDon();
        }

        public DataTable ThongKe(string keyword)
        {
            return dalhd.ThongKe(keyword);
        }

        public void AddHoaDon(HoaDon hoaDon)
        {
            dalhd.AddHoaDon(hoaDon);
        }

        public void EditHoaDon(HoaDon hoaDon)
        {
            dalhd.EditHoaDon(hoaDon);
        }

        public void UpdateTongTien(string maHoaDon, string maCTHD, string maphong)
        {
            dalhd.UpdateTongTien(maHoaDon, maCTHD, maphong);
        }

        public void DeleteHoaDon(string maHoaDon)
        {
            dalhd.DeleteHoaDon(maHoaDon);
        }

        public DataTable SearchHoaDon(string keyword)
        {
            return dalhd.SearchHoaDon(keyword);
        }




        public void KetXuatWord(string exportPath)
        {
            WordHelper.ExportToWord(dalhd.GetHoaDon(), "Template\\HoaDon_Template.docx", exportPath, new List<string>()
            {
                "MaQuanLy",
                "LoaiThanhToan"
            });
        }

        

        public void XuatExcel(string filePath)
        {
            ExcelHelper.WriteExcelFile(filePath, "Template\\HoaDon_Template.xlsx", dalhd.GetHoaDon());
        }

        public DataTable TaoBangHoaDon(int tongtien)
        {
            // Tạo DataTable và thêm cột
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("NoiDung");
            dataTable.Columns.Add("TongTien");

            dataTable.Rows.Add("Doanh thu theo tháng 5", tongtien + " đồng");


            return dataTable;
        }

        public int TinhTong(DataTable dataTable)
        {
            int sum = 0;
            foreach(DataRow row in dataTable.Rows)
            {
                sum += int.Parse(row[5].ToString());
            }
            return sum;
        }


        public void KetXuatWordThongKe(string exportPath, string thang)
        {
            WordHelper.ExportToWord2(TaoBangHoaDon(TinhTong(dalhd.ThongKe(thang))), "Template\\ThongKe_Template.docx", exportPath);
        }

        public void XuatExcelThongKe(string filePath, string thang)
        {
            ExcelHelper.WriteExcelFile(filePath, "Template\\HoaDon_Template.xlsx", dalhd.ThongKe(thang));
        }
    }
}
