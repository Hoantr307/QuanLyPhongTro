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
    public partial class GUI_PhongTro : Form
    {
        public GUI_PhongTro()
        {
            InitializeComponent();
            txtKeyword.Text = "Nhập nội dung tìm kiếm";
            txtKeyword.ForeColor = Color.DarkGray;
        }

        BUS_PhongTro buspt = new BUS_PhongTro();

        public event EventHandler ExitForm;



        private void GUI_PhongTro_Load(object sender, EventArgs e)
        {
            dgvPhongTro.DataSource = buspt.GetPhongTro();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                string maPhong = txtMaPhong.Text.Trim();
                int soPhong = int.Parse(txtSoPhong.Text.Trim());
                double dienTich = double.Parse(txtDienTich.Text.Trim());
                int giaThue = int.Parse(txtGiaThue.Text.Trim());
                string tinhTrang = cbTinhTrang.Text.Trim();

                PhongTro kh = new PhongTro(maPhong, soPhong, dienTich, giaThue, tinhTrang);
                buspt.AddPhongTro(kh);
                MessageBox.Show("Thêm thông tin phòng trọ thành công!");
                Reset();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                GUI_PhongTro_Load(sender, e);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string maPhong = txtMaPhong.Text.Trim();
            int soPhong = int.Parse(txtSoPhong.Text.Trim());
            double dienTich = double.Parse(txtDienTich.Text.Trim());
            int giaThue = int.Parse(txtGiaThue.Text.Trim());
            string tinhTrang = cbTinhTrang.Text.Trim();

            PhongTro kh = new PhongTro(maPhong, soPhong, dienTich, giaThue, tinhTrang);
            buspt.EditPhongTro(kh);
            MessageBox.Show("Cập nhật thông tin phòng trọ thành công!");
            Reset();
            GUI_PhongTro_Load(sender, e);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string maPhongTro = txtMaPhong.Text;
                buspt.DeletePhongTro(maPhongTro);
                GUI_PhongTro_Load(sender, e);
                Reset();
            }
        }

        private void dgvPhongTro_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            txtMaPhong.Text = dgvPhongTro.CurrentRow.Cells[0].Value.ToString();
            txtSoPhong.Text = dgvPhongTro.CurrentRow.Cells[1].Value.ToString();
            txtDienTich.Text = dgvPhongTro.CurrentRow.Cells[2].Value.ToString();
            txtGiaThue.Text = dgvPhongTro.CurrentRow.Cells[3].Value.ToString();
            cbTinhTrang.Text = dgvPhongTro.CurrentRow.Cells[4].Value.ToString();
        }



        private void btnSearch_Click(object sender, EventArgs e)
        {

            string keyWord = txtKeyword.Text;
            dgvPhongTro.DataSource = buspt.SearchPhongTro(keyWord);

        }

        private void btnKetXuat_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Microsoft Word | *.docx";
            saveFileDialog.Title = "Lưu thông tin phòng trọ";
            saveFileDialog.ShowDialog();
            if (saveFileDialog.FileName != "")
            {
                try
                {
                    buspt.KetXuatWord(saveFileDialog.FileName);
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
            saveFileDialog.Title = "Lưu thông tin phòng trọ";
            saveFileDialog.ShowDialog();
            if (saveFileDialog.FileName != "")
            {
                try
                {
                    buspt.XuatExcel(saveFileDialog.FileName);
                    MessageBox.Show("Kết xuất thành công!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông báo lỗi");
                }
            }
        }

        private void btnThemDl_Click(object sender, EventArgs e)
        {
            /*OpenFileDialog saveFileDialog = new OpenFileDialog();
            saveFileDialog.DefaultExt = "*.xlsx";
            saveFileDialog.Filter = "Excel (*.xlsx)|*.xlsx";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    buspt.ThemTuExcel(saveFileDialog.FileName);
                    GUI_PhongTro_Load(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông báo lỗi");
                }
            }*/
        }



        void Reset()
        {
            txtMaPhong.Clear();
            txtSoPhong.Clear();
            txtDienTich.Clear();
            txtGiaThue.Clear();
            cbTinhTrang.SelectedIndex = 0;
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
            GUI_PhongTro_Load(sender, e);
            Reset();
        }

    }
}
