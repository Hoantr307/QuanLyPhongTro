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
    public class BUS_BaoTri : IBaoTriBUS
    {
        DAL_BaoTri dalbt = new DAL_BaoTri();

        public DataTable GetBaoTri()
        {
            return dalbt.GetBaoTri();
        }

        public void AddBaoTri(BaoTri BaoTri)
        {
            dalbt.AddBaoTri(BaoTri);
        }

        public void EditBaoTri(BaoTri BaoTri)
        {
            dalbt.EditBaoTri(BaoTri);
        }

        public void DeleteBaoTri(string maBaoTri)
        {
            dalbt.DeleteBaoTri(maBaoTri);
        }

        public DataTable SearchBaoTri(string keyword)
        {
            return dalbt.SearchBaoTri(keyword);
        }

        public void KetXuatWord(string exportPath)
        {
            WordHelper.ExportToWord(dalbt.GetBaoTri(), "Template\\BaoTri_Template.docx", exportPath);
        }

        public void XuatExcel(string filePath)
        {
            ExcelHelper.WriteExcelFile(filePath, "Template\\BaoTri_Template.xlsx", dalbt.GetBaoTri());
        }
    }
}
