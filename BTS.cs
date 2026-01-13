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
    public partial class BTS : Form
    {
        public BTS()
        {
            InitializeComponent();
            DataGridView_BTS_ToaDo.KeyDown += DataGridView_BTS_ToaDo_KeyDown;
        }
        
        private void BTS_Load(object sender, EventArgs e)
        {
            TextBox_BTS_Nam.Text = "2026";
            TextBox_BTS_HangMuc.Text = "Vị trí đặt trạm phát sóng di động - Trạm BTS ";
            ComboBox_BTS_DiaDiem.Text = "Phường Chơn Thành, tỉnh Đồng Nai";
            //cấu hình DataGridview
            DataGridView_BTS_ToaDo.ColumnCount = 2;
            DataGridView_BTS_ToaDo.RowCount = 4;
            DataGridView_BTS_ToaDo.Columns[0].HeaderText = "Tọa độ E";
            DataGridView_BTS_ToaDo.Columns[1].HeaderText = "Tọa độ N";
            DataGridView_BTS_ToaDo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DataGridView_BTS_ToaDo.AllowUserToAddRows = true;
            DataGridView_BTS_ToaDo.ReadOnly = false;
            DataGridView_BTS_ToaDo.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2;
            DataGridView_BTS_ToaDo.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
        }
        private void DataGridView_BTS_ToaDo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
            {
                PasteExcelToGrid(DataGridView_BTS_ToaDo);
                e.SuppressKeyPress = true; // chặn Ctrl+V mặc định
            }
        }

        private void PasteExcelToGrid(DataGridView dgv)
        {
            string text = Clipboard.GetText();
            if (string.IsNullOrWhiteSpace(text)) return;

            string[] rows = text.Split(
                new[] { "\r\n" },
                StringSplitOptions.RemoveEmptyEntries
            );

            for (int i = 0; i < rows.Length && i < dgv.RowCount; i++)
            {
                string[] cols = rows[i].Split('\t');

                for (int j = 0; j < cols.Length && j < dgv.ColumnCount; j++)
                {
                    dgv.Rows[i].Cells[j].Value = cols[j];
                }
            }
        }


        private void Btn_BTS_ExportGridToToado_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra 8 TextBox có trống hết không
            bool allEmpty =
                string.IsNullOrWhiteSpace(TextBox_BTS_L11.Text) &&
                string.IsNullOrWhiteSpace(TextBox_BTS_L12.Text) &&
                string.IsNullOrWhiteSpace(TextBox_BTS_L21.Text) &&
                string.IsNullOrWhiteSpace(TextBox_BTS_L22.Text) &&
                string.IsNullOrWhiteSpace(TextBox_BTS_L31.Text) &&
                string.IsNullOrWhiteSpace(TextBox_BTS_L32.Text) &&
                string.IsNullOrWhiteSpace(TextBox_BTS_L41.Text) &&
                string.IsNullOrWhiteSpace(TextBox_BTS_L42.Text);

            if (!allEmpty)
                return; // có ít nhất 1 ô đã có dữ liệu → không làm gì

            // 2. Lấy dữ liệu từ DataGridView (4x2)
            TextBox_BTS_L11.Text = DataGridView_BTS_ToaDo.Rows[0].Cells[0].Value?.ToString() ?? "";
            TextBox_BTS_L12.Text = DataGridView_BTS_ToaDo.Rows[0].Cells[1].Value?.ToString() ?? "";

            TextBox_BTS_L21.Text = DataGridView_BTS_ToaDo.Rows[1].Cells[0].Value?.ToString() ?? "";
            TextBox_BTS_L22.Text = DataGridView_BTS_ToaDo.Rows[1].Cells[1].Value?.ToString() ?? "";

            TextBox_BTS_L31.Text = DataGridView_BTS_ToaDo.Rows[2].Cells[0].Value?.ToString() ?? "";
            TextBox_BTS_L32.Text = DataGridView_BTS_ToaDo.Rows[2].Cells[1].Value?.ToString() ?? "";

            TextBox_BTS_L41.Text = DataGridView_BTS_ToaDo.Rows[3].Cells[0].Value?.ToString() ?? "";
            TextBox_BTS_L42.Text = DataGridView_BTS_ToaDo.Rows[3].Cells[1].Value?.ToString() ?? "";
        }

        private void Btn_BTS_Build_Click(object sender, EventArgs e)
        {
            var map = new Dictionary<string, string>
            {
                ["{{SOTTR}}"] = TextBox_BTS_SoTTr1506.Text.Trim(),
                ["{{DAY}}"] = TextBox_BTS_Ngay.Text.Trim(),
                ["{{MONTH}}"] = TextBox_BTS_Thang.Text.Trim(),
                ["{{YEAR}}"] = TextBox_BTS_Nam.Text.Trim(),
                ["{{DUAN}}"] = ComboBox_BTS_DuAn.Text.Trim(),
                ["{{CONGTRINH}}"] = ComboBox_BTS_CongTrinh.Text.Trim(),
                ["{{HANGMUC}}"] = TextBox_BTS_HangMuc.Text.Trim(),
                ["{{DIADIEM}}"] = ComboBox_BTS_DiaDiem.Text.Trim(),
                ["{{MATRAM}}"] = TextBox_BTS_MaTram.Text.Trim(),
                ["{{L11}}"] = TextBox_BTS_L11.Text.Trim(),
                ["{{L12}}"] = TextBox_BTS_L12.Text.Trim(),
                ["{{L21}}"] = TextBox_BTS_L21.Text.Trim(),
                ["{{L22}}"] = TextBox_BTS_L22.Text.Trim(),
                ["{{L31}}"] = TextBox_BTS_L31.Text.Trim(),
                ["{{L32}}"] = TextBox_BTS_L32.Text.Trim(),
                ["{{L41}}"] = TextBox_BTS_L41.Text.Trim(),
                ["{{L42}}"] = TextBox_BTS_L42.Text.Trim(),
            };
            
            Directory.CreateDirectory("Output");
            string suffix = TextBox_BTS_NameAddFileBuild.Text.Trim();
            string outputPath = $@"Output\BM-15-06 TỜ TRÌNH XIN CHỦ TRƯƠNG BTS - {suffix}.docx";
            BuildWordService.Build(@"Templates\BTS\BM-15-06 TỜ TRÌNH XIN CHỦ TRƯƠNG BTS - Templates.docx",outputPath, map);
            //BuildWordService.Build(@"Templates\BTS\BM-15-06 TỜ TRÌNH XIN CHỦ TRƯƠNG BTS - Templates.docx", @"Output\BM-15-06 TỜ TRÌNH XIN CHỦ TRƯƠNG BTS - Build.docx", map);
            MessageBox.Show("Done!");
        }

    }
}
