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
    public partial class GUI_DKDichVu : Form
    {
        public GUI_DKDichVu()
        {
            InitializeComponent();
            txtKeyword.Text = "Nhập nội dung tìm kiếm";
            txtKeyword.ForeColor = Color.DarkGray;
            txtNgayBatDau.Text = DateTime.Now.ToShortDateString();

        }
        public event EventHandler ExitForm;


        BUS_DKDichVu busdk = new BUS_DKDichVu();

        private void GUI_DKDichVu_Load(object sender, EventArgs e)
        {
            dgvDichVu.DataSource = busdk.GetDangKyDV();


            cboMaDichVu.DataSource = busdk.GetDichVu();
            cboMaDichVu.ValueMember = "MaDichVu";
            cboMaDichVu.DisplayMember = "TenDichVu";
            cboMaDichVu.SelectedIndex = 0;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                string maCTHD = txtMaCTHD.Text.Trim();
                string maDichVu = cboMaDichVu.SelectedValue.ToString();
                DateTime ngayDK = DateTime.Parse(txtNgayBatDau.Text.Trim());
                DateTime ngayKT = DateTime.Parse(txtNgayKetThuc.Text.Trim());


                DKDichVu dk = new DKDichVu(maCTHD, maDichVu, ngayDK, ngayKT);
                busdk.AddDKDichVu(dk);
                MessageBox.Show("Thêm thông tin thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                GUI_DKDichVu_Load(sender, e);
                Reset();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string maCTHD = txtMaCTHD.Text.Trim();
            string maDichVu = cboMaDichVu.SelectedValue.ToString();
            DateTime ngayDK = DateTime.Parse(txtNgayBatDau.Text.Trim());
            DateTime ngayKT = DateTime.Parse(txtNgayKetThuc.Text.Trim());


            DKDichVu dk = new DKDichVu(maCTHD, maDichVu, ngayDK, ngayKT);
            busdk.EditDKDichVu(dk);
            MessageBox.Show("Cập nhật thông tin bảo trì thành công!");
            Reset();
            GUI_DKDichVu_Load(sender, e);


        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string maCTHD = txtMaCTHD.Text.Trim();
                string maDichVu = cboMaDichVu.SelectedValue.ToString();
                busdk.DeleteDKDichVu(maCTHD, maDichVu);
                Reset();
                GUI_DKDichVu_Load(sender, e);

            }
        }

        private void dgvDKDichVu_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            txtMaCTHD.Text = dgvDichVu.CurrentRow.Cells[0].Value.ToString();
            cboMaDichVu.Text = dgvDichVu.CurrentRow.Cells[1].Value.ToString();
            txtNgayBatDau.Text = Convert.ToDateTime(dgvDichVu.CurrentRow.Cells[3].Value).ToShortDateString();
            txtNgayKetThuc.Text = Convert.ToDateTime(dgvDichVu.CurrentRow.Cells[4].Value).ToShortDateString();

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

            string keyWord = txtKeyword.Text;
            //dgvDichVu.DataSource = busbt.SearchDKDichVu(keyWord);
        }

        private void btnKetXuat_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Microsoft Word | *.docx";
            saveFileDialog.Title = "Lưu thông tin đăng ký dịch vụ";
            saveFileDialog.ShowDialog();
            if (saveFileDialog.FileName != "")
            {
                try
                {
                    //busbt.KetXuatWord(saveFileDialog.FileName);
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
            txtMaCTHD.Clear();
            txtNgayBatDau.Text = DateTime.Now.ToShortDateString();
            cboMaDichVu.SelectedItem = 0;
            txtNgayKetThuc.Text = "";

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
            GUI_DKDichVu_Load(sender, e);
            Reset();
        }

        
    }
}
