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
    public partial class frmBTS : Form
    {
        public frmBTS()
        {
            InitializeComponent();
            dgvToaDo.KeyDown += DataGridView_BTS_ToaDo_KeyDown;
            cboHangMuc.TextChanged += TextBox_BTS_HangMuc_TextChanged;
        }
        
        private void BTS_Load(object sender, EventArgs e)
        {
            txtYear.Text = "2026";
            cboHangMuc.Text = "Vị trí đặt trạm phát sóng di động BPCxxx (Trạm BTS xxx)";
            cboDiaDiem.Text = "Phường Chơn Thành, tỉnh Đồng Nai";
            //cấu hình DataGridview
            dgvToaDo.ColumnCount = 2;
            dgvToaDo.RowCount = 4;
            dgvToaDo.Columns[0].HeaderText = "Tọa độ E";
            dgvToaDo.Columns[1].HeaderText = "Tọa độ N";
            dgvToaDo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvToaDo.AllowUserToAddRows = true;
            dgvToaDo.ReadOnly = false;
            dgvToaDo.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2;
            dgvToaDo.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
        }
        private void TextBox_BTS_HangMuc_TextChanged(object sender, EventArgs e)
        {
            string input = cboHangMuc.Text.Trim();

            if (string.IsNullOrWhiteSpace(input))
            {
                txtMaTram.Text = "";
                return;
            }

            string prefix = "Vị trí đặt ";

            if (input.StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
            {
                string result = input.Substring(prefix.Length);

                // viết hoa chữ cái đầu
                if (!string.IsNullOrEmpty(result))
                {
                    result = char.ToUpper(result[0]) + result.Substring(1);
                }

                txtMaTram.Text = result;
            }
            else
            {
                // nếu không đúng format thì giữ nguyên
                txtMaTram.Text = input;
            }
        }
        private void DataGridView_BTS_ToaDo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
            {
                PasteExcelToGrid(dgvToaDo);
                e.SuppressKeyPress = true; // chặn Ctrl+V mặc định
            }
        }

        private void PasteExcelToGrid(DataGridView dgv)
        {
            string text = Clipboard.GetText();
            if (string.IsNullOrWhiteSpace(text)) return;

            string[] rows = text.Split( new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

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
            txtL11.Text = dgvToaDo.Rows[0].Cells[0].Value?.ToString() ?? "";
            txtL12.Text = dgvToaDo.Rows[0].Cells[1].Value?.ToString() ?? "";
            txtL21.Text = dgvToaDo.Rows[1].Cells[0].Value?.ToString() ?? "";
            txtL22.Text = dgvToaDo.Rows[1].Cells[1].Value?.ToString() ?? "";
            txtL31.Text = dgvToaDo.Rows[2].Cells[0].Value?.ToString() ?? "";
            txtL32.Text = dgvToaDo.Rows[2].Cells[1].Value?.ToString() ?? "";
            txtL41.Text = dgvToaDo.Rows[3].Cells[0].Value?.ToString() ?? "";
            txtL42.Text = dgvToaDo.Rows[3].Cells[1].Value?.ToString() ?? "";
        }

        private void Btn_BTS_Build_Click(object sender, EventArgs e)
        {
            var map = new Dictionary<string, string>
            {
                ["{{SOTTR}}"] = txtSoTTr.Text.Trim(),
                ["{{DAY}}"] = txtDay.Text.Trim(),
                ["{{MONTH}}"] = txtMonth.Text.Trim(),
                ["{{YEAR}}"] = txtYear.Text.Trim(),
                ["{{DUAN}}"] = cboDuAn.Text.Trim(),
                ["{{CONGTRINH}}"] = cboCongTrinh.Text.Trim(),
                ["{{HANGMUC}}"] = cboHangMuc.Text.Trim(),
                ["{{DIADIEM}}"] = cboDiaDiem.Text.Trim(),
                ["{{MATRAM}}"] = txtMaTram.Text.Trim(),
                ["{{L11}}"] = txtL11.Text.Trim(),
                ["{{L12}}"] = txtL12.Text.Trim(),
                ["{{L21}}"] = txtL21.Text.Trim(),
                ["{{L22}}"] = txtL22.Text.Trim(),
                ["{{L31}}"] = txtL31.Text.Trim(),
                ["{{L32}}"] = txtL32.Text.Trim(),
                ["{{L41}}"] = txtL41.Text.Trim(),
                ["{{L42}}"] = txtL42.Text.Trim(),
            };

            string downloadFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),"Downloads");

            // đảm bảo thư mục tồn tại (thực ra Downloads luôn có, nhưng cứ cho chắc)
            Directory.CreateDirectory(downloadFolder);

            string suffix = txtNameAddFileBuild.Text.Trim();
            string outputPath1506 = Path.Combine(downloadFolder,string.IsNullOrWhiteSpace(suffix)? "BM-15-06 TỜ TRÌNH XIN CHỦ TRƯƠNG.docx": $"BM-15-06 TỜ TRÌNH XIN CHỦ TRƯƠNG - {suffix}.docx");
            BuildWordService.Build(@"Templates\BTS\BM-15-06 TỜ TRÌNH XIN CHỦ TRƯƠNG BTS - Templates.docx", outputPath1506, map);

            string outputPath1507 = Path.Combine(downloadFolder, string.IsNullOrWhiteSpace(suffix)? "BM-15-07 TỜ TRÌNH KÝ BIÊN BẢN THỎA THUẬN.docx" : $"BM-15-07 TỜ TRÌNH KÝ BIÊN BẢN THỎA THUẬN - {suffix}.docx");
            BuildWordService.Build(@"Templates\BTS\BM-15-07 TỜ TRÌNH KÝ BIÊN BẢN THỎA THUẬN BTS - Templates.docx", outputPath1507, map);

            string outputPathThoaThuan = Path.Combine( downloadFolder,string.IsNullOrWhiteSpace(suffix)? "BIÊN BẢN THỎA THUẬN.docx": $"BIÊN BẢN THỎA THUẬN - {suffix}.docx");
            BuildWordService.Build(@"Templates\BTS\BIÊN BẢN THỎA THUẬN BTS - Templates.docx", outputPathThoaThuan, map);

            string outputPathBienbangiaomatbang = Path.Combine(downloadFolder, string.IsNullOrWhiteSpace(suffix) ? "BM-62-12 BIÊN BẢN BÀN GIAO MẶT BẰNG BTS.docx" : $"BM-62-12 BIÊN BẢN BÀN GIAO MẶT BẰNG BTS - {suffix}.docx");
            BuildWordService.Build(@"Templates\BTS\BM-62-12 BIÊN BẢN BÀN GIAO MẶT BẰNG BTS - Templates.docx", outputPathBienbangiaomatbang, map);

            MessageBox.Show("Done!");
        }
    }
}
