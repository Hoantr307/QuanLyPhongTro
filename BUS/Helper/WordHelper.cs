using BUS.Helper;
using DTO;
using Novacode;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    internal static class WordHelper
    {
        public static void ExportToWord(DataTable data, string templatePath, string exportPath, List<string> unwantedValues = null)
        {
            if (unwantedValues == null)
            {
                unwantedValues = new List<string>();
            }
            // Tạo tài liệu Word mới
            using (DocX document = DocX.Load(templatePath))
            {
                DateTime dateNow = DateTime.Now;

                // tìm đối tượng Paragraph chứa trường dữ liệu
                Paragraph p = document.Paragraphs.FirstOrDefault(paragraph => paragraph.Text.Contains("<<QuanLy>>"));
                Paragraph day = document.Paragraphs.FirstOrDefault(paragraph => paragraph.Text.Contains("{day}"));
                Paragraph month = document.Paragraphs.FirstOrDefault(paragraph => paragraph.Text.Contains("{month}"));
                Paragraph year = document.Paragraphs.FirstOrDefault(paragraph => paragraph.Text.Contains("{year}"));

                // thay thế chuỗi trường dữ liệu bằng giá trị thật
                p.ReplaceText("<<QuanLy>>", "Trần Đình Hoàn");
                day.ReplaceText("{day}", dateNow.Day.ToString());
                month.ReplaceText("{month}", dateNow.Month.ToString());
                year.ReplaceText("{year}", dateNow.Year.ToString());

                // Lấy đối tượng bảng từ tài liệu Word
                Table table = document.Tables[1];
                

                // Lặp qua các dữ liệu trong danh sách

                List<string> columns = new List<string>();
                foreach (DataColumn column in data.Columns)
                {
                    columns.Add(column.ColumnName);
                }

                int index = 1;
                foreach (DataRow item in data.Rows)
                {
                    // Thêm một dòng mới vào bảng
                    Row row = table.InsertRow();
                    int i = 1;

                    row.Cells[0].Paragraphs[0].InsertText(index++.ToString());
                    row.Cells[0].Width = 80;

                    foreach (string col in columns)
                    {

                        if (unwantedValues.Contains(col))
                        {
                            continue; 
                        }

                        if (item[col] is DateTime)
                        {
                            DateTime dateValue = (DateTime)item[col];
                            string formattedDate = dateValue.ToString("dd/MM/yyyy");
                            row.Cells[i++].Paragraphs[0].InsertText(formattedDate);
                            continue;
                        }

                        row.Cells[i++].Paragraphs[0].InsertText(item[col].ToString());
                        

                    }
                }
                document.SaveAndOpenFile(exportPath);
            }
        }

        public static void ExportToWord2(DataTable data, string templatePath, string exportPath, int giaTri = 0 , List<string> unwantedValues = null)
        {

            if (unwantedValues == null)
            {
                unwantedValues = new List<string>();
            }
            // Tạo tài liệu Word mới
            using (DocX document = DocX.Load(templatePath))
            {
                DateTime dateNow = DateTime.Now;

                // tìm đối tượng Paragraph chứa trường dữ liệu
                Paragraph p = document.Paragraphs.FirstOrDefault(paragraph => paragraph.Text.Contains("<<QuanLy>>"));
                Paragraph day = document.Paragraphs.FirstOrDefault(paragraph => paragraph.Text.Contains("{day}"));
                Paragraph month = document.Paragraphs.FirstOrDefault(paragraph => paragraph.Text.Contains("{month}"));
                Paragraph year = document.Paragraphs.FirstOrDefault(paragraph => paragraph.Text.Contains("{year}"));
                Paragraph tongtien = document.Paragraphs.FirstOrDefault(paragraph => paragraph.Text.Contains("<<TongTien>>"));
                Paragraph bangChu = document.Paragraphs.FirstOrDefault(paragraph => paragraph.Text.Contains("<<BangChu>>"));


                // thay thế chuỗi trường dữ liệu bằng giá trị thật
                p.ReplaceText("<<QuanLy>>", "Trần Đình Hoàn");
                day.ReplaceText("{day}", dateNow.Day.ToString());
                month.ReplaceText("{month}", dateNow.Month.ToString());
                year.ReplaceText("{year}", dateNow.Year.ToString());
                if (giaTri != 0)
                {
                    tongtien.ReplaceText("<<TongTien>>", giaTri.ToString() + " đồng");
                    bangChu.ReplaceText("<<BangChu>>", Tools.NumberToWords(giaTri) + " đồng");

                }



                // Lấy đối tượng bảng từ tài liệu Word
                Table table = document.Tables[1];


                // Lặp qua các dữ liệu trong danh sách

                List<string> columns = new List<string>();
                foreach (DataColumn column in data.Columns)
                {
                    columns.Add(column.ColumnName);
                }

                int index = 1;
                foreach (DataRow item in data.Rows)
                {
                    // Thêm một dòng mới vào bảng
                    Row row = table.InsertRow();
                    int i = 1;

                    row.Cells[0].Paragraphs[0].InsertText(index++.ToString());
                    row.Cells[0].Width = 80;

                    foreach (string col in columns)
                    {

                        if (unwantedValues.Contains(col))
                        {
                            continue;
                        }

                        if (item[col] is DateTime)
                        {
                            DateTime dateValue = (DateTime)item[col];
                            string formattedDate = dateValue.ToString("dd/MM/yyyy");
                            row.Cells[i++].Paragraphs[0].InsertText(formattedDate);
                            continue;
                        }

                        row.Cells[i++].Paragraphs[0].InsertText(item[col].ToString());


                    }
                }
                document.SaveAndOpenFile(exportPath);
            }
        }

        public static void SaveAndOpenFile(this DocX doc, string filename = "BaoCao.docx")
        {
            /*string thuMuc = "temp";
            if (!Directory.Exists(thuMuc))
                Directory.CreateDirectory(thuMuc);*/

            while (true)
            {
                string tenTep = $"{filename}";
                try
                {
                    doc.SaveAs(tenTep);
                    Process.Start(tenTep);
                    break;
                }
                catch
                {

                }
            }
        }
    }
}
