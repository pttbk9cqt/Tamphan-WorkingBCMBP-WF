using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tamphan_WorkingBCMBP_WF.Models
{
    internal class DataHopdong
    {
        // Thông tin chung
        public string TieuDe { get; set; }
        public string DuAn { get; set; }
        public string CongTrinh { get; set; }
        public string HangMuc { get; set; }
        public string DiaDiem { get; set; }

        // Nhà thầu
        public string DonViThiCong { get; set; }
        public string DiaChiDVTC { get; set; }
        public string SdtDVTC { get; set; }
        public string EmailDVTC { get; set; }
        public string MSTDVTC { get; set; }
        public string STKDVTC { get; set; }
        public string NguoiDaiDienDVTC { get; set; }
        public string ChucVuDVTC { get; set; }

        public decimal GiaTri { get; set; }
        public string LyDoChonNhaCungCap { get; set; }

        // Thời gian
        public string ThoiGianThucHien { get; set; }     // vd: "120 ngày"
        public string ThoiGianBaoHanh { get; set; }      // vd: "12 tháng"
        public DateTime HieuLucHopDong { get; set; }

        // Thanh toán & điều khoản
        public string HinhThucThanhToan { get; set; }
        public string DieuKhoanKhac { get; set; }

    }
}
