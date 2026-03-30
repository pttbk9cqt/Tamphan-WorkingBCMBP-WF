using CefSharp;
using CefSharp.WinForms;
using DocumentFormat.OpenXml.Bibliography;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tamphan_WorkingBCMBP_WF
{
    public partial class EofficeBecamexBinhphuoc : Form
    {
        public string username_eof;
        public string password_eof;
        public string url_eof;

        public EofficeBecamexBinhphuoc(string username, string password, string url)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            username_eof = username;
            password_eof = password;
            url_eof = url;
            try
            {
                chromiumWebBrowser_Eoffice.FrameLoadEnd += Browser_FrameLoadEnd;
                chromiumWebBrowser_Eoffice.Load(url);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khởi tạo trình duyệt: " + ex.Message);
            }
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
            chromiumWebBrowser_Eoffice.ExecuteScriptAsync(logininfo);//xong bước này là điền username và pass
            //tới bước này là tick vào checkbox (cho phép đăng nhập tự động)
            chromiumWebBrowser_Eoffice.ExecuteScriptAsync(@"const checkbox = document.querySelector('#kmsiInput');
            checkbox && !checkbox.checked && checkbox.click();");
            //tiếp theo là bấm nút đăng nhập
            chromiumWebBrowser_Eoffice.ExecuteScriptAsync("document.getElementById('submitButton').click();");
        }
    }
}
