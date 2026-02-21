using CefSharp;
using CefSharp.WinForms;
using System.Windows.Forms;

public static class DevToolsService
{
    public static void AttachDebugShortcut(Form form, ChromiumWebBrowser browser)
    {
        form.KeyPreview = true;

        form.KeyDown += (s, e) =>
        {
            if (e.Control && e.Shift && e.KeyCode == Keys.I)
            {
                OpenDevTools(browser);
            }
        };
    }

 
    public static void OpenDevTools(ChromiumWebBrowser browser)
    {
        if (browser != null && browser.IsBrowserInitialized)
        {
            browser.ShowDevTools();
        }
    }
}
