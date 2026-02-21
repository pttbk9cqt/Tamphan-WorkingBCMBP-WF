using CefSharp;
using CefSharp.WinForms;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tamphan_WorkingBCMBP_WF.Services;
using static FieldBindingManager;

namespace Tamphan_WorkingBCMBP_WF
{
    public partial class Cre1506Panel : Form
    {
        public string username_eof;
        public string password_eof;
        public string url_eof;
        private FieldBindingManager _bindingManager;
        private bool _isLoggedIn = false;

        public Cre1506Panel(string username, string password, string url)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            username_eof = username;
            password_eof = password;
            url_eof = url;
            MousePositionHelper.Start(this);  //đây là hàm lấy tọa độ con trỏ chuột
            //dưới đây là phần khởi tạo của CefSharp
            //var settings = new CefSettings() { BrowserSubprocessPath = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "CefSharp.BrowserSubprocess.exe") };
            ChromiumWebBrowser_Cre1506Panel.FrameLoadEnd += Browser_FrameLoadEnd;
            ChromiumWebBrowser_Cre1506Panel.IsBrowserInitializedChanged += Browser_IsBrowserInitializedChanged;    // thêm Devtools cho trình duyệt
            ChromiumWebBrowser_Cre1506Panel.Load(url_eof);
        }


        // Mở DevTools khi browser init xong
        private void Browser_IsBrowserInitializedChanged(object sender, EventArgs e)
        {
            if (ChromiumWebBrowser_Cre1506Panel.IsBrowserInitialized)
            {
                this.Invoke(new Action(() => { ChromiumWebBrowser_Cre1506Panel.ShowDevTools(); }));
            }
        }
        private async void Browser_FrameLoadEnd(object sender, FrameLoadEndEventArgs e)
        {
            if (!e.Frame.IsMain)
                return;

            var url = e.Url;
            // Nếu đang ở trang login
            if (!_isLoggedIn && url.Contains("login"))
            {
                string logininfo = $@"
                (function() 
                {{
                    let userInput = document.querySelector('input[placeholder=""Tên người dùng""]');
                    let passInput = document.querySelector('input[placeholder=""Mật khẩu""]');
                    if (userInput && passInput) 
                    {{
                        userInput.value = '{username_eof}'; 
                        userInput.dispatchEvent(new Event('input', {{ bubbles: true }}));
                        passInput.value = '{password_eof}'; 
                        passInput.dispatchEvent(new Event('input', {{ bubbles: true }}));
                    }}
                }})();";
                ChromiumWebBrowser_Cre1506Panel.ExecuteScriptAsync(logininfo);
                ChromiumWebBrowser_Cre1506Panel.ExecuteScriptAsync(@"const checkbox = document.querySelector('#kmsiInput'); checkbox && !checkbox.checked && checkbox.click();");
                ChromiumWebBrowser_Cre1506Panel.ExecuteScriptAsync("document.getElementById('submitButton').click();");
                return;
            }

            // ================= SAU LOGIN =================
            if (!_isLoggedIn)
            {
                _isLoggedIn = true;

                var fieldMap = new Dictionary<string, ListBox>
                    {
                        { "Dự án", listBoxDuAn },
                        { "Công trình", listBoxCongTrinh },
                        { "Hạng mục", listBoxHangMuc }
                    };

                _bindingManager = new FieldBindingManager(ChromiumWebBrowser_Cre1506Panel, PanelCre1506, fieldMap);

                // ĐĂNG KÝ BRIDGE TRƯỚC
                ChromiumWebBrowser_Cre1506Panel.JavascriptObjectRepository.ResolveObject += (s, ev) =>
                {
                    if (ev.ObjectName == "bridge")
                    {
                        ev.ObjectRepository.Register("bridge", new FieldBindingManager.JsBridge(_bindingManager), isAsync: true);
                    }
                };
                await _bindingManager.InjectFocusListenerAsync();
            }
        }


        private async void Btn_Build_Cre1506_Click(object sender, EventArgs e)
        {
            string TieuDe = (await ChromiumWebBrowser_Cre1506Panel.EvaluateScriptAsync(@"(() => document.querySelector(""[name='Tiêu đề']"")?.value.trim())()")).Result?.ToString();
            string DuAn = (await ChromiumWebBrowser_Cre1506Panel.EvaluateScriptAsync(@"(() => document.querySelector(""[name='Dự án']"")?.value.trim())()")).Result?.ToString();
            string CongTrinh = (await ChromiumWebBrowser_Cre1506Panel.EvaluateScriptAsync(@"(() => document.querySelector(""[name='Công trình']"")?.value.trim())()")).Result?.ToString();
            string HangMuc = (await ChromiumWebBrowser_Cre1506Panel.EvaluateScriptAsync(@"(() => document.querySelector(""[name='Hạng mục']"")?.value.trim())()")).Result?.ToString();
            string CongTy1 = (await ChromiumWebBrowser_Cre1506Panel.EvaluateScriptAsync(@"(() => document.querySelector(""[name='Công ty 1']"")?.value.trim())()")).Result?.ToString();
            string CongTy2 = (await ChromiumWebBrowser_Cre1506Panel.EvaluateScriptAsync(@"(() => document.querySelector(""[name='Công ty 2']"")?.value.trim())()")).Result?.ToString();
            string CongTy3 = (await ChromiumWebBrowser_Cre1506Panel.EvaluateScriptAsync(@"(() => document.querySelector(""[name='Công ty 3']"")?.value.trim())()")).Result?.ToString();
            string NCC = (await ChromiumWebBrowser_Cre1506Panel.EvaluateScriptAsync(@"(() => document.querySelector(""[name='Nhà cung cấp được chọn']"")?.value.trim())()")).Result?.ToString();
            // ở trên đã chạy ok hết rồi, tới bước lấy lý do chọn nhà cung cấp, bước này tuất code
            ////////////////////////////////////////////////////////////////////////////////////////////////
            string LyDoChonNCC = ChromiumWebBrowser_Cre1506Panel.EvaluateScriptAsync<string>(@"[document.querySelectorAll(""iframe"")][0][1].contentDocument.body.innerText;").Result;

            MessageBox.Show(LyDoChonNCC);

            var map = new Dictionary<string, string>
            {
                ["{{SOTTR}}"] = TextBox_BTS_SoTTr1506.Text.Trim(),
                ["{{DAY}}"] = TextBox_BTS_Ngay.Text.Trim(),
                ["{{MONTH}}"] = TextBox_BTS_Thang.Text.Trim(),
                ["{{YEAR}}"] = TextBox_BTS_Nam.Text.Trim(),
                ["{{DUAN}}"] = DuAn,
                ["{{CONGTRINH}}"] = CongTrinh,
                ["{{HANGMUC}}"] = HangMuc,
                ["{{DIADIEM}}"] = "Phường Chơn Thành, tỉnh Đồng Nai",
                ["{{LYDOCHONNCC}}"] = LyDoChonNCC,
            };
            ///////////////////////////////////////////////////////////////////////////////////////////////////
            // ở dưới là bước build word
            //Directory.CreateDirectory("Output");
            //string suffix = TextBox_NameAddFileBuild.Text.Trim();
            //string outputPath1506 = $@"Output\BM-15-06 Tờ trình xin chủ trương - {suffix}.docx";
            //BuildWordService.Build(@"Templates\Contract\BM-15-06 TỜ TRÌNH XIN CHỦ TRƯƠNG - Templates.docx", outputPath1506, map);
            //string outputPath1507 = $@"Output\BM-15-07 Tờ trình ký hợp đồng - {suffix}.docx";
            //BuildWordService.Build(@"Templates\Contract\BM-15-07 TỜ TRÌNH KÝ HỢP ĐỒNG - Templates.docx", outputPath1507, map);
            //string outputPathHopDong = $@"Output\HỢP ĐỒNG THI CÔNG - {suffix}.docx";
            //BuildWordService.Build(@"Templates\Contract\HỢP ĐỒNG THI CÔNG - Templates.docx", outputPathHopDong, map);
            MessageBox.Show("Done!");
        }
    }

}