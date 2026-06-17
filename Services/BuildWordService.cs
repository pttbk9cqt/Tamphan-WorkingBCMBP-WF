using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace Tamphan_WorkingBCMBP_WF.Services
{
    internal class BuildWordService
    {
        public static void Build(
            string templatePath,
            string outputPath,
            Dictionary<string, string> data)
        {
            var destDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrEmpty(destDir) && !Directory.Exists(destDir))
                Directory.CreateDirectory(destDir);

            if (!File.Exists(templatePath))
                throw new FileNotFoundException($"Template not found: {templatePath}", templatePath);

            // đổi tên nếu file đã tồn tại (KHÔNG xóa nữa)++
            outputPath = GetUniqueFilePath(outputPath);

            File.Copy(templatePath, outputPath);

            // retry mở file để tránh bị lock (Downloads)
            for (int i = 0; i < 5; i++)
            {
                try
                {
                    using (var doc = WordprocessingDocument.Open(outputPath, true))
                    {
                        ReplaceInPart(doc.MainDocumentPart, data);

                        foreach (var header in doc.MainDocumentPart.HeaderParts)
                            ReplaceInPart(header, data);

                        foreach (var footer in doc.MainDocumentPart.FooterParts)
                            ReplaceInPart(footer, data);
                    }
                    break;
                }
                catch (IOException)
                {
                    if (i == 4) throw;
                    Thread.Sleep(200);
                }
            }
        }

        // hàm tự tạo tên file không trùng
        private static string GetUniqueFilePath(string path)
        {
            if (!File.Exists(path))
                return path;

            string dir = Path.GetDirectoryName(path);
            string name = Path.GetFileNameWithoutExtension(path);
            string ext = Path.GetExtension(path);

            int i = 1;
            string newPath;

            do
            {
                newPath = Path.Combine(dir, $"{name} ({i}){ext}");
                i++;
            }
            while (File.Exists(newPath));

            return newPath;
        }

        private static void ReplaceInPart(OpenXmlPart part, Dictionary<string, string> data)
        {
            var textElements = part.RootElement.Descendants<Text>();

            foreach (var text in textElements)
            {
                foreach (var item in data)
                {
                    if (text.Text.Contains(item.Key))
                        text.Text = text.Text.Replace(item.Key, item.Value);
                }
            }
        }
    }
}