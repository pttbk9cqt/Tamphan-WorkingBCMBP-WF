using System;
using System.Windows.Forms;
using Tamphan_WorkingBCMBP_WF.Models;
using Tamphan_WorkingBCMBP_WF.Services;

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
            //Kiểm tra mã khách hàng
            if (maKH.Length == 5 && !maKH.StartsWith("PB010500"))
            {
                maKH = "PB010500" + maKH;
                textBox_nhập_mã_khách_hàng.Text = maKH;
            }

            ExcelAccountService service = new ExcelAccountService();
            AccountEVN acc = service.GetAccount(maKH);
            if (acc == null)
            {
                MessageBox.Show("Mã khách hàng không tồn tại trong file excel");
                return;
            }

            if (string.IsNullOrWhiteSpace(textBox_password.Text) || textBox_password.Text != acc.Password)
            {
                textBox_password.Text = acc.Password;
            }

            //MessageBox.Show(
            //    $"ID: {acc.Id}\n" +
            //    $"Mục đích sử dụng: {acc.MucDichSuDung}\n" +
            //    $"Tên đăng nhập: {acc.MaKH}\n" +
            //    $"Pass: {acc.Password}");

            // tiếp tục xử lý login bên dưới
            EVNSPC_WEB_LOGIN frmwebdienluc = new EVNSPC_WEB_LOGIN(maKH);
            frmwebdienluc.Show();
        }

        private void btn_login_download_no_UI_Click(object sender, EventArgs e)
        {
            string maKH_no_UI = textBox_nhập_mã_khách_hàng.Text.Trim();
            //Kiểm tra mã khách hàng
            if (maKH_no_UI.Length == 5 && !maKH_no_UI.StartsWith("PB010500"))
            {
                maKH_no_UI = "PB010500" + maKH_no_UI;
                textBox_nhập_mã_khách_hàng.Text = maKH_no_UI;
            }

            ExcelAccountService service_no_UI = new ExcelAccountService();
            AccountEVN acc_no_UI = service_no_UI.GetAccount(maKH_no_UI);
            if (acc_no_UI == null)
            {
                MessageBox.Show("Mã khách hàng không tồn tại trong file excel");
                return;
            }

            if (string.IsNullOrWhiteSpace(textBox_password.Text) || textBox_password.Text != acc_no_UI.Password)
            {
                textBox_password.Text = acc_no_UI.Password;
            }

            //MessageBox.Show(
            //    $"ID: {acc_no_UI.Id}\n" +
            //    $"Mục đích sử dụng: {acc_no_UI.MucDichSuDung}\n" +
            //    $"Tên đăng nhập: {acc_no_UI.MaKH}\n" +
            //    $"Pass: {acc_no_UI.Password}");

            // tiếp tục xử lý login bên dưới
            EVNSPC_WEB_Hidden frmwebdienluc_no_UI = new EVNSPC_WEB_Hidden(maKH_no_UI);
            frmwebdienluc_no_UI.Show();
        }
    }
}
