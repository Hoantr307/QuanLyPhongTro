using BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;

namespace QuanLyPhongTro
{
    public partial class GUI_HopDong : Form
    {
        public GUI_HopDong()
        {
            InitializeComponent();
            txtKeyword.Text = "Nhập nội dung tìm kiếm";
            txtKeyword.ForeColor = Color.DarkGray;
        }

        BUS_HopDong bushd = new BUS_HopDong();
        BUS_PhongTro buspt = new BUS_PhongTro();
        BUS_KhachHang busKh = new BUS_KhachHang();

        public event EventHandler ExitForm;

        private void GUI_HopDong_Load(object sender, EventArgs e)
        {
            dgvHopDong.DataSource = bushd.GetHopDong();

            cboMaPhong.DataSource = buspt.GetPhongTro();
            cboMaPhong.ValueMember = "MaPhong";
            cboMaPhong.DisplayMember = "SoPhong";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                string maHopDong = txtMaHopDong.Text.Trim();
                string maQuanLy = txtMaQuanLy.Text.Trim();
                string maKhachHang = txtMaKhachHang.Text.Trim();
                string maPhong = cboMaPhong.SelectedValue.ToString();
                DateTime ngayBatDau = DateTime.Parse(txtBatDau.Text);
                DateTime ngayKetThuc = DateTime.Parse(txtKetThuc.Text);
                HopDong hd = new HopDong(maHopDong, maQuanLy, maKhachHang, maPhong, ngayBatDau, ngayKetThuc);

                bushd.AddHopDong(hd);
                MessageBox.Show("Thêm thông tin hợp đồng thành công!");
                Reset();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                GUI_HopDong_Load(sender, e);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string maHopDong = txtMaHopDong.Text.Trim();
            string maQuanLy = txtMaQuanLy.Text.Trim();
            string maKhachHang = txtMaKhachHang.Text.Trim();
            string maPhong = cboMaPhong.SelectedValue.ToString();
            DateTime ngayBatDau = DateTime.Parse(txtBatDau.Text);
            DateTime ngayKetThuc = DateTime.Parse(txtKetThuc.Text);
            HopDong hd = new HopDong(maHopDong, maQuanLy, maKhachHang, maPhong, ngayBatDau, ngayKetThuc);

            bushd.EditHopDong(hd);
            MessageBox.Show("Cập nhật thông tin hợp đồng thành công!");
            Reset();

            GUI_HopDong_Load(sender, e);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string maHopDong = txtMaHopDong.Text;
                bushd.DeleteHopDong(maHopDong);
                GUI_HopDong_Load(sender, e);
                Reset();
            }
        }

        private void dgvHopDong_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            txtMaHopDong.Text = dgvHopDong.CurrentRow.Cells[0].Value.ToString();
            txtMaQuanLy.Text = dgvHopDong.CurrentRow.Cells[1].Value.ToString();
            txtMaKhachHang.Text = dgvHopDong.CurrentRow.Cells[2].Value.ToString();
            cboMaPhong.Text = dgvHopDong.CurrentRow.Cells[3].Value.ToString();
            txtBatDau.Text = Convert.ToDateTime(dgvHopDong.CurrentRow.Cells[4].Value).ToShortDateString();
            txtKetThuc.Text = Convert.ToDateTime(dgvHopDong.CurrentRow.Cells[5].Value).ToShortDateString();
            
        }




        private void btnSearch_Click(object sender, EventArgs e)
        {

            string keyWord = txtKeyword.Text;
            dgvHopDong.DataSource = bushd.SearchHopDong(keyWord);

        }

        private void btnKetXuat_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Microsoft Word | *.docx";
            saveFileDialog.Title = "Lưu thông tin hợp đồng";
            saveFileDialog.ShowDialog();
            if (saveFileDialog.FileName != "")
            {
                try
                {
                    bushd.KetXuatWord(saveFileDialog.FileName);
                    MessageBox.Show("Kết xuất thành công!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông báo lỗi");
                }

            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel (*.xlsx)|*.xlsx";
            saveFileDialog.Title = "Lưu thông tin hợp đồng";
            saveFileDialog.ShowDialog();
            if (saveFileDialog.FileName != "")
            {
                try
                {
                    bushd.XuatExcel(saveFileDialog.FileName);
                    MessageBox.Show("Kết xuất thành công!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông báo lỗi");
                }
            }
            
        }
        

        void Reset()
        {
            txtMaHopDong.Clear();
            txtMaQuanLy.Clear();
            txtMaKhachHang.Clear();
            txtBatDau.Clear();
            txtKetThuc.Clear();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            ExitForm(this, new EventArgs());
        }

        private void txtKeyword_Enter(object sender, EventArgs e)
        {
            if (txtKeyword.Text == "Nhập nội dung tìm kiếm")
            {
                txtKeyword.Text = "";
                txtKeyword.ForeColor = Color.Black;
            }
        }

        private void txtKeyword_Leave(object sender, EventArgs e)
        {
            if (txtKeyword.Text == "")
            {
                txtKeyword.Text = "Nhập nội dung tìm kiếm";
                txtKeyword.ForeColor = Color.DarkGray;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            GUI_HopDong_Load(sender, e);
            Reset();
        }

        private void txtMaKhachHang_Leave(object sender, EventArgs e)
        {
            string maKhachHang = txtMaKhachHang.Text.Trim();

            if (!busKh.CheckKhachHang(maKhachHang) && maKhachHang != "")
            {
                MessageBox.Show("Mã khách hàng này chưa tồi tại!");
                Reset();
            }
        }
    }
}
