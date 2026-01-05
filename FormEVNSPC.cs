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
    public partial class FormEVNSPC : Form
    {
        private ChromiumWebBrowser browser;

        public FormEVNSPC()
        {
            InitializeComponent();

            // Treat null (and false) as "not initialized"
            if (Cef.IsInitialized != true)
            {
                Cef.Initialize(new CefSettings());
            }

            browser = new ChromiumWebBrowser("https://cskh.evnspc.vn/TaiKhoan/DangNhap?previousLink=/TraCuu/HoaDonTienDien");
            browser.Dock = DockStyle.Fill;

            panelBrowser.Controls.Add(browser);
            TestExcelFile();
        }
        private void TestExcelFile()
        {
            if (File.Exists("AccountEVN-addWF.xlsm"))
            {
                MessageBox.Show("Đã tìm thấy AccountEVN-addWF.xlsm");
            }
            else
            {
                MessageBox.Show("KHÔNG tìm thấy AccountEVN-addWF.xlsm");
            }

            var wb = new XLWorkbook("AccountEVN-addWF.xlsm");
            var ws = wb.Worksheet(1);
            string id = ws.Cell("A2").GetString();
            string mucdichsudung = ws.Cell("D2").GetString();
            string tendangnhap = ws.Cell("C2").GetString();
            string password = ws.Cell("M2").GetString();

            MessageBox.Show($"ID: {id}\nMục đích sử dụng: {mucdichsudung}\nTên đăng nhập: {tendangnhap}\nPass: {password}");
        }

    }
}
