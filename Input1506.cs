using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
                TieuDe = TextBox_TieuDe.Text.Trim(),
                DuAn = ComboBox_DuAn.Text.Trim(),
                CongTrinh = ComboBox_CongTrinh.Text.Trim(),
                HangMuc = TextBox_HangMuc.Text.Trim(),
                DiaDiem = ComboBox_DiaDiem.Text.Trim(),
                NCC = TextBox_NCC.Text.Trim(),
                DiaChiNCC = TextBox_NCC_DiaChi.Text.Trim(),
                SdtNCC = TextBox_NCC_SDT.Text.Trim(),
                EmailNCC = TextBox_NCC_Email.Text.Trim(),
                MSTNCC = TextBox_NCC_MST.Text.Trim(),
                STKNCC = TextBox_NCC_STK.Text.Trim(),
                DaiDienNCC = TextBox_NCC_DaiDien.Text.Trim(),
                ChucVuNCC = ComboBox_NCC_ChucVu.Text.Trim(),
                CanCu = RichTextBox_CanCu.Text.Trim(),
                NguyenNhanTrinhKy = RichTextBox_Nguyennhantrinhky.Text.Trim(),
                GiaTri = RichTextBox_Giatrihopdong.Text.Trim(),
                ThoiGianThucHien = RichTextBox_Thoigianthuchien.Text.Trim(),
                TienDoVaThoiGianThanhToan = RichTextBox_Tiendovathoigianthanhtoan.Text.Trim(),
                ThoiGianBaoHanh = TextBox_TieuDe.Text.Trim(),
                HieuLucHopDong = TextBox_TieuDe.Text.Trim(),
            };
            var map = new Dictionary<string, string>
            {
                ["{{TIEUDE}}"] = model.TieuDe,
                ["{{DUAN}}"] = model.DuAn,
                ["{{CONGTRINH}}"] = model.CongTrinh,
                ["{{HANGMUC}}"] = model.HangMuc,
                ["{{DIADIEM}}"] = model.DiaDiem,
                ["{{NCC}}"] = model.NCC,
                ["{{DIACHI_NCC}}"] = model.DiaChiNCC,
                ["{{SDT_NCC}}"] = model.SdtNCC,
                ["{{EMAIL_NCC}}"] = model.EmailNCC,
                ["{{MST_NCC}}"] = model.MSTNCC,
                ["{{STK_NCC}}"] = model.STKNCC,
                ["{{DAIDIEN_NCC}}"] = model.DaiDienNCC,
                ["{{CHUC_NCC}}"] = model.ChucVuNCC,
                ["{{LYDOCHON_NCC}}"] = model.LyDoChonNCC,
                ["{{CANCU}}"] = model.CanCu,
                ["{{NGUYENNHANTRINHKY}}"] = model.NguyenNhanTrinhKy,
                ["{{GIATRI}}"] = model.GiaTri + " VNĐ",
                ["{{THOI_GIAN_THUC_HIEN}}"] = model.ThoiGianThucHien,
                ["{{TIENDOVATHOIGIANTHANHTOAN}}"] = model.TienDoVaThoiGianThanhToan,
                ["{{THOI_GIAN_BAO_HANH}}"] = model.ThoiGianBaoHanh,
                ["{{HIEU_LUC_HOP_DONG}}"] = model.HieuLucHopDong,
            };

            var outputDir = "Output";
            Directory.CreateDirectory(outputDir);

            BuildWordService.Build(
                @"Templates\BM-15-06.docx",
                @"Output\BM-15-06_Test.docx",
                map
            );

            MessageBox.Show("Tạo Word xong!");
        }
    }
}
