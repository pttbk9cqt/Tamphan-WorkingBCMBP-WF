using CefSharp;
using CefSharp.WinForms;
using DocumentFormat.OpenXml.Drawing.ChartDrawing;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tamphan_WorkingBCMBP_WF.Models;
using Tamphan_WorkingBCMBP_WF.Services;

namespace Tamphan_WorkingBCMBP_WF
{
    public partial class EVNSPC_WEB_LOGIN : Form
    {
        private string _maKH;
        private CaptchaHelper _captchaHelper;
        string kyHoaDon = "01.2026";
        private bool _DownloadBtnClicked = false;
        private bool _LoginSuccess = false;

        public EVNSPC_WEB_LOGIN(string maKH)
        {
            InitializeComponent();
            _maKH = maKH;
            this.WindowState = FormWindowState.Maximized;
            InitBrowser();
            _captchaHelper = new CaptchaHelper(weblogin); // tạo helper

        }

        private void InitBrowser()
        {
            if (Cef.IsInitialized != true)
            {
                CefSettings settings = new CefSettings();
                settings.BrowserSubprocessPath = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "CefSharp.BrowserSubprocess.exe");
                Cef.Initialize(settings);
            }
            weblogin.FrameLoadEnd += Browser_FrameLoadEndAsync;
            string url = "https://cskh.evnspc.vn/TaiKhoan/DangNhap?previousLink=/TraCuu/HoaDonTienDien";
            MousePositionHelper.Start(this);
            var downloadHandler = new BlobPdfDownloadHandler(@"E:\Điện\Đóng tiền điện\ThongBaoVaHoaDonDien", () => BuildPdfName(_maKH));
            downloadHandler.PdfDownloaded += delegate (string path) {Console.WriteLine("PDF saved: " + path); };
            weblogin.DownloadHandler = downloadHandler;
            weblogin.Load(url);
        }
        private async void Browser_FrameLoadEndAsync(object sender, FrameLoadEndEventArgs e)
        {
            if (!e.Frame.IsMain)
                return;
            if (!e.Url.Contains("cskh.evnspc.vn/TaiKhoan/DangNhap"))
                return;
            if (_LoginSuccess)
                return;
            if (_DownloadBtnClicked)
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
            weblogin.ExecuteScriptAsync(fill_maKH_pass_Script);//tới đây là đã tự điền mã KH và pass
            await Task.Delay(500);
            await _captchaHelper.AutoFillCaptchaAsync();// ĐẾN ĐÂY LÀ ĐÃ ĐIỀN XONG CAPTCHA VÀO TRANG WEB
            await Task.Delay(1200);
            weblogin.ExecuteScriptAsync("document.getElementById('btnDangNhap').click();");// Tiếp đó là bấm nút đăng nhập
            await Task.Delay(1200); // chờ load trang sau khi đăng nhập

            //nếu bị lỗi captcha hoặc đăng nhập không thành công thì thử lại
            for (int i = 0; i <= 3; i++) // thử 3 lần
                if (weblogin.Address.Contains("cskh.evnspc.vn/TaiKhoan/DangNhap"))
                {
                    weblogin.Reload();
                    await Task.Delay(1000); // chờ load lại trang
                    weblogin.ExecuteScriptAsync(fill_maKH_pass_Script);
                    await _captchaHelper.AutoFillCaptchaAsync();
                    await Task.Delay(700);
                    weblogin.ExecuteScriptAsync("document.getElementById('btnDangNhap').click();");
                    await Task.Delay(2000);
                }
                else
                {
                    _LoginSuccess = true;
                    break; // đăng nhập thành công, thoát vòng lặp
                }


            //tới đây là đã đăng nhập thành công rồi, click vào nút view thông báo/hóa đơn (nếu có thông báo thì vẫn nút đó, nếu có hóa đơn rồi thì vẫn nút tên đó không đổi)
            weblogin.ExecuteScriptAsync("document.querySelector('a.invoice-btn.view-btn.cursor').click();");
            await Task.Delay(5000);// chờ 5s để chắc chắn view file thông báo lên
            //click vào nút tải hóa đơn
            int X = 1350;//Convert.ToInt32(weblogin.Width * 0.711); tính ngược lại ra 1899.7; thì ở setup là 1900
            int Y = 140;//Convert.ToInt32(weblogin.Height * 0.139);tính ngược lại ra 1007.2; thì ở setup là 1000
            //int X = 1365;//ứng với setup 1920
            //int Y = 165;//ứng với setup 1080
            //3 dòng dưới đây là giả lập click chuột tại tọa độ X Y
            weblogin.GetBrowser().GetHost().SendMouseClickEvent(X, Y, MouseButtonType.Left, false, 1, CefEventFlags.None);
            await Task.Delay(150);
            weblogin.GetBrowser().GetHost().SendMouseClickEvent(X, Y, MouseButtonType.Left, true, 1, CefEventFlags.None);
            _DownloadBtnClicked = true;
        }

        string BuildPdfName(string maKH)
        {
            _maKH = maKH;
            ExcelAccountService service = new ExcelAccountService();
            AccountEVN acc = service.GetAccount(_maKH);
            return acc.MucDichSuDung + "_" + "Thông báo tiền điện tháng " + kyHoaDon + "_" + _maKH + ".pdf";
        }
    }
}
