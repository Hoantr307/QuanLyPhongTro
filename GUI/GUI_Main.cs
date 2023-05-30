using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyPhongTro
{
    public partial class GUI_Main : Form
    {
        public GUI_Main()
        {
            InitializeComponent();
            guna2ShadowForm1.SetShadowForm(this);
        }

        public bool isExit = true;

        public event EventHandler Exit;

        
        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            Exit(this, new EventArgs());
        }

        private void GUI_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isExit)
            {
                Application.Exit();
            }
        }

        private void btnPhongTro_Click(object sender, EventArgs e)
        {
            GUI_PhongTro frm = new GUI_PhongTro();
            frm.Show();
            this.Hide();
            frm.ExitForm += Frm_ExitForm;
        }


        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            GUI_KhachHang frm = new GUI_KhachHang();
            frm.Show();
            this.Hide();
            frm.ExitForm += Frm_ExitForm;
        }


      

        private void btnHoaDon_Click(object sender, EventArgs e)
        {
            GUI_HoaDon frm = new GUI_HoaDon();
            frm.Show();
            this.Hide();
            frm.ExitForm += Frm_ExitForm;


        }
        private void Frm_ExitForm(object sender, EventArgs e)
        {
            Form frm = sender as Form;
            if (frm != null)
            {
                frm.Close();
            }
            this.Show();
        }

        private void btnBaoTri_Click(object sender, EventArgs e)
        {
            GUI_BaoTri frm = new GUI_BaoTri();
            frm.Show();
            this.Hide();
            frm.ExitForm += Frm_ExitForm;

        }

        private void btnHopDong_Click(object sender, EventArgs e)
        {
            GUI_HopDong frm = new GUI_HopDong();
            frm.Show();
            this.Hide();
            frm.ExitForm += Frm_ExitForm;
        }

        private void btnDichVu_Click(object sender, EventArgs e)
        {
            GUI_DKDichVu frm = new GUI_DKDichVu();
            frm.Show();
            this.Hide();
            frm.ExitForm += Frm_ExitForm;
        }

        private void btnDonGiaDienNuoc_Click(object sender, EventArgs e)
        {

        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            GUI_ThongKe frm = new GUI_ThongKe();
            frm.Show();
            this.Hide();
            frm.ExitForm += Frm_ExitForm;
        }
    }
}
