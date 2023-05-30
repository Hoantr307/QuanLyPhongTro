using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using Clock;

namespace QuanLyPhongTro
{
    public partial class GUI_DangNhap : Form
    {
        public GUI_DangNhap()
        {
            InitializeComponent();
        }

        BUS_TaiKhoan tk = new BUS_TaiKhoan();

        public static string tenTaiKhoan;
        public static string matKhau;

        

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            tenTaiKhoan = txtTenTaiKhoan.Text;
            matKhau = txtMatKhau.Text;

            if (tenTaiKhoan != "" || matKhau != "")
            {
                if (tk.kiemTraTK(tenTaiKhoan,matKhau))
                {
                    GUI_Main frmMain = new GUI_Main();
                    frmMain.Show();
                    this.Hide();
                    frmMain.Exit += FrmMain_Exit;
                }
                else
                {
                    MessageBox.Show("Tài khoản mật khẩu không chính xác. Yêu cầu nhập lại!");
                }

            }
            else
            {
                MessageBox.Show("Bạn chưa nhập đầy đủ thông tin!");
            }
        }

        private void FrmMain_Exit(object sender, EventArgs e)
        {
            (sender as GUI_Main).isExit = false;
            (sender as GUI_Main).Close();
            this.Show();
        }


        private void txtTenTaiKhoan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Space)
            {
                e.Handled = true;
            }
        }

        private void txtMatKhau_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Space)
            {
                e.Handled = true;
            }
        }
       

        protected override void WndProc(ref Message message)
        {
            if (message.Msg == SingleInstance.WM_SHOWFIRSTINSTANCE)
            {
                ShowWindow();
            }
            base.WndProc(ref message);
        }

        public void ShowWindow()
        {
            Win32Api.ShowToFront(this.Handle);
        }

    }
}
