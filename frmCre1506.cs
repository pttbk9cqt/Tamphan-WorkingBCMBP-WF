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
            txtYear.Text = "2026";
            cboDiaDiem.Text = "Phường Chơn Thành, tỉnh Đồng Nai";
            //load NCC từ file json
            var content = JsonConvert.DeserializeObject<ContentData>(File.ReadAllText(Path.Combine("Data\\ContentData.json")));
            rtbCanCu.Text = content.CanCu;
            rtbNguyennhantrinhky.Text = content.NguyenNhanTrinhKy;
        }
        private void TextBox_HangMuc_TextChanged(object sender, EventArgs e)
        {
            rtbNoidungtrinhky.Text = "Bên A đồng ý giao và Bên B đồng ý nhận thi công hạng mục: " + txtHangMuc.Text + " với khối lượng và đơn giá chi tiết như sau:";
        }
        private void ComboBox_NCC_SelectedIndexChanged(object sender, EventArgs e)
        {
            var ncc = JsonConvert.DeserializeObject<List<NCC>>(File.ReadAllText("Data\\Supplier.json")).FirstOrDefault(NCC => NCC.TenNCC == cboNameNCC.Text);
            if (ncc == null) return;
            {
                txtLocationNCC.Text = ncc.DiaChi;
                txtPhoneNCC.Text = ncc.SDT;
                txtEmailNCC.Text = ncc.Email;
                txtStkNCC.Text = ncc.STK;
                txtMstNCC.Text = ncc.MST;
                txtOwnerNCC.Text = ncc.DaiDien;
                cboFunctionNCC.Text = ncc.ChucVu;
            }
        }

        private async Task Btn_Build_Click(object sender, EventArgs e)
        {
            var map = new Dictionary<string, string>
            {
                ["{{SOTTR}}"] = txtSoTTr.Text.Trim(),
                ["{{DAY}}"] = txtDay.Text.Trim(),
                ["{{MONTH}}"] = txtMonth.Text.Trim(),
                ["{{YEAR}}"] = txtYear.Text.Trim(),
                ["{{DUAN}}"] = cboDuAn.Text.Trim(),
                ["{{CONGTRINH}}"] = cboCongTrinh.Text.Trim(),
                ["{{HANGMUC}}"] = txtHangMuc.Text.Trim(),
                ["{{DIADIEM}}"] = cboDiaDiem.Text.Trim(),
                ["{{NCC}}"] = cboNameNCC.Text.Trim(),
                ["{{DIACHINCC}}"] = txtLocationNCC.Text.Trim(),
                ["{{SDTNCC}}"] = txtPhoneNCC.Text.Trim(),
                ["{{EMAILNCC}}"] = txtEmailNCC.Text.Trim(),
                ["{{STKNCC}}"] = txtStkNCC.Text.Trim(),
                ["{{MSTNCC}}"] = txtMstNCC.Text.Trim(),
                ["{{DAIDIENNCC}}"] = txtOwnerNCC.Text.Trim(),
                ["{{CHUCVUNCC}}"] = cboFunctionNCC.Text.Trim(),
                ["{{CANCU}}"] = rtbCanCu.Text.Trim(),
                ["{{NGUYENNHANTRINHKY}}"] = rtbNguyennhantrinhky.Text.Trim(),
                ["{{NOIDUNGTRINHKY}}"] = rtbNguyennhantrinhky.Text.Trim(),
            };

            MessageBox.Show("Done!");
        }
    }
}
