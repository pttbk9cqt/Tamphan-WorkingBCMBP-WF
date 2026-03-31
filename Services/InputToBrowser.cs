using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CefSharp;
using CefSharp.WinForms;

namespace Tamphan_WorkingBCMBP_WF.Services
{
    public class InputToBrowser
    {
        private readonly ChromiumWebBrowser _browser;

        public InputToBrowser(ChromiumWebBrowser browser)
        {
            _browser = browser;
        }

        public async Task SetValue(string selector, string value)
        {
            await _browser.EvaluateScriptAsync($@"
        var el = document.querySelector('{selector}');
        if (el) {{
            el.value = '{Escape(value)}';
            el.dispatchEvent(new Event('input', {{ bubbles: true }}));
            el.dispatchEvent(new Event('change', {{ bubbles: true }}));
        }}
    ");
        }

        public async Task SetDate(string selector, DateTime date)
        {
            var jsDate = $"{date:MM/dd/yyyy}";

            await _browser.EvaluateScriptAsync($@"
        var el = document.querySelector('{selector}');
        if (el) {{
            el.value = '{jsDate}';
            el.dispatchEvent(new Event('input', {{ bubbles: true }}));
            el.dispatchEvent(new Event('change', {{ bubbles: true }}));
        }}
    ");
        }

        private string Escape(string input)
        {
            return input.Replace("\\", "\\\\").Replace("'", "\\'");
        }
    }
}
