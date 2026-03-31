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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace Tamphan_WorkingBCMBP_WF
{
    public partial class frmMain : Form
    {
        public string username;
        public string password;
        public string url;
        //////////////////////////////////////////////
        public frmMain(string usernamehome, string passwordhome, string urlhome)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            username = usernamehome;
            password = passwordhome;
            url = urlhome;
            InitBrowser();
        }
        //////////////////////////////////////////////
        private void InitBrowser()
        {
            chromiumeof.FrameLoadEnd += Browser_FrameLoadEnd;
            chromiumeof.Load(url);
        }
        //////////////////////////////////////////////
        private async void Browser_FrameLoadEnd(object sender, FrameLoadEndEventArgs e)
        {
            await AutoLogin(username, password);
        }
        //////////////////////////////////////////////
        private async Task AutoLogin(string username, string password)
        {
            string logininfo = $@"
            (function() 
            {{
                let userInput = document.querySelector('input[placeholder=""Tên người dùng""]');
                let passInput = document.querySelector('input[placeholder=""Mật khẩu""]');
                if (userInput && passInput) 
                {{
                    userInput.value = '{username}';
                    userInput.dispatchEvent(new Event('input', {{ bubbles: true }}));
                    passInput.value = '{password}';
                    passInput.dispatchEvent(new Event('input', {{ bubbles: true }}));
                }}
            }})();";
            chromiumeof.ExecuteScriptAsync(logininfo);// điền username và pass
            chromiumeof.ExecuteScriptAsync(@"const checkbox = document.querySelector('#kmsiInput'); checkbox && !checkbox.checked && checkbox.click();"); //tick vào checkbox
            chromiumeof.ExecuteScriptAsync("document.getElementById('submitButton').click();"); // bấm nút đăng nhập
        }
        //////////////////////////////////////////////
    }
}
