using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClosedXML.Excel;
using System.IO;
using Tamphan_WorkingBCMBP_WF.Models;
using Tamphan_WorkingBCMBP_WF.Services;

namespace Tamphan_WorkingBCMBP_WF
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void btnHopdongThoathuan_Click(object sender, EventArgs e)
        {

        }


        private void btn_account_riêng_lẻ_Click(object sender, EventArgs e)
        {
            panel_account_lẻ.Visible = !panel_account_lẻ.Visible;
            if (panel_account_lẻ.Visible)
                textBox_nhập_mã_khách_hàng.Focus();
        }
        private void button_Login_account_riêng_lẻ_Click(object sender, EventArgs e)
        {
            string maKH = textBox_nhập_mã_khách_hàng.Text.Trim();
            //Kiểm tra mã khách hàng
            if (maKH.Length == 5 && !maKH.StartsWith("PB010500"))
            {
                maKH = "PB010500" + maKH;
                textBox_nhập_mã_khách_hàng.Text = maKH;
            }

            ExcelAccountService service = new ExcelAccountService();
            AccountEVN acc = service.GetAccount(maKH);
            if (acc == null)
            {
                MessageBox.Show("Mã khách hàng không tồn tại trong file excel");
                return;
            }

            if (string.IsNullOrWhiteSpace(textBox_password.Text) || textBox_password.Text != acc.Password)
            {
                textBox_password.Text = acc.Password;
            }


            //MessageBox.Show(
            //    $"ID: {acc.Id}\n" +
            //    $"Mục đích sử dụng: {acc.MucDichSuDung}\n" +
            //    $"Tên đăng nhập: {acc.MaKH}\n" +
            //    $"Pass: {acc.Password}");

            // tiếp tục xử lý login bên dưới
            FormEVNSPC_login_account_riêng_lẻ frmwebdienluc = new FormEVNSPC_login_account_riêng_lẻ(maKH);
            frmwebdienluc.Show();
        }


    }
}
