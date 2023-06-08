using BlazorComponent.JSInterop;

namespace Gotrays.Desktop.Share.Modules;

public class DesktopModule : JSModule
{
    public DesktopModule(IJSRuntime js) : base(js, "/_content/Gotrays.Desktop.Share/js/desktop.js")
    {
    }

    /// <summary>
    /// 点击指定dom
    /// </summary>
    /// <param name="id"></param>
    public async ValueTask Click(string id)
    {
        await InvokeVoidAsync("click", id);
    }
}