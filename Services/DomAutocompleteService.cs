using CefSharp;
using CefSharp.WinForms;
using Newtonsoft.Json;
using System.Collections.Generic;

public class DomAutocompleteService
{
    private readonly ChromiumWebBrowser _browser;
    private readonly ExcelSuggestionEof _excelService;

    public DomAutocompleteService(
        ChromiumWebBrowser browser,
        ExcelSuggestionEof excelService)
    {
        _browser = browser;
        _excelService = excelService;
    }

    public void HandleFieldFocused(string fieldName)
    {
        var suggestions = _excelService.GetSuggestions(fieldName);
        InjectAutocomplete(fieldName, suggestions);
    }

    private void InjectAutocomplete(string fieldName, List<string> suggestions)
    {
        var json = JsonConvert.SerializeObject(suggestions);

        var script =
            "window.injectAutocomplete('" + fieldName + "', " + json + ");";

        _browser.ExecuteScriptAsync(script);
    }
}
