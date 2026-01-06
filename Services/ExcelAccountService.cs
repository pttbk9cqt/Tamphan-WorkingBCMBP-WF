using System;
using System.IO;
using ClosedXML.Excel;
using Tamphan_WorkingBCMBP_WF.Models;

namespace Tamphan_WorkingBCMBP_WF.Services
{
    internal class ExcelAccountService
    {
        private const string ExcelPath = "AccountEVN-addWF.xlsm";

        public AccountEVN GetAccount(string maKH)
        {
            if (!File.Exists(ExcelPath))
                return null;

            using (var wb = new XLWorkbook(ExcelPath))
            {
                var ws = wb.Worksheet(1);

                for (int row = 2; row <= 1000; row++)
                {
                    string maKHExcel = ws.Cell(row, "C").GetString().Trim();

                    if (maKHExcel == maKH)
                    {
                        return new AccountEVN
                        {
                            Id = ws.Cell(row, "A").GetString(),
                            MaKH = maKHExcel,
                            MucDichSuDung = ws.Cell(row, "D").GetString(),
                            Password = ws.Cell(row, "M").GetString()
                        };
                    }
                }
            }

            return null;
        }
    }
}
