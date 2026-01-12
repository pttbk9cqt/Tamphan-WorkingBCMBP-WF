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
        }
    }
}
