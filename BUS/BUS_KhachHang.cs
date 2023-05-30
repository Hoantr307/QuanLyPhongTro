using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing.Printing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BUS.Interface;
using DAL;
using DTO;


namespace BUS
{
    public class BUS_KhachHang : IKhachHangBUS
    {
        DAL_KhachHang dalkh = new DAL_KhachHang();

        public DataTable GetKhachHang()
        {
            return dalkh.GetKhachHang();
        }

        public bool CheckKhachHang(string maKhachHang)
        {
            return dalkh.CheckKhachHang(maKhachHang);
        }

        public bool AddKhachHang(KhachHang khachHang)
        {
            try
            {
                return dalkh.AddKhachHang(khachHang);

            }
            catch (Exception)
            {
                return false;
            }

        }

        public bool EditKhachHang(KhachHang khachHang)
        {
            return dalkh.EditKhachHang(khachHang);
        }

        public bool DeleteKhachHang(string maKhachHang)
        {
            return dalkh.DeleteKhachHang(maKhachHang);
        }

        public DataTable SearchKhachHang(string keyword)
        {
            return dalkh.SearchKhachHang(keyword);
        }

        public void KetXuatWord(string exportPath)
        {
            WordHelper.ExportToWord(dalkh.GetKhachHang(), "Template\\KhachHang_Template.docx", exportPath, new List<string>()
            {
                "MaKhachHang",
                "CCCD",
                "MaPhong"
            });
        }



        public void XuatExcel(string filePath)
        {
            ExcelHelper.WriteExcelFile(filePath, "Template\\KhachHang_Template.xlsx", dalkh.GetKhachHang());
        }


    }
}
