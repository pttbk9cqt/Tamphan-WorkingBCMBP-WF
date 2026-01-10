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
        string kyHoaDon = "12.2025";

        public EVNSPC_WEB_LOGIN(string maKH)
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
            _maKH = maKH;
  
            this.WindowState = FormWindowState.Maximized;
            this.MouseDown += (s, e) =>
            {
                MessageBox.Show($"Click at {e.X},{e.Y}");
            };
            try
            {
                InitBrowser();
                _captchaHelper = new CaptchaHelper(weblogin); // tạo helper
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khởi tạo trình duyệt: " + ex.Message);
            }
        }
        string BuildPdfName(string maKH)
        {
            _maKH = maKH;
            ExcelAccountService service = new ExcelAccountService();
            AccountEVN acc = service.GetAccount(_maKH);
            //MessageBox.Show("Đang lưu file cho mã KH: " + acc.MucDichSuDung);
            return "Thông báo tiền điện tháng " + kyHoaDon + "_" + acc.MucDichSuDung +"_" +_maKH + ".pdf";
        }
        private void InitBrowser()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(InitBrowser));
            }
            else
            {
                if (Cef.IsInitialized != true)
                {
                    CefSettings settings = new CefSettings();
                    //settings.ChromeRuntime = true;
                    settings.BrowserSubprocessPath = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "CefSharp.BrowserSubprocess.exe");
                    Cef.Initialize(settings);
                }
                weblogin.FrameLoadEnd += Browser_FrameLoadEndAsync;
                string url = "https://cskh.evnspc.vn/TaiKhoan/DangNhap?previousLink=/TraCuu/HoaDonTienDien";
                //weblogin.DownloadHandler = new DownloadHandler();
                var downloadHandler = new BlobPdfDownloadHandler(
                                                    @"E:\Điện\Đóng tiền điện\hoadon", () => BuildPdfName(_maKH));
                downloadHandler.PdfDownloaded += delegate (string path)
                {
                    Console.WriteLine("PDF saved: " + path);
                };
                weblogin.DownloadHandler = downloadHandler;
                weblogin.Load(url);
            }
        }
        private async void Browser_FrameLoadEndAsync(object sender, FrameLoadEndEventArgs e)
        {
            if (!e.Frame.IsMain)
                return;
            if (!e.Url.Contains("cskh.evnspc.vn/TaiKhoan/DangNhap"))
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
            weblogin.ExecuteScriptAsync(fill_maKH_pass_Script);
            //tới đây là đã tự điền mã KH và pass

            // đợi captcha render
            await Task.Delay(500);

            // GỌI AUTO CAPTCHA TẠI ĐÂY
            await _captchaHelper.AutoFillCaptchaAsync();
            // ĐẾN ĐÂY LÀ ĐÃ ĐIỀN XONG CAPTCHA VÀO TRANG WEB

            //Ghi lại địa chỉ trang web hiện tại
            string currentUrl = weblogin.Address;

            await Task.Delay(700);
            // Tiếp đó là bấm nút đăng nhập
            weblogin.ExecuteScriptAsync("document.getElementById('btnDangNhap').click();");

            await Task.Delay(700); // chờ load trang sau khi đăng nhập

            //nếu bị lỗi captcha hoặc đăng nhập không thành công thì thử lại
            for (int i = 0; i <= 4; i++) // thử 4 lần
                if (weblogin.Address.Contains("cskh.evnspc.vn/TaiKhoan/DangNhap"))
                {
                    weblogin.Reload();
                    await Task.Delay(1000); // chờ load lại trang
                    weblogin.ExecuteScriptAsync(fill_maKH_pass_Script);
                    await _captchaHelper.AutoFillCaptchaAsync();
                    await Task.Delay(2000);
                    MessageBox.Show("ID:" + acc.Id + " mã KH:" + acc.MaKH + " " + acc.MucDichSuDung);
                    weblogin.ExecuteScriptAsync("document.getElementById('btnDangNhap').click();");
                    await Task.Delay(2000);
                }
                else
                {
                    break; // đăng nhập thành công, thoát vòng lặp
                }
            // tới đây là đã đăng nhập thành công rồi

            //Nếu chưa nhấn OK thì vẫn dừng ở đây, và chưa chạy dòng code ở dưới đâu
            //click vào nút xem hóa đơn
            weblogin.ExecuteScriptAsync("document.querySelector('a.invoice-btn.view-btn.cursor').click();");
            //
            //auto trigger pdf view and auto download

            // chờ 15s để chắc chắn view file thông báo lên
            await Task.Delay(15000);
            //auto trigger pdf view and auto download
            //click vào nút tải hóa đơn
            int X = 1350;//Convert.ToInt32(weblogin.Width * 0.711); tính ngược lại ra 1899.7
            int Y = 140;//Convert.ToInt32(weblogin.Height * 0.139);tính ngược lại ra 1007.2
            weblogin.GetBrowser().GetHost().SendMouseClickEvent(X, Y, MouseButtonType.Left, false, 1, CefEventFlags.None);
            await Task.Delay(150);
            weblogin.GetBrowser().GetHost().SendMouseClickEvent(X, Y, MouseButtonType.Left, true, 1, CefEventFlags.None);

        }

        private void weblogin_MouseUp(object sender, MouseEventArgs e)
        {
            MessageBox.Show($"MouseUp at ({e.X}, {e.Y})" );
        }

        private void weblogin_MouseClick(object sender, MouseEventArgs e)
        {
            MessageBox.Show($"MouseClick at ({e.X}, {e.Y})");
        }

        private async void btn_download_thu_cong_Click(object sender, EventArgs e)
        {
            int X = 1350;//Convert.ToInt32(weblogin.Width * 0.711);
            int Y = 140;//Convert.ToInt32(weblogin.Height * 0.139);
            weblogin.GetBrowser().GetHost().SendMouseClickEvent(X, Y, MouseButtonType.Left, false, 1, CefEventFlags.None);
            await Task.Delay(150);
            weblogin.GetBrowser().GetHost().SendMouseClickEvent(X, Y, MouseButtonType.Left, true, 1, CefEventFlags.None);
        }


    }
}
