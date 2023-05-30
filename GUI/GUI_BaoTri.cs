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
    public partial class GUI_BaoTri : Form
    {
        public GUI_BaoTri()
        {
            InitializeComponent();
            txtKeyword.Text = "Nhập nội dung tìm kiếm";
            txtKeyword.ForeColor = Color.DarkGray;
            txtNgayBaoTri.Text = DateTime.Now.ToShortDateString();

        }
        public event EventHandler ExitForm;


        BUS_BaoTri busbt = new BUS_BaoTri();
        BUS_PhongTro buspt = new BUS_PhongTro();

        private void GUI_BaoTri_Load(object sender, EventArgs e)
        {
            dgvBaoTri.DataSource = busbt.GetBaoTri();
            cboMaPhong.DataSource = buspt.GetPhongTro();
            cboMaPhong.ValueMember = "MaPhong";
            cboMaPhong.DisplayMember = "SoPhong";
            cboMaPhong.SelectedIndex = 0;
            cboTinhTrang.SelectedIndex = 0;
            
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                string maBaoTri = txtMaBaoTri.Text.Trim();
                string maPhong = cboMaPhong.SelectedValue.ToString();
                string noiDung = txtNoiDung.Text.Trim();
                DateTime ngayBaoTri = DateTime.Parse(txtNgayBaoTri.Text.Trim());
                string trangThai = cboTinhTrang.Text.Trim();


                BaoTri bt = new BaoTri(maBaoTri, maPhong, noiDung, ngayBaoTri, trangThai);
                busbt.AddBaoTri(bt);
                MessageBox.Show("Thêm thông tin bảo trì thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                GUI_BaoTri_Load(sender, e);
                Reset();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string maBaoTri = txtMaBaoTri.Text.Trim();
            string maPhong = cboMaPhong.SelectedValue.ToString();
            string noiDung = txtNoiDung.Text.Trim();
            DateTime ngayBaoTri = DateTime.Parse(txtNgayBaoTri.Text.Trim());
            string trangThai = cboTinhTrang.Text.Trim();


            BaoTri bt = new BaoTri(maBaoTri, maPhong, noiDung, ngayBaoTri, trangThai);
            busbt.EditBaoTri(bt);
            MessageBox.Show("Cập nhật thông tin bảo trì thành công!");
            Reset();
            GUI_BaoTri_Load(sender, e);


        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string maBaoTri = txtMaBaoTri.Text;
                busbt.DeleteBaoTri(maBaoTri);
                Reset();
                GUI_BaoTri_Load(sender, e);

            }
        }

        private void dgvBaoTri_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            txtMaBaoTri.Text = dgvBaoTri.CurrentRow.Cells[0].Value.ToString();
            cboMaPhong.Text = dgvBaoTri.CurrentRow.Cells[1].Value.ToString();
            txtNoiDung.Text = dgvBaoTri.CurrentRow.Cells[2].Value.ToString();
            txtNgayBaoTri.Text = Convert.ToDateTime(dgvBaoTri.CurrentRow.Cells[3].Value).ToShortDateString();

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

            string keyWord = txtKeyword.Text;
            dgvBaoTri.DataSource = busbt.SearchBaoTri(keyWord);
        }

        private void btnKetXuat_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Microsoft Word | *.docx";
            saveFileDialog.Title = "Lưu thông tin bảo trì";
            saveFileDialog.ShowDialog();
            if (saveFileDialog.FileName != "")
            {
                try
                {
                    busbt.KetXuatWord(saveFileDialog.FileName);
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

        }



        void Reset()
        {
            txtMaBaoTri.Clear();
            txtNoiDung.Clear();
            cboMaPhong.SelectedItem = 0;
            txtNgayBaoTri.Text = DateTime.Now.ToShortDateString();
            cboTinhTrang.SelectedIndex = 0;
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
            GUI_BaoTri_Load(sender, e);
            Reset();
        }

    }
}
