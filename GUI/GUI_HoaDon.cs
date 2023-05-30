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
using System.Globalization;

namespace QuanLyPhongTro
{
    public partial class GUI_HoaDon : Form
    {
        public GUI_HoaDon()
        {
            InitializeComponent();
            txtKeyword.Text = "Nhập nội dung tìm kiếm";
            txtKeyword.ForeColor = Color.DarkGray;
        }

        BUS_HoaDon bushd = new BUS_HoaDon();
        BUS_HopDong bushdg = new BUS_HopDong();


        public event EventHandler ExitForm;


        public static string maHoaDon;
        private void GUI_HoaDon_Load(object sender, EventArgs e)
        {
            dgvHoaDon.DataSource = bushd.GetHoaDon();
            txtNgayLap.Text = DateTime.Now.ToShortDateString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            
                string maHoaDon = txtMaHoaDon.Text.Trim();
                string maQuanLy = txtMaQuanLy.Text.Trim();
                string maKhachHang = txtMaKhachHang.Text.Trim();
                DateTime ngayLap = DateTime.Parse(txtNgayLap.Text.Trim());
                DateTime ngayThanhToan = DateTime.Parse(txtNgayLap.Text.Trim());
                int tongTien = int.Parse(txtTongTien.Text.Trim());
                string loaiThanhToan = txtLoaiThanhToan.Text.Trim();
                string trangThai = txtTrangThai.Text.Trim();


                HoaDon kh = new HoaDon(maHoaDon, maQuanLy, maKhachHang, ngayLap, ngayThanhToan, tongTien, loaiThanhToan, trangThai);
                bushd.AddHoaDon(kh);
                MessageBox.Show("Thêm thông tin hóa đơn thành công!");
            try
            {
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Reset();
                GUI_HoaDon_Load(sender, e);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string maHoaDon = txtMaHoaDon.Text.Trim();
            string maQuanLy = txtMaQuanLy.Text.Trim();
            string maKhachHang = txtMaKhachHang.Text.Trim();
            DateTime ngayLap = DateTime.Parse(txtNgayLap.Text.Trim());
            DateTime ngayThanhToan = DateTime.Parse(txtNgayLap.Text.Trim());
            int tongTien = int.Parse(txtTongTien.Text.Trim());
            string loaiThanhToan = txtLoaiThanhToan.Text.Trim();
            string trangThai = txtTrangThai.Text.Trim();


            HoaDon kh = new HoaDon(maHoaDon, maQuanLy, maKhachHang, ngayLap, ngayThanhToan, tongTien, loaiThanhToan, trangThai);
            bushd.EditHoaDon(kh);
            MessageBox.Show("Cập nhật thông tin hóa đơn thành công!");
            Reset();

            GUI_HoaDon_Load(sender, e);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string maHoaDon = txtMaHoaDon.Text;
                bushd.DeleteHoaDon(maHoaDon);
                GUI_HoaDon_Load(sender, e);
                Reset();
            }
        }


        private void dgvHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            txtMaHoaDon.Text = dgvHoaDon.CurrentRow.Cells[0].Value.ToString();
            txtMaQuanLy.Text = dgvHoaDon.CurrentRow.Cells[1].Value.ToString();
            txtMaKhachHang.Text = dgvHoaDon.CurrentRow.Cells[2].Value.ToString();
            txtNgayLap.Text = DateTime.Parse(dgvHoaDon.CurrentRow.Cells[3].Value.ToString()).ToShortDateString();
            txtNgayThanhToan.Text = DateTime.Parse(dgvHoaDon.CurrentRow.Cells[4].Value.ToString()).ToShortDateString();
            txtTongTien.Text = dgvHoaDon.CurrentRow.Cells[5].Value.ToString();
            txtLoaiThanhToan.Text = dgvHoaDon.CurrentRow.Cells[6].Value.ToString();
            txtTrangThai.Text = dgvHoaDon.CurrentRow.Cells[7].Value.ToString();
            dgvHoaDon.CurrentRow.ContextMenuStrip = cmsCTHD;

            maHoaDon = txtMaHoaDon.Text.Trim();
        }

        private void btnCTHoaDon_Click(object sender, EventArgs e)
        {
            GUI_ChiTietHD frm = new GUI_ChiTietHD();
            frm.ShowDialog();
            GUI_HoaDon_Load(sender, e);
        }


        private void btnSearch_Click(object sender, EventArgs e)
        {

            string keyWord = txtKeyword.Text;
            dgvHoaDon.DataSource = bushd.SearchHoaDon(keyWord);

            
        }

        private void btnKetXuat_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Microsoft Word | *.docx";
            saveFileDialog.Title = "Lưu thông tin hóa đơn";
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


        private void btnThoat_Click(object sender, EventArgs e)
        {
            ExitForm(this, new EventArgs());
        }

        void Reset()
        {
            txtMaHoaDon.Clear();
            txtMaQuanLy.Clear();
            txtMaKhachHang.Clear();
            txtNgayLap.Text = DateTime.Now.ToShortDateString();
            txtTongTien.Clear();
            txtLoaiThanhToan.Clear();
            txtTrangThai.Clear();
            txtNgayThanhToan.Clear();
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
            GUI_HoaDon_Load(sender, e);
            Reset();
        
        }


        private void txtMaKhachHang_Leave(object sender, EventArgs e)
        {
            string maKhachHang = txtMaKhachHang.Text.Trim();

            if (!bushdg.CheckDkHopDong(maKhachHang) && maKhachHang != "")
            {
                MessageBox.Show("Mã khách hàng này chưa được đăng ký hợp đồng!");
                Reset();
            }
            
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel (*.xlsx)|*.xlsx";
            saveFileDialog.Title = "Lưu thông tin hóa đơn";
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

        private void txtNgayThanhToan_Enter(object sender, EventArgs e)
        {
            string day = DateTime.Parse(txtNgayLap.Text.Trim()).Day.ToString();
            string month = (DateTime.Parse(txtNgayLap.Text.Trim()).Month + 1).ToString();
            string year = DateTime.Parse(txtNgayLap.Text.Trim()).Year.ToString();
            string date = $"{day}/{month}/{year}";
            DateTime ngaythanhtoan = DateTime.Parse(date);

            txtNgayThanhToan.Text = ngaythanhtoan.ToShortDateString();
        }
    }
}
