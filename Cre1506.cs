using CefSharp;
using CefSharp.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tamphan_WorkingBCMBP_WF
{
    public partial class Cre1506 : Form
    {
        public string username_eof;
        public string password_eof;
        public string url_eof;
        public Cre1506(string username, string password, string url)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            username_eof = username;
            password_eof = password;
            url_eof = url;

            //if (Cef.IsInitialized != true)
            //{
            //    CefSettings settings = new CefSettings();
            //    settings.BrowserSubprocessPath = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "CefSharp.BrowserSubprocess.exe");
            //    Cef.Initialize(settings);
            //}
            var settings = new CefSettings() { BrowserSubprocessPath = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "CefSharp.BrowserSubprocess.exe") };
            
            ChromiumWebBrowser_Cre1506.FrameLoadEnd += Browser_FrameLoadEnd;
            ChromiumWebBrowser_Cre1506.Load(url);
        }

        private void Browser_FrameLoadEnd(object sender, FrameLoadEndEventArgs e)
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
            ChromiumWebBrowser_Cre1506.ExecuteScriptAsync(logininfo);//xong bước này là điền username và pass
            //tới bước này là tick vào checkbox (cho phép đăng nhập tự động)
            ChromiumWebBrowser_Cre1506.ExecuteScriptAsync(@"const checkbox = document.querySelector('#kmsiInput');
            checkbox && !checkbox.checked && checkbox.click();");
            //tới bước này là tick vào checkbox (cho phép đăng nhập tự động)
            ChromiumWebBrowser_Cre1506.ExecuteScriptAsync(@"const checkbox = document.querySelector('#kmsiInput');
            checkbox && !checkbox.checked && checkbox.click();");
            //tiếp theo là bấm nút đăng nhập
            ChromiumWebBrowser_Cre1506.ExecuteScriptAsync("document.getElementById('submitButton').click();");
        }
    }

}

