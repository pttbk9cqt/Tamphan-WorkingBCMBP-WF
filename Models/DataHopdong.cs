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

        // Nhà cung cấp
        public string NCC { get; set; }
        public string DiaChiNCC { get; set; }
        public string SdtNCC { get; set; }
        public string EmailNCC { get; set; }
        public string MSTNCC { get; set; }
        public string STKNCC { get; set; }
        public string DaiDienNCC { get; set; }
        public string ChucVuNCC { get; set; }


        //Quyết định lựa chọn NCC
        public string CanCu { get; set; }
        public string NguyenNhanTrinhKy { get; set; }


        // Nội dung hợp đồng

        public string GiaTri { get; set; }
        public string LyDoChonNCC { get; set; }
        public string ThoiGianThucHien { get; set; }     // vd: "120 ngày"
        public string TienDoVaThoiGianThanhToan { get; set; }
        public string ThoiGianBaoHanh { get; set; }      // vd: "12 tháng"
        public string HieuLucHopDong { get; set; }

    }
}
