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

        private void Btn1506(object sender, EventArgs e)
        {

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

        private void BtnTestWord_Click(object sender, EventArgs e)
        {
            var model = new DataHopdong
            {
                TieuDe = "TỜ TRÌNH PHÊ DUYỆT HỢP ĐỒNG",
                DuAn = "Dự án A",
                CongTrinh = "Công trình B",
                HangMuc = "Hạng mục C",
                DiaDiem = "Bình Phước",
                DonViThiCong = "Công ty XYZ",
                GiaTri = 1500000000,
                LyDoChonNhaCungCap = "Đủ năng lực, giá hợp lý",
                ThoiGianThucHien = "120 ngày",
                ThoiGianBaoHanh = "12 tháng",
                HinhThucThanhToan = "Chuyển khoản",
                HieuLucHopDong = DateTime.Today,
                DieuKhoanKhac = "Theo quy định hiện hành"
            };

            var map = new Dictionary<string, string>
            {
                ["{{TIEU_DE}}"] = model.TieuDe,
                ["{{DU_AN}}"] = model.DuAn,
                ["{{CONG_TRINH}}"] = model.CongTrinh,
                ["{{HANG_MUC}}"] = model.HangMuc,
                ["{{DIA_DIEM}}"] = model.DiaDiem,
                ["{{DON_VI_THI_CONG}}"] = model.DonViThiCong,
                ["{{GIA_TRI}}"] = model.GiaTri.ToString("N0") + " VNĐ",
                ["{{LY_DO_CHON_NCC}}"] = model.LyDoChonNhaCungCap,
                ["{{THOI_GIAN_THUC_HIEN}}"] = model.ThoiGianThucHien,
                ["{{THOI_GIAN_BAO_HANH}}"] = model.ThoiGianBaoHanh,
                ["{{HINH_THUC_THANH_TOAN}}"] = model.HinhThucThanhToan,
                ["{{HIEU_LUC_HOP_DONG}}"] = model.HieuLucHopDong.ToString("dd/MM/yyyy"),
                ["{{DIEU_KHOAN_KHAC}}"] = model.DieuKhoanKhac
            };

            var outputDir = "Output";
            Directory.CreateDirectory(outputDir);

            BuildWordService.Build(
                @"Templates\HopDong_15-06_Template.docx",
                @"Output\HopDong_15-06_Test.docx",
                map
            );

            MessageBox.Show("Tạo Word xong!");
        }

        private void Btn_new_1506_Click(object sender, EventArgs e)
        {
            Input1506 frm = new Input1506();
            frm.Show();
        }
    }
}
