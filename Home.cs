using CefSharp;
using System;
using System.Collections.Generic;
using System.IO;
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

        private void Btn_account_riêng_lẻ_Click(object sender, EventArgs e)
        {
            panel_account_lẻ.Visible = !panel_account_lẻ.Visible;
            if (panel_account_lẻ.Visible)
                textBox_nhập_mã_khách_hàng.Focus();
        }
        private void Btn_Login_account_riêng_lẻ_Click(object sender, EventArgs e)
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

        private void Btn_login_download_no_UI_Click(object sender, EventArgs e)
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

        private void Btn_login_eof_Click(object sender, EventArgs e)
        {
            string url = "https://login.becamexbinhphuoc.com.vn/adfs/ls?wa=wsignin1.0&wtrealm=urn%3aeofficebecamexbinhphuoc&wctx=https%3a%2f%2feoffice.becamexbinhphuoc.com.vn";
            string username = textBox_Eof_Username.Text.Trim();
            string password = textBox_Eof_Password.Text.Trim();
            EofficeBecamexBinhphuoc frmEoffice = new EofficeBecamexBinhphuoc(username, password, url);
            frmEoffice.Show();
        }

        private void Btn_login_Tamphan_Click(object sender, EventArgs e)
        {
            string url = "https://login.becamexbinhphuoc.com.vn/adfs/ls?wa=wsignin1.0&wtrealm=urn%3aeofficebecamexbinhphuoc&wctx=https%3a%2f%2feoffice.becamexbinhphuoc.com.vn";
            string username = "phanthanhtam";
            string password = "Mocungcunganhcungnhat@bcm26";
            EofficeBecamexBinhphuoc frmEoffice = new EofficeBecamexBinhphuoc(username, password, url);
            frmEoffice.Show();
        }

        private void Btn_calendar_Click(object sender, EventArgs e)
        {
            string url = "https://eofficeao.becamexbinhphuoc.com.vn/lich?dep=427";
            string username = "phanthanhtam";
            string password = "Mocungcunganhcungnhat@bcm26";
            EofficeBecamexBinhphuoc frmEoffice = new EofficeBecamexBinhphuoc(username, password, url);
            frmEoffice.Show();
        }

        private void Btn_process_waiting_Click(object sender, EventArgs e)
        {
            string url = "https://eoffice.becamexbinhphuoc.com.vn/workflow/SitePages/Workflow-follow.aspx";
            string username = "phanthanhtam";
            string password = "Mocungcunganhcungnhat@bcm26";
            EofficeBecamexBinhphuoc frmEoffice = new EofficeBecamexBinhphuoc(username, password, url);
            frmEoffice.Show();
        }

        private void Btn_BTS_Click(object sender, EventArgs e)
        {
            BTS frm = new BTS();
            frm.Show();
        }
        private void Btn_new_1506_Click(object sender, EventArgs e)
        {
            string url = "https://eoffice.becamexbinhphuoc.com.vn/workflow/SitePages/NewWorkflow.aspx?mode=1&ListID=589dfff1-f412-41fd-8824-c48a2bf66309";
            string username = "phanthanhtam";
            string password = "Mocungcunganhcungnhat@bcm26";
            Cre1506 frm = new Cre1506(username, password, url);
            frm.Show();
        }
    }
}
