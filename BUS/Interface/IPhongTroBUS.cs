using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.Interface
{
    public interface IPhongTroBUS
    {
        DataTable GetPhongTro();

        void AddPhongTro(PhongTro phongTro);

        void EditPhongTro(PhongTro phongTro);

        void DeletePhongTro(string maPhongTro);

        DataTable SearchPhongTro(string keyword);

        void KetXuatWord(string exportPath);

        void XuatExcel(string filePath);
    }
}
