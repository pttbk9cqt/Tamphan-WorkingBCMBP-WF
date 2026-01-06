using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;
using ClosedXML.Excel;
using System.IO;

namespace Tamphan_WorkingBCMBP_WF
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void btnHopdongThoathuan_Click(object sender, EventArgs e)
        {

        }


        private void btn_account_riêng_lẻ_Click(object sender, EventArgs e)
        {
            panel_account_lẻ.Visible = !panel_account_lẻ.Visible;
            if (panel_account_lẻ.Visible)
                textBox_nhập_mã_khách_hàng.Focus();
        }
        private void button_Login_account_riêng_lẻ_Click(object sender, EventArgs e)
        {
            string maKH = textBox_nhập_mã_khách_hàng.Text.Trim();

            if (maKH.Length == 5 && !maKH.StartsWith("PB010500"))
            {
                maKH = "PB010500" + maKH;
                textBox_nhập_mã_khách_hàng.Text = maKH;
            }

            if (string.IsNullOrWhiteSpace(textBox_password.Text))
            {
                string excelPath = @"AccountEVN-addWF.xlsm";

                using (var wb = new XLWorkbook(excelPath))
                {
                    var ws = wb.Worksheet(1);

                    bool found = false;

                    foreach (var row in ws.RowsUsed().Skip(1))
                    {
                        if (row.Cell("C").GetString().Trim() == maKH)
                        {
                            textBox_password.Text = row.Cell("M").GetString();
                            found = true;
                            break;
                        }
                    }

                    if (!found)
                    {
                        MessageBox.Show("Không tìm thấy mã khách hàng trong Excel");
                        return;
                    }
                }
            }
            RunExcelFile(maKH);


            // tiếp tục xử lý login bên dưới
            FormEVNSPC_login_account_riêng_lẻ frm = new FormEVNSPC_login_account_riêng_lẻ();
            frm.Show();
        }
        private void RunExcelFile(string maKH)
        {
            if (!File.Exists("AccountEVN-addWF.xlsm"))
            {
                MessageBox.Show("KHÔNG tìm thấy AccountEVN-addWF.xlsm");
                return;
            }

            using (var wb = new XLWorkbook("AccountEVN-addWF.xlsm"))
            {
                var ws = wb.Worksheet(1);

                bool found = false;

                for (int row = 2; row <= 1000; row++)
                {
                    string maKH_Excel = ws.Cell(row, "C").GetString().Trim();

                    if (maKH_Excel == maKH)
                    {
                        string id = ws.Cell(row, "A").GetString();
                        string mucdichsudung = ws.Cell(row, "D").GetString();
                        string password = ws.Cell(row, "M").GetString();

                        MessageBox.Show(
                            $"ID: {id}\n" +
                            $"Mục đích sử dụng: {mucdichsudung}\n" +
                            $"Tên đăng nhập: {maKH}\n" +
                            $"Pass: {password}"
                        );

                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    MessageBox.Show("Không tìm thấy mã khách hàng trong phạm vi dòng 2–1000");
                }
            }
        }

    }
}
