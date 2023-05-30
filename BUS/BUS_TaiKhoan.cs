using BUS.Helper;
using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class BUS_TaiKhoan
    {
        DAL_TaiKhoan dalTk = new DAL_TaiKhoan();



        public DataTable GetTaiKhoan(string tenTaiKhoan)
        {
            return dalTk.GetTaiKhoan(tenTaiKhoan);
        }

        public bool kiemTraTK(string tenTaiKhoan, string matKhau)
        {

            string hasPass = Encryption.Decrypt( GetTaiKhoan(tenTaiKhoan).Rows[0][2].ToString() );

            return matKhau == hasPass;
        }

        /*byte[] temp = ASCIIEncoding.ASCII.GetBytes(matKhau);
            byte[] hasData = new MD5CryptoServiceProvider().ComputeHash(temp);

            string hasPass = "";

            foreach (byte item in hasData)
            {
                hasPass += item;
            }*/
    }
}
