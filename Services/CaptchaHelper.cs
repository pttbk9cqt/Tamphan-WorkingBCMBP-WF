using CefSharp;
using CefSharp.WinForms;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tamphan_WorkingBCMBP_WF.Models;

namespace Tamphan_WorkingBCMBP_WF.Services
{
    // Đây là class dữ liệu mô tả tọa độ captcha
    public class CaptchaRect
    {
        public double x { get; set; }
        public double y { get; set; }
        public double width { get; set; }
        public double height { get; set; }
        public double devicePixelRatio { get; set; }
    }

    // Class helper để thao tác với captcha
    public class CaptchaHelper
    {
        private readonly ChromiumWebBrowser _browser;
        private readonly CaptchaOcrService _ocrService;
        public CaptchaHelper(ChromiumWebBrowser browser)
        {
            _browser = browser;
            _ocrService = new CaptchaOcrService(); // hoặc inject nếu bạn muốn
        }

        // đoạn dưới đây sẽ lấy ảnh captcha ra
        public async Task<CaptchaRect> GetCaptchaRectAsync()
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

            var response = await _browser.EvaluateScriptAsync(jsCode);

            if (!response.Success || response.Result == null)
                return null;

            return JsonConvert.DeserializeObject<CaptchaRect>(
                JsonConvert.SerializeObject(response.Result)
            );
        }

        public async Task<Bitmap> CaptureBrowserAsync()
        {
            // CaptureScreenshotAsync returns a byte[] (PNG format), so convert it to Bitmap
            byte[] pngBytes = await _browser.CaptureScreenshotAsync();
            using (var ms = new MemoryStream(pngBytes))
            {
                return new Bitmap(ms);
            }
        }


        public Bitmap CropCaptcha(Bitmap fullImage, CaptchaRect rect)
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
        public async Task<string> SolveCaptchaAsync()
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
        public async Task AutoFillCaptchaAsync()
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

            var result = await _browser.EvaluateScriptAsync(js);
        }

    }
}
    

