using DocumentFormat.OpenXml.EMMA;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tamphan_WorkingBCMBP_WF.Models;
using Tamphan_WorkingBCMBP_WF.Services;

namespace Tamphan_WorkingBCMBP_WF
{
    public partial class Input1506 : Form
    {
        public Input1506()
        {
            InitializeComponent();
            //DataGridView_BTS_ToaDo.KeyDown += DataGridView_BTS_ToaDo_KeyDown;
        }

        private void  Input1506_Load(object sender, EventArgs e)
        {
            TextBox_Nam.Text = "2026";
            ComboBox_DiaDiem.Text = "Phường Chơn Thành, tỉnh Đồng Nai";
            try
            {
                var content = LoadJson<ContentData>("ContentData.json");
                RichTextBox_CanCu.Text = content.CanCu;
                RichTextBox_Nguyennhantrinhky.Text = content.NguyenNhanTrinhKy;

                //TenNCC = LoadJson<List<NCC>>("Supplier.json");
                //ComboBox_NCC.DataSource = TenNCC;
                //ComboBox_NCC.DisplayMember = "TenNCC";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //RichTextBox_Noidungtrinhky1.Text = "Bên A đồng ý giao và Bên B đồng ý nhận thi công hạng mục:" + TextBox_HangMuc.Text.Trim() + "với khối lượng và đơn giá chi tiết như sau:";
            //cấu hình DataGridview
            //DataGridView_BTS_ToaDo.ColumnCount = 2;
            //DataGridView_BTS_ToaDo.RowCount = 4;
            //DataGridView_BTS_ToaDo.Columns[0].HeaderText = "Tọa độ E";
            //DataGridView_BTS_ToaDo.Columns[1].HeaderText = "Tọa độ N";
            //DataGridView_BTS_ToaDo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //DataGridView_BTS_ToaDo.AllowUserToAddRows = true;
            //DataGridView_BTS_ToaDo.ReadOnly = false;
            //DataGridView_BTS_ToaDo.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2;
            //DataGridView_BTS_ToaDo.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
        }
        private void TextBox_HangMuc_TextChanged(object sender, EventArgs e)
        {
            RichTextBox_Noidungtrinhky1.Text = "Bên A đồng ý giao và Bên B đồng ý nhận thi công hạng mục: " + TextBox_HangMuc.Text + " với khối lượng và đơn giá chi tiết như sau:";
        }
        private void ComboBox_NCC_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (ComboBox_NCC.Text == "Công ty Cổ phần Điện Lực Becamex Bình Phước (BBPJSC)")
            //{
            //    TextBox_NCC_DiaChi.Text = "Tổ 8, Khu phố 3, Phường Chơn Thành, Tỉnh Đồng Nai";
            //    TextBox_NCC_SDT.Text = "0271.3.603.868 – 0271.3.603.869";
            //    TextBox_NCC_Email.Text = "cskh.dienluc@becamexbinhphuoc.com.vn";
            //    TextBox_NCC_STK.Text = "6550.648.328 tại Ngân hàng TMCP Đầu tư & Phát triển Việt Nam";
            //    TextBox_NCC_MST.Text = "3 8 0 1 2 3 9 3 2 4";
            //    TextBox_NCC_DaiDien.Text = "Ông Đặng Văn Dũng";
            //    ComboBox_NCC_ChucVu.Text = "Tổng Giám đốc";
            //}
            if (ComboBox_NCC.SelectedItem is NCC ncc)
            {
                TextBox_NCC_DiaChi.Text = ncc.DiaChi;
                TextBox_NCC_SDT.Text = ncc.SDT;
                TextBox_NCC_Email.Text = ncc.Email;
                TextBox_NCC_STK.Text = ncc.STK;
                TextBox_NCC_MST.Text = ncc.MST;
                TextBox_NCC_DaiDien.Text = ncc.DaiDien;
                ComboBox_NCC_ChucVu.Text = ncc.ChucVu;
            }
        }
        //private void DataGridView_BTS_ToaDo_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.Control && e.KeyCode == Keys.V)
        //    {
        //        PasteExcelToGrid(DataGridView_BTS_ToaDo);
        //        e.SuppressKeyPress = true; // chặn Ctrl+V mặc định
        //    }
        //}
        //private void PasteExcelToGrid(DataGridView dgv)
        //{
        //    string text = Clipboard.GetText();
        //    if (string.IsNullOrWhiteSpace(text)) return;

        //    string[] rows = text.Split(
        //        new[] { "\r\n" },
        //        StringSplitOptions.RemoveEmptyEntries
        //    );

        //    for (int i = 0; i < rows.Length && i < dgv.RowCount; i++)
        //    {
        //        string[] cols = rows[i].Split('\t');

        //        for (int j = 0; j < cols.Length && j < dgv.ColumnCount; j++)
        //        {
        //            dgv.Rows[i].Cells[j].Value = cols[j];
        //        }
        //    }
        //}
        private T LoadJson<T>(string fileName)
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", fileName);

            if (!File.Exists(path))
                throw new FileNotFoundException($"Không tìm thấy file {fileName}");

            return JsonConvert.DeserializeObject<T>(File.ReadAllText(path));
        }



        private void Btn_Build_Click(object sender, EventArgs e)
        {
            var map = new Dictionary<string, string>
            {
                ["{{SOTTR}}"] = TextBox_SoTTr1506.Text.Trim(),
                ["{{DAY}}"] = TextBox_Ngay.Text.Trim(),
                ["{{MONTH}}"] = TextBox_Thang.Text.Trim(),
                ["{{YEAR}}"] = TextBox_Nam.Text.Trim(),
                ["{{DUAN}}"] = ComboBox_DuAn.Text.Trim(),
                ["{{CONGTRINH}}"] = ComboBox_CongTrinh.Text.Trim(),
                ["{{HANGMUC}}"] = TextBox_HangMuc.Text.Trim(),
                ["{{DIADIEM}}"] = ComboBox_DiaDiem.Text.Trim(),
                ["{{NCC}}"] = ComboBox_NCC.Text.Trim(),
                ["{{DIACHINCC}}"] = TextBox_NCC_DiaChi.Text.Trim(),
                ["{{SDTNCC}}"] = TextBox_NCC_SDT.Text.Trim(),
                ["{{EMAILNCC}}"] = TextBox_NCC_Email.Text.Trim(),
                ["{{STKNCC}}"] = TextBox_NCC_STK.Text.Trim(),
                ["{{MSTNCC}}"] = TextBox_NCC_MST.Text.Trim(),
                ["{{DAIDIENNCC}}"] = TextBox_NCC_DaiDien.Text.Trim(),
                ["{{CHUCVUNCC}}"] = ComboBox_NCC_ChucVu.Text.Trim(),
                ["{{CANCU}}"] = RichTextBox_CanCu.Text.Trim(),
                ["{{NGUYENNHANTRINHKY}}"] = RichTextBox_Nguyennhantrinhky.Text.Trim(),
                ["{{NOIDUNGTRINHKY}}"] = RichTextBox_Nguyennhantrinhky.Text.Trim(),
            };

            //Directory.CreateDirectory("Output");
            //string suffix = TextBox_BTS_NameAddFileBuild.Text.Trim();
            //string outputPath1506 = $@"Output\BM-15-06 Tờ trình xin chủ trương - {suffix}.docx";
            //BuildWordService.Build(@"Templates\BTS\BM-15-06 TỜ TRÌNH XIN CHỦ TRƯƠNG BTS - Templates.docx", outputPath1506, map);
            ////BuildWordService.Build(@"Templates\BTS\BM-15-06 TỜ TRÌNH XIN CHỦ TRƯƠNG BTS - Templates.docx", @"Output\BM-15-06 TỜ TRÌNH XIN CHỦ TRƯƠNG BTS - Build.docx", map);
            //string outputPath1507 = $@"Output\BM-15-07 Tờ trình ký hợp đồng - {suffix}.docx";
            //BuildWordService.Build(@"Templates\BTS\BM-15-07 TỜ TRÌNH KÝ HỢP ĐỒNG BTS - Templates.docx", outputPath1507, map);
            //string outputPathThoaThuan = $@"Output\BIÊN BẢN THỎA THUẬN - {suffix}.docx";
            //BuildWordService.Build(@"Templates\BTS\BIÊN BẢN THỎA THUẬN BTS - Templates.docx", outputPathThoaThuan, map);
            MessageBox.Show("Done!");
        }

    }
}
