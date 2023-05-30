using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BUS.Interface;
using DAL;
using DTO;
using Novacode;

namespace BUS
{
    public class BUS_PhongTro : IPhongTroBUS
    {
        DAL_PhongTro dalpt = new DAL_PhongTro();

        public DataTable GetPhongTro()
        {
            return dalpt.GetPhongTro();
        }

        public void AddPhongTro(PhongTro phongTro)
        {
            dalpt.AddPhongTro(phongTro);
        }

        public void EditPhongTro(PhongTro phongTro)
        {
            dalpt.EditPhongTro(phongTro);
        }

        public void DeletePhongTro(string maPhongTro)
        {
            dalpt.DeletePhongTro(maPhongTro);
        }

        public DataTable SearchPhongTro(string keyword)
        {
            return dalpt.SearchPhongTro(keyword);
        }

        public void KetXuatWord(string exportPath)
        {
            WordHelper.ExportToWord(dalpt.GetPhongTro(), "Template\\PhongTro_Template.docx", exportPath);
        }

        public void XuatExcel(string filePath)
        {
            ExcelHelper.WriteExcelFile(filePath, "Template\\PhongTro_Template.xlsx", dalpt.GetPhongTro());
        }

    }
}
