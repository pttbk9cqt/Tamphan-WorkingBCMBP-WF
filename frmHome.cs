using CefSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Tamphan_WorkingBCMBP_WF.Models;
using Tamphan_WorkingBCMBP_WF.Services;

namespace Tamphan_WorkingBCMBP_WF
{
    public partial class frmHome : Form
    {
        string username = "phanthanhtam";
        string password = "Mocungcung@99";

        public frmHome()
        {
            InitializeComponent();
        }

        private void Btn_login_eof_Click(object sender, EventArgs e)
        {
            string url = "https://login.becamexbinhphuoc.com.vn/adfs/ls?wa=wsignin1.0&wtrealm=urn%3aeofficebecamexbinhphuoc&wctx=https%3a%2f%2feoffice.becamexbinhphuoc.com.vn";
            string username = textBox_Eof_Username.Text.Trim();
            string password = textBox_Eof_Password.Text.Trim();
            EofficeBecamexBinhphuoc frmEoffice = new EofficeBecamexBinhphuoc(username, password, url);
            frmEoffice.Show();
        }

        private void Btn_login_Tamphan_Click(object sender, EventArgs e)
        {
            string url = "https://login.becamexbinhphuoc.com.vn/adfs/ls?wa=wsignin1.0&wtrealm=urn%3aeofficebecamexbinhphuoc&wctx=https%3a%2f%2feoffice.becamexbinhphuoc.com.vn";
            EofficeBecamexBinhphuoc frmEoffice = new EofficeBecamexBinhphuoc(username, password, url);
            frmEoffice.Show();
        }

        private void Btn_calendar_Click(object sender, EventArgs e)
        {
            string url = "https://eofficeao.becamexbinhphuoc.com.vn/lich?dep=427";
            EofficeBecamexBinhphuoc frmEoffice = new EofficeBecamexBinhphuoc(username, password, url);
            frmEoffice.Show();
        }

        private void Btn_process_waiting_Click(object sender, EventArgs e)
        {
            string url = "https://eoffice.becamexbinhphuoc.com.vn/workflow/SitePages/Workflow-follow.aspx";
            EofficeBecamexBinhphuoc frmEoffice = new EofficeBecamexBinhphuoc(username, password, url);
            frmEoffice.Show();
        }

        private void Btn_BTS_Click(object sender, EventArgs e)
        {
            frmBTS frm = new frmBTS();
            frm.Show();
        }
        private void Btn_new_1506_Click(object sender, EventArgs e)
        {
            string url = "https://eoffice.becamexbinhphuoc.com.vn/workflow/SitePages/NewWorkflow.aspx?mode=1&ListID=589dfff1-f412-41fd-8824-c48a2bf66309";
            frmCre1506 frm = new frmCre1506(username, password, url);
            frm.Show();
            //if (Clipboard.ContainsText())
            //{
            //    string text = Clipboard.GetText();
            //    MessageBox.Show(text);
            //}
        }
    }
}
