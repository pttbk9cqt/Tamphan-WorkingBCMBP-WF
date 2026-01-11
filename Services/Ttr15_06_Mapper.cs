using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tamphan_WorkingBCMBP_WF.Models;

namespace Tamphan_WorkingBCMBP_WF.Services
{
    internal class Ttr15_06_Mapper
    {
        public static Dictionary<string, string> Map(DataHopdong model)
        {
            return new Dictionary<string, string>
            {
                ["{{TIEU_DE}}"] = model.TieuDe,
                ["{{DU_AN}}"] = model.DuAn,
                ["{{CONG_TRINH}}"] = model.CongTrinh,
                ["{{HANG_MUC}}"] = model.HangMuc,
                ["{{DIA_DIEM}}"] = model.DiaDiem,
                ["{{DON_VI_THI_CONG}}"] = model.DonViThiCong,
                ["{{GIA_TRI}}"] = model.GiaTri.ToString("N0") + " VNĐ",
                ["{{LY_DO_CHON_NCC}}"] = model.LyDoChonNhaCungCap,
                ["{{THOI_GIAN_THUC_HIEN}}"] = model.ThoiGianThucHien,
                ["{{THOI_GIAN_BAO_HANH}}"] = model.ThoiGianBaoHanh,
                ["{{HINH_THUC_THANH_TOAN}}"] = model.HinhThucThanhToan,
                ["{{HIEU_LUC_HOP_DONG}}"] = model.HieuLucHopDong.ToString("dd/MM/yyyy"),
                ["{{DIEU_KHOAN_KHAC}}"] = model.DieuKhoanKhac
            };
        }
    }
}
