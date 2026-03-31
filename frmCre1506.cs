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
    public partial class frmCre1506 : Form
    {
        public frmCre1506()
        {
            InitializeComponent();
        }

        private void Input1506_Load(object sender, EventArgs e)
        {
            TextBox_Nam.Text = "2026";
            ComboBox_DiaDiem.Text = "Phường Chơn Thành, tỉnh Đồng Nai";
            //load NCC từ file json
            var content = JsonConvert.DeserializeObject<ContentData>(File.ReadAllText(Path.Combine("Data\\ContentData.json")));
            RichTextBox_CanCu.Text = content.CanCu;
            RichTextBox_Nguyennhantrinhky.Text = content.NguyenNhanTrinhKy;
        }
        private void TextBox_HangMuc_TextChanged(object sender, EventArgs e)
        {
            RichTextBox_Noidungtrinhky1.Text = "Bên A đồng ý giao và Bên B đồng ý nhận thi công hạng mục: " + TextBox_HangMuc.Text + " với khối lượng và đơn giá chi tiết như sau:";
        }
        private void ComboBox_NCC_SelectedIndexChanged(object sender, EventArgs e)
        {
            var ncc = JsonConvert.DeserializeObject<List<NCC>>(File.ReadAllText("Data\\Supplier.json")).FirstOrDefault(NCC => NCC.TenNCC == ComboBox_NCC.Text);
            if (ncc == null) return;
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

        private async Task Btn_Build_Click(object sender, EventArgs e)
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

            MessageBox.Show("Done!");
        }
    }
}
