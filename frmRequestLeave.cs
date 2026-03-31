using CefSharp;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tamphan_WorkingBCMBP_WF
{
    public partial class frmRequestLeave : Form
    {
        public string username;
        public string password;
        public string url;
        //////////////////////////////////////////////
        public frmRequestLeave(string usernamehome, string passwordhome, string urlhome)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            username = usernamehome;
            password = passwordhome;
            url = urlhome;
            InitBrowser();
        }
        //////////////////////////////////////////////
        private void InitBrowser()
        {
            chromiumrequestleave.FrameLoadEnd += Browser_FrameLoadEnd;
            chromiumrequestleave.Load(url);
        }
        //////////////////////////////////////////////
        private async void Browser_FrameLoadEnd(object sender, FrameLoadEndEventArgs e)
        {
            await AutoLogin(username, password);
        }
        //////////////////////////////////////////////
        private async Task AutoLogin(string username, string password)
        {
            string logininfo = $@"
            (function() 
            {{
                let userInput = document.querySelector('input[placeholder=""Tên người dùng""]');
                let passInput = document.querySelector('input[placeholder=""Mật khẩu""]');
                if (userInput && passInput) 
                {{
                    userInput.value = '{username}';
                    userInput.dispatchEvent(new Event('input', {{ bubbles: true }}));
                    passInput.value = '{password}';
                    passInput.dispatchEvent(new Event('input', {{ bubbles: true }}));
                }}
            }})();";
            chromiumrequestleave.ExecuteScriptAsync(logininfo);// điền username và pass
            chromiumrequestleave.ExecuteScriptAsync(@"const checkbox = document.querySelector('#kmsiInput'); checkbox && !checkbox.checked && checkbox.click();"); //tick vào checkbox
            chromiumrequestleave.ExecuteScriptAsync("document.getElementById('submitButton').click();"); // bấm nút đăng nhập
            await FillInfo();
        }

        // =================================================
        //     hàm thực thi điền thông tin vào frm xin nghỉ phép
        // =================================================
        private async Task FillInfo( )
        { //element sau khi copy từ web như sau: <input id="bba79813-a7aa-4767-b603-91bb8cf82454" type="Text" maxlength="255" class="TieuDe k-valid" value="[TÊN PHÒNG VIẾT TẮT] - HỌ VÀ TÊN; CHỨC VỤ; XIN NGHỈ PHÉP ... NGÀY ĐỂ ..." name="Tiêu đề" data-required-msg="'{0}' is required." required="required" data-maxlength-msg="'{0}' chỉ có thể nhập tối đa 255 kí tự." data-maxlength="255" style="display: inline-block;">
          // Note: thứ tự ưu tiên là bắt vào id , nếu id không có thì bắt vào name, nếu name cũng không được thì bắt vào class, nếu class cũng không có thì bắt vào placeholder, như vậy sẽ đảm bảo được độ chính xác khi thao tác với element
          //ưu tiên 1: bắt vào id như sau:
          //await chromiumrequestleave.EvaluateScriptAsync(@"document.getElementById('bba79813-a7aa-4767-b603-91bb8cf82454').value = 'NỘI DUNG CỦA BẠN';");
          //nhưng mà id mỗi lần load nó sẽ đổi, nên mình không dùng
          //ưu tiên 2: bắt vào name như sau:
          //await chromiumrequestleave.EvaluateScriptAsync(@"document.getElementsByName('Tiêu đề')[0].value = 'NỘI DUNG CỦA BẠN';"); phải thêm [0].value bởi vì không giống như getElementById trả về giá trị, thì getElementsByName LUÔN trả về danh sách (array-like), dù chỉ có 1 element, nên mình phải thêm [0].value vào mới đúng
          //một cách bắt vào name khác nhưng không dùng [0] là 
          //await chromiumrequestleave.EvaluateScriptAsync(@"document.querySelector('[name=""Tiêu đề""]').value = 'NỘI DUNG CỦA BẠN';");
          //ưu tiên 3: bắt vào class như sau:
          //await chromiumrequestleave.EvaluateScriptAsync(@"document.querySelector('.TieuDe').value = 'NỘI DUNG CỦA BẠN';");
          /* lưu ý do class có thể có nhiều element cùng tên class nên mình phải dùng querySelector để nó bắt vào đúng element đầu tiên có class là TieuDe, nếu dùng getElementsByClassName thì nó sẽ trả về 1 danh sách (array-like) các element có cùng class, như vậy sẽ không thao tác được trực tiếp mà phải thêm [0] vào sau để lấy phần tử đầu tiên trong danh sách đó, nhưng như vậy sẽ không đảm bảo được độ chính xác nếu có nhiều element cùng class, nên mình ưu tiên dùng querySelector hơn
          - một lưu ý nữa là khi dùng querySelector để bắt vào class thì mình phải thêm dấu chấm (.) vào trước tên class, nếu không sẽ không bắt được element nào, còn khi dùng getElementsByClassName thì không cần thêm dấu chấm, nếu thêm dấu chấm vào trước tên class khi dùng getElementsByClassName thì sẽ không bắt được element nào
          - do là querySelector() dùng CSS selector, nên: cú pháp .abc thì nghĩa là class = abc, cú pháp #abc thì nghĩa là id = abc, cú pháp [name="abc"] thì nghĩa là name = abc, cú pháp input[value^="abc"] thì nghĩa là thẻ input có thuộc tính value bắt đầu bằng abc, cú pháp input[value$="abc"] thì nghĩa là thẻ input có thuộc tính value kết thúc bằng abc, cú pháp input[value*="abc"] thì nghĩa là thẻ input có thuộc tính value chứa abc ở bất kỳ vị trí nào
          - như vậy do class là class="TieuDe k-valid" nên nếu chính xác 100% thì mình bắt vào mình bắt vào .TieuDe.k-valid luôn, nhưng trường hợp nó có thay đổi thì mình sẽ bị sai, và phải edit lại code, nên là .TieuDe là được rồi, để chống sự thay đổi */
          //ưu tiên 4: bắt vào placeholder như sau:
          //await chromiumrequestleave.EvaluateScriptAsync(@"document.querySelector('input[value^=""[TÊN PHÒNG""]').value = 'NỘI DUNG tamphan';");

            // dùng bắt vào name
            await chromiumrequestleave.EvaluateScriptAsync(@"document.querySelector('[name=""Tiêu đề""]').value = '[P.SXKD] - PHAN THÀNH TÂM; NV P.SXKD; XIN NGHỈ PHÉP 01 NGÀY ĐỂ GIẢI QUYẾT CÔNG VIỆC CÁ NHÂN';");
            await Task.Delay(500);
            //await chromiumrequestleave.EvaluateScriptAsync(@"document.querySelector('[name=""Kính gửi:""]').value = 'Nội dung mới';");
            //await chromiumrequestleave.EvaluateScriptAsync(@"
            //                                                (function () {
            //                                                    const el = document.querySelector('[name=""Kính gửi:""]');
            //                                                    if (!el) return;

            //                                                    el.value = `- Tổng Giám đốc
            //                                                - Phòng Tổ chức Hành chính;
            //                                                - Phòng Sản xuất Kinh doanh (Quản lý trực tiếp).`;

            //                                                    el.dispatchEvent(new Event('input', { bubbles: true }));
            //                                                    el.dispatchEvent(new Event('change', { bubbles: true }));
            //                                                })();
            //                                                ");

            await chromiumrequestleave.EvaluateScriptAsync(@"
                                                            var el = document.querySelector('[name=""Kính gửi:""]');
                                                            if (el) {
                                                                el.value = '- Tổng Giám đốc\n- Phòng Tổ chức Hành chính;\n- Phòng Sản xuất Kinh doanh (Quản lý trực tiếp).';
                                                                el.dispatchEvent(new Event('input', { bubbles: true }));
                                                                el.dispatchEvent(new Event('change', { bubbles: true }));
                                                            }
                                                            ");
        }
    }
}
