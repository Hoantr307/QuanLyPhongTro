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
    public partial class GUI_ThongKe : Form
    {
        public GUI_ThongKe()
        {
            InitializeComponent();
        }

        BUS_HoaDon bushd = new BUS_HoaDon();


        public event EventHandler ExitForm;


        private void GUI_HoaDon_Load(object sender, EventArgs e)
        {
            dgvHoaDon.DataSource = bushd.GetHoaDon();
        }

     

        private void btnKetXuat_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Microsoft Word | *.docx";
            saveFileDialog.Title = "Lưu thông tin thông kê";
            saveFileDialog.ShowDialog();
            if (saveFileDialog.FileName != "")
            {
                try
                {
                    bushd.KetXuatWordThongKe(saveFileDialog.FileName, txtThang.Text);
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

       
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            GUI_HoaDon_Load(sender, e);
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel (*.xlsx)|*.xlsx";
            saveFileDialog.Title = "Lưu thông tin thông kê";
            saveFileDialog.ShowDialog();
            if (saveFileDialog.FileName != "")
            {
                try
                {
                    bushd.XuatExcelThongKe(saveFileDialog.FileName, txtThang.Text);
                    MessageBox.Show("Kết xuất thành công!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông báo lỗi");
                }
            }
        }

        private void txt_TextChanged(object sender, EventArgs e)
        {
            string keyWord = txtThang.Text;
            dgvHoaDon.DataSource = bushd.ThongKe(keyWord);
        }

        
    }
}
