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
            browser.FrameLoadEnd += Browser_FrameLoadEndAsync; // No change needed here, just ensure the handler is 'void'
            this.WindowState = FormWindowState.Maximized;
            panelBrowser.Controls.Add(browser);
            _maKH = maKH;
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
            await AutoFillCaptchaAsync();
            // ĐẾN ĐÂY LÀ ĐÃ ĐIỀN XONG CAPTCHA VÀO TRANG WEB

            await Task.Delay(700);
            // Tiếp đó là bấm nút đăng nhập
            browser.ExecuteScriptAsync("document.getElementById('btnDangNhap').click();");


            //Nếu captcha sai thì phải làm lại từ đầu
            browser.ExecuteScriptAsync("RefreshCaptcha();");
            // GỌI AUTO CAPTCHA TẠI ĐÂY
            await AutoFillCaptchaAsync();
            await Task.Delay(700);
            browser.ExecuteScriptAsync("document.getElementById('btnDangNhap').click();");


        }

        // đoạn dưới đây sẽ lấy ảnh captcha ra
        private async Task<CaptchaRect> GetCaptchaRectAsync()
        {
            var jsCode = @"
            (function () {
                var img = document.getElementById('imgCaptcha');
                if (!img) return null;

                var rect = img.getBoundingClientRect();
                return {
                    x: rect.left,
                    y: rect.top,
                    width: rect.width,
                    height: rect.height,
                    devicePixelRatio: window.devicePixelRatio
                };
            })();
            ";

            var response = await browser.EvaluateScriptAsync(jsCode);

            if (!response.Success || response.Result == null)
                return null;

            return JsonConvert.DeserializeObject<CaptchaRect>(
                JsonConvert.SerializeObject(response.Result)
            );
        }

        private async Task<Bitmap> CaptureBrowserAsync()
        {
            // CaptureScreenshotAsync returns a byte[] (PNG format), so convert it to Bitmap
            byte[] pngBytes = await browser.CaptureScreenshotAsync();
            using (var ms = new MemoryStream(pngBytes))
            {
                return new Bitmap(ms);
            }
        }


        private Bitmap CropCaptcha(Bitmap fullImage, CaptchaRect rect)
        {
            float scale = (float)rect.devicePixelRatio;

            Rectangle cropRect = new Rectangle(
                (int)(rect.x * scale),
                (int)(rect.y * scale),
                (int)(rect.width * scale),
                (int)(rect.height * scale)
            );

            return fullImage.Clone(cropRect, fullImage.PixelFormat);
        }


        // đoạn này chỉ làm đúng 1 việc: trả về text captcha
        private async Task<string> SolveCaptchaAsync()
        {
            var rect = await GetCaptchaRectAsync();
            if (rect == null)
                return null;

            Bitmap fullPage = await CaptureBrowserAsync();
            Bitmap captcha = CropCaptcha(fullPage, rect);

            captcha.Save("captcha.png"); // debug nếu cần

            var ocr = new CaptchaOcrService();
            string text = ocr.ReadCaptcha(captcha);

            return text;
        }


        //đoạn code điền captcha sau khi đã xử lý hoàn chỉnh vào web
        private async Task AutoFillCaptchaAsync()
        {
            string captchaText = await SolveCaptchaAsync();
            if (string.IsNullOrEmpty(captchaText))
                return;

            string js = $@"
            (function(){{
                var el = document.querySelector('input[placeholder=""Nhập chính xác nội dung ở trên.""]');
                if(!el) return 'NOT_FOUND';

                el.focus();
                el.value = '{captchaText}';
                el.dispatchEvent(new Event('input', {{ bubbles: true }}));
                el.dispatchEvent(new Event('change', {{ bubbles: true }}));
                return 'OK';
            }})();
            ";

            var result = await browser.EvaluateScriptAsync(js);
        }

        //code nút test captcha để check thủ công
        private async void btn_TestCaptcha_Click(object sender, EventArgs e)
        {
            string text = await SolveCaptchaAsync();

            if (string.IsNullOrEmpty(text))
            {
                MessageBox.Show("Không đọc được captcha");
                return;
            }

            MessageBox.Show("OCR đọc được:\n" + text);
        }
    }
}
