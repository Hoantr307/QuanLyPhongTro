using BUS;
using DTO;
using Guna.UI2.WinForms;
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
    public partial class GUI_ChiTietHD : Form
    {
        public GUI_ChiTietHD()
        {
            InitializeComponent();
            guna2ShadowForm1.SetShadowForm(this);
        }

        BUS_CTHoaDon busCt = new BUS_CTHoaDon();
        BUS_DKDichVu busDk = new BUS_DKDichVu();
        BUS_HoaDon busHd = new BUS_HoaDon();

        private void GUI_ChiTietHD_Load(object sender, EventArgs e)
        {

            cboDichVu.DataSource = busDk.GetDichVu();
            cboDichVu.ValueMember = "MaDichVu";
            cboDichVu.DisplayMember = "TenDichVu";
            cboDichVu.SelectedIndex = 0;

            DataTable dt = busCt.GetPhongTroByHdId(GUI_HoaDon.maHoaDon);
            txtCthdID.Text = "ct" + GUI_HoaDon.maHoaDon;
            txtMaHoaDon.Text = GUI_HoaDon.maHoaDon;

            if (dt.Rows.Count > 0)
            {
                txtTienPhong.Text = dt.Rows[0][3].ToString();
                txtMaPhong.Text = dt.Rows[0][0].ToString();
                
            }
            else
            {
                MessageBox.Show("Khách hàng này chưa được đăng ký thuê trọ!");
            }

            try
            {
                DataTable dt1 = busCt.GetCTHoaDonById(txtCthdID.Text);
                txtCthdID.Text = dt1.Rows[0][0].ToString();
                txtSoDien.Text = dt1.Rows[0][4].ToString();
                txtSoNuoc.Text = dt1.Rows[0][5].ToString();

            }
            catch (Exception)
            {

            }

        }

        private void btnDKDichVu_Click(object sender, EventArgs e)
        {
            GUI_DKDichVu f = new GUI_DKDichVu();
            f.ShowDialog();
        }


        private void btnDKDichVu_Click_1(object sender, EventArgs e)
        {
            pnlCTHD.Visible = false;
            txtMaCthd.Text = txtCthdID.Text;
        }

        private void btnCTHD_Click(object sender, EventArgs e)
        {
            pnlCTHD.Visible = true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                string maCtHd = txtCthdID.Text;
                string maHoaDon = txtMaHoaDon.Text;
                string maPhong = txtMaPhong.Text;
                int soDien = int.Parse(txtSoDien.Text);
                int soNuoc = int.Parse(txtSoNuoc.Text);

                ChiTietHoaDon ct = new ChiTietHoaDon(maCtHd, maHoaDon, maPhong, soDien, soNuoc);
                busCt.AddOrUpdateCTHoaDon(ct);
                MessageBox.Show("Lưu thàng công");

                busHd.UpdateTongTien(maHoaDon, maCtHd, maPhong);

                GUI_ChiTietHD_Load(sender, e);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            

        }

        private void btnDKDV_Click(object sender, EventArgs e)
        {
            try 
            { 
                string maCTHD = txtMaCthd.Text.Trim();
                string maDichVu = cboDichVu.SelectedValue.ToString();
                DateTime ngayDK = DateTime.Parse(txtNgayDK.Text.Trim());
                DateTime ngayKT = DateTime.Parse(txtNgayKT.Text.Trim());


                DKDichVu dk = new DKDichVu(maCTHD, maDichVu, ngayDK, ngayKT);
                busDk.AddDKDichVu(dk);
                MessageBox.Show("Thêm thông tin thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                GUI_ChiTietHD_Load(sender, e);
            }
        }

        private void btnInHD_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Microsoft Word | *.docx";
            saveFileDialog.Title = "Lưu thông tin đăng ký dịch vụ";
            saveFileDialog.ShowDialog();
            if (saveFileDialog.FileName != "")
            {
                try
                {
                    busCt.KetXuatWord(saveFileDialog.FileName, new List<int>()
                    {
                        int.Parse(txtSoDien.Text.Trim()),
                        int.Parse(txtSoNuoc.Text.Trim()),
                        int.Parse(txtTienPhong.Text.Trim()),

                    }, txtMaHoaDon.Text);
                    MessageBox.Show("Kết xuất thành công!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông báo lỗi");
                }

            }
        }
    }
}
