using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

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

            File.Copy(templatePath, outputPath, true);

            using (var doc = WordprocessingDocument.Open(outputPath, true))
            {
                ReplaceInPart(doc.MainDocumentPart, data);

                foreach (var header in doc.MainDocumentPart.HeaderParts)
                    ReplaceInPart(header, data);

                foreach (var footer in doc.MainDocumentPart.FooterParts)
                    ReplaceInPart(footer, data);
            }
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
