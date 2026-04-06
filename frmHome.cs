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
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            frmMain frmlogin = new frmMain(username, password, url);
            frmlogin.Show();
        }

        private void Btn_login_Tamphan_Click(object sender, EventArgs e)
        {
            string urllogin = "https://login.becamexbinhphuoc.com.vn/adfs/ls?wa=wsignin1.0&wtrealm=urn%3aeofficebecamexbinhphuoc&wctx=https%3a%2f%2feoffice.becamexbinhphuoc.com.vn";
            frmMain frmlogintamphan = new frmMain(username, password, urllogin);
            frmlogintamphan.Show();
        }

        private void Btn_calendar_Click(object sender, EventArgs e)
        {
            string urlcalendar = "https://eofficeao.becamexbinhphuoc.com.vn/lich?dep=427";
            frmMain frmcalendar = new frmMain(username, password, urlcalendar);
            frmcalendar.Show();
        }

        private void Btn_process_waiting_Click(object sender, EventArgs e)
        {
            string urlwaitingprogress = "https://eoffice.becamexbinhphuoc.com.vn/workflow/SitePages/Workflow-follow.aspx";
            frmMain frmwaitingprogress = new frmMain(username, password, urlwaitingprogress);
            frmwaitingprogress.Show();
        }

        private void Btn_BTS_Click(object sender, EventArgs e)
        {
            frmBTS frmbts = new frmBTS();
            frmbts.Show();
        }
        private void Btn_new_1506_Click(object sender, EventArgs e)
        {
            //string url1506 = "https://eoffice.becamexbinhphuoc.com.vn/workflow/SitePages/NewWorkflow.aspx?mode=1&ListID=589dfff1-f412-41fd-8824-c48a2bf66309";
            frmCre1506 frm1506 = new frmCre1506();
            frm1506.Show();
        }

        private void btnRequestLeave_Click(object sender, EventArgs e)
        {
            string urlRequestLeave = "https://eoffice.becamexbinhphuoc.com.vn/workflow/SitePages/NewWorkflow.aspx?mode=1&ListID=57f94304-f426-447e-8c76-df5345588a9f";
            string songaydanghiphep = txtSoNgayDaNghiPhep.Text.Trim();
            frmRequestLeave frmRequestLeave = new frmRequestLeave(username, password, urlRequestLeave, songaydanghiphep);
            frmRequestLeave.Show();
        }
    }
        
}
