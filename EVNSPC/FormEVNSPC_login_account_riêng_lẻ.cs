using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;
using ClosedXML.Excel;


namespace Tamphan_WorkingBCMBP_WF
{
    public partial class FormEVNSPC_login_account_riêng_lẻ : Form
    {
        private ChromiumWebBrowser browser;

        public FormEVNSPC_login_account_riêng_lẻ()
        {
            InitializeComponent();

            // Treat null (and false) as "not initialized"
            if (Cef.IsInitialized != true)
            {
                Cef.Initialize(new CefSettings());
            }

            browser = new ChromiumWebBrowser("https://cskh.evnspc.vn/TaiKhoan/DangNhap?previousLink=/TraCuu/HoaDonTienDien");
            browser.Dock = DockStyle.Fill;
            this.WindowState = FormWindowState.Maximized;
            panelBrowser.Controls.Add(browser);
        }


    }
}
