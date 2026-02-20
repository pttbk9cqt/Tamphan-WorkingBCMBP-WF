using CefSharp;
using CefSharp.WinForms;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

public class FieldBindingManager
{
    private readonly ChromiumWebBrowser _browser;
    private readonly Panel _panel;
    private readonly Dictionary<string, ListBox> _fieldMap;

    public FieldBindingManager(
        ChromiumWebBrowser browser,
        Panel panel,
        Dictionary<string, ListBox> fieldMap)
    {
        _browser = browser;
        _panel = panel;
        _fieldMap = fieldMap;
    }

    // Inject JS lắng nghe focus (chỉ gọi 1 lần từ Form)
    public async Task InjectFocusListenerAsync()
    {
        string script = @"
            (function () {
                if (window._focusListenerInjected)
                    return;

                window._focusListenerInjected = true;
                window._lastFocusedField = null;
                CefSharp.BindObjectAsync('bridge').then(function () {
                    document.addEventListener('focusin', function (e) {

                        if (!e.target || !e.target.name)
                            return;

                        if (window._lastFocusedField === e.target.name)
                            return;

                        window._lastFocusedField = e.target.name;
                        bridge.fieldFocused(e.target.name);
                    });
                });
            })();
        ";
        await _browser.EvaluateScriptAsync(script);
    }

    // JS gọi về đây
    public void OnFieldFocused(string fieldName)
    {
        if (_panel.InvokeRequired)
        {
            _panel.Invoke(new Action(() => OnFieldFocused(fieldName)));
            return;
        }

        // Ẩn tất cả
        foreach (var listBox in _fieldMap.Values)
            listBox.Visible = false;
        // Hiện đúng cái cần
        if (_fieldMap.TryGetValue(fieldName, out var target))
        {
            target.Visible = true;
            target.BringToFront();
        }
    }
    // Bridge class
    public class JsBridge
    {
        private readonly FieldBindingManager _manager;
        public JsBridge(FieldBindingManager manager)
        {
            _manager = manager;
        }
        public void FieldFocused(string name)
        {
            _manager.OnFieldFocused(name);
        }
    }
}