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

        public EofficeBecamexBinhphuoc(string username, string password)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            username_eof = username;
            password_eof = password;
            try
            {
                if (Cef.IsInitialized != true)
                {
                    CefSettings settings = new CefSettings();
                    settings.BrowserSubprocessPath = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "CefSharp.BrowserSubprocess.exe");
                    Cef.Initialize(settings);
                }
                chromiumWebBrowser_Eoffice.FrameLoadEnd += Browser_FrameLoadEnd;
                chromiumWebBrowser_Eoffice.Load("https://login.becamexbinhphuoc.com.vn/adfs/ls?wa=wsignin1.0&wtrealm=urn%3aeofficebecamexbinhphuoc&wctx=https%3a%2f%2feoffice.becamexbinhphuoc.com.vn");
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
            }})();
            ";
                chromiumWebBrowser_Eoffice.ExecuteScriptAsync(logininfo);
            }
    }
       
    
}
