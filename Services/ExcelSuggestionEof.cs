using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

public class ExcelSuggestionEof
{
    private readonly string _filePath;

    // Cache: Sheet_Column => List<string>
    private readonly Dictionary<string, List<string>> _cache
        = new Dictionary<string, List<string>>();

    public ExcelSuggestionEof()
    {
        _filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Data\SuggestEofWF.xlsm");
    }
    public ExcelSuggestionEof(string filePath)
    {
        _filePath = filePath;
    }

    public Task<List<string>> GetSuggestionsAsync(
        string sheetName,
        string columnLetter,
        string keyword)
    {
        string cacheKey = sheetName + "_" + columnLetter.ToUpper();

        if (!_cache.ContainsKey(cacheKey))
        {
            LoadSheetColumn(sheetName, columnLetter.ToUpper());
        }

        if (!_cache.ContainsKey(cacheKey))
        {
            return Task.FromResult(new List<string>());
        }

        List<string> result = _cache[cacheKey]
            .Where(x => string.IsNullOrEmpty(keyword)
                || x.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0)
            .Take(20)
            .ToList();

        return Task.FromResult(result);
    }

    private void LoadSheetColumn(string sheetName, string columnLetter)
    {
        string cacheKey = sheetName + "_" + columnLetter;

        List<string> list = new List<string>();

        using (SpreadsheetDocument document =
            SpreadsheetDocument.Open(_filePath, false))
        {
            WorkbookPart workbookPart = document.WorkbookPart;

            Sheet sheet = workbookPart.Workbook.Sheets
                .Cast<Sheet>()
                .FirstOrDefault(s => s.Name == sheetName);

            if (sheet == null)
                return;

            WorksheetPart worksheetPart =
                (WorksheetPart)workbookPart.GetPartById(sheet.Id);

            SheetData sheetData =
                worksheetPart.Worksheet.GetFirstChild<SheetData>();

            foreach (Row row in sheetData.Elements<Row>())
            {
                Cell targetCell = row.Elements<Cell>()
                    .FirstOrDefault(c =>
                        GetColumnLetter(c.CellReference) == columnLetter);

                if (targetCell == null)
                    continue;

                string value = GetCellValue(document, targetCell);

                if (!string.IsNullOrWhiteSpace(value))
                {
                    list.Add(value.Trim());
                }
            }
        }

        _cache[cacheKey] = list
            .Distinct()
            .ToList();
    }

    private string GetColumnLetter(StringValue cellReference)
    {
        if (cellReference == null)
            return string.Empty;

        string reference = cellReference.Value;

        return new string(reference
            .Where(char.IsLetter)
            .ToArray());
    }

    private string GetCellValue(SpreadsheetDocument doc, Cell cell)
    {
        if (cell.CellValue == null)
            return null;

        string value = cell.CellValue.InnerText;

        if (cell.DataType != null &&
            cell.DataType == CellValues.SharedString)
        {
            SharedStringTablePart stringTablePart =
                doc.WorkbookPart.SharedStringTablePart;

            if (stringTablePart != null)
            {
                return stringTablePart.SharedStringTable
                    .ElementAt(int.Parse(value))
                    .InnerText;
            }
        }

        return value;
    }

    internal List<string> GetSuggestions(string fieldName)
    {
        throw new NotImplementedException();
    }
}