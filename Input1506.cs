using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tamphan_WorkingBCMBP_WF.Models;
using Tamphan_WorkingBCMBP_WF.Services;

namespace Tamphan_WorkingBCMBP_WF
{
    public partial class Input1506 : Form
    {
        public Input1506()
        {
            InitializeComponent();

            var model = new DataHopdong
            {
                TieuDe = "TỜ TRÌNH PHÊ DUYỆT HỢP ĐỒNG",
                DuAn = "Dự án A",
                CongTrinh = "Công trình B",
                HangMuc = "Hạng mục C",
                DiaDiem = "Bình Phước",
                DonViThiCong = "Công ty XYZ",
                GiaTri = 1500000000,
                LyDoChonNhaCungCap = "Đủ năng lực, giá hợp lý",
                ThoiGianThucHien = "120 ngày",
                ThoiGianBaoHanh = "12 tháng",
                HinhThucThanhToan = "Chuyển khoản",
                HieuLucHopDong = DateTime.Today,
                DieuKhoanKhac = "Theo quy định hiện hành"
            };


        }

        private void ComboBox_DuAn_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox_DuAn.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            ComboBox_DuAn.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void ComboBox_CongTrinh_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ComboBox_DiaDiem_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void TextBox_HangMuc_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
