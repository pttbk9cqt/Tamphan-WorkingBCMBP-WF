using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tesseract;

namespace Tamphan_WorkingBCMBP_WF.Services
{
    public class CaptchaOcrService
    {
        private string _tessDataPath;

        // ===== B1: TIỀN XỬ LÝ ẢNH =====
        public Bitmap PreprocessCaptcha(Bitmap src)
        {
            Bitmap bmp = new Bitmap(src.Width, src.Height);

            for (int y = 0; y < src.Height; y++)
            {
                for (int x = 0; x < src.Width; x++)
                {
                    Color c = src.GetPixel(x, y);

                    // Lọc màu đỏ
                    bool isRed =
                        c.R > 120 &&
                        c.R > c.G * 1.3 &&
                        c.R > c.B * 1.3;

                    bmp.SetPixel(x, y, isRed ? Color.Black : Color.White);
                }
            }

            return bmp;
        }

        // ===== B2: OCR =====
        public string ReadCaptcha(Bitmap bitmap)
        {
            string result = "";

            using (var engine = new TesseractEngine(_tessDataPath, "eng",EngineMode.Default))
            {
                engine.SetVariable(
                    "tessedit_char_whitelist",
                    "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789");

                using (var pix = PixConverter.ToPix(bitmap))
                {
                    using (var page = engine.Process(pix))
                    {
                        result = page.GetText();
                    }
                }
            }

            return result.Trim();
        }


    }
}

