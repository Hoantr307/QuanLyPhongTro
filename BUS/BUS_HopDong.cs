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
    public class BUS_HopDong
    {
        DAL_HopDong dalhdg = new DAL_HopDong();
        public DataTable GetHopDong()
        {
            return dalhdg.GetHopDong();
        }

        public void AddHopDong(HopDong hopDong)
        {
            dalhdg.AddHopDong(hopDong);
        }

        public void EditHopDong(HopDong hopDong)
        {
            dalhdg.EditHopDong(hopDong);
        }

        public void DeleteHopDong(string maHopDong)
        {
            dalhdg.DeleteHopDong(maHopDong);
        }

        public DataTable SearchHopDong(string keyword)
        {
            return dalhdg.SearchHopDong(keyword);
        }


        public bool CheckDkHopDong(string maKH)
        {
            return dalhdg.CheckDkHopDong(maKH);
        }

        public void KetXuatWord(string exportPath)
        {

            WordHelper.ExportToWord(dalhdg.GetHopDong(), "Template\\HopDong_Template.docx", exportPath);

        }

        public void XuatExcel(string filePath)
        {
            ExcelHelper.WriteExcelFile(filePath, "Template\\HopDong_Template.xlsx", dalhdg.GetHopDong());
        }

    }
}
