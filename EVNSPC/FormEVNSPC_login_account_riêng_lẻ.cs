using CefSharp;
using CefSharp.WinForms;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Wordprocessing;
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
using Newtonsoft.Json;
using Tesseract;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace Tamphan_WorkingBCMBP_WF
{
    public partial class FormEVNSPC_login_account_riêng_lẻ : Form
    {
        private ChromiumWebBrowser browser;
        private string _maKH;
        private CaptchaHelper _captchaHelper;

        public FormEVNSPC_login_account_riêng_lẻ(string maKH)
        {
            InitializeComponent();
            _maKH = maKH;
            if (Cef.IsInitialized != true)
            {
                Cef.Initialize(new CefSettings());
            }

            browser = new ChromiumWebBrowser("https://cskh.evnspc.vn/TaiKhoan/DangNhap?previousLink=/TraCuu/HoaDonTienDien");
            browser.Dock = DockStyle.Fill;
            browser.FrameLoadEnd += Browser_FrameLoadEndAsync;
            this.WindowState = FormWindowState.Maximized;
            panelBrowser.Controls.Add(browser);
            _maKH = maKH;
            _captchaHelper = new CaptchaHelper(browser); // tạo helper
        }

        private async void Browser_FrameLoadEndAsync(object sender, FrameLoadEndEventArgs e)
        {
            if (!e.Frame.IsMain)
                return;

            ExcelAccountService service = new ExcelAccountService();
            AccountEVN acc = service.GetAccount(_maKH);

            if (acc == null)
                return;

            string fill_maKH_pass_Script = $@"
            (function() 
            {{
                let userInput = document.querySelector('input[placeholder=""TÊN ĐĂNG NHẬP""]');
                let passInput = document.querySelector('input[placeholder=""MẬT KHẨU""]');
                if (userInput && passInput) 
                {{
                    userInput.value = '{acc.MaKH}';
                    userInput.dispatchEvent(new Event('input', {{ bubbles: true }}));
                    passInput.value = '{acc.Password}';
                    passInput.dispatchEvent(new Event('input', {{ bubbles: true }}));
                }}
            }})();
            ";
            browser.ExecuteScriptAsync(fill_maKH_pass_Script);
            //tới đây là đã tự điền mã KH và pass

            // đợi captcha render
            await Task.Delay(700);

            // GỌI AUTO CAPTCHA TẠI ĐÂY
            await _captchaHelper.AutoFillCaptchaAsync();
            // ĐẾN ĐÂY LÀ ĐÃ ĐIỀN XONG CAPTCHA VÀO TRANG WEB

            await Task.Delay(700);
            // Tiếp đó là bấm nút đăng nhập
            browser.ExecuteScriptAsync("document.getElementById('btnDangNhap').click();");


            //Nếu captcha sai thì phải làm lại từ đầu
            browser.ExecuteScriptAsync("RefreshCaptcha();");
            // GỌI AUTO CAPTCHA TẠI ĐÂY
            await _captchaHelper.AutoFillCaptchaAsync();
            await Task.Delay(700);
            browser.ExecuteScriptAsync("document.getElementById('btnDangNhap').click();");


        }

      

        //code nút test captcha để check thủ công
        private async void btn_TestCaptcha_Click(object sender, EventArgs e)
        {
            string text = await _captchaHelper.SolveCaptchaAsync();

            if (string.IsNullOrEmpty(text))
            {
                MessageBox.Show("Không đọc được captcha");
                return;
            }
            MessageBox.Show("OCR đọc được:\n" + text);
        }
    }
}
