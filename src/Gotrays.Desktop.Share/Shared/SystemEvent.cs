namespace Gotrays.Desktop.Share.Shared;

public class SystemEvent
{
    public static Action<int, int>? OnResize { get; set; }

    public static Func<(int, int)>? WindowSize { get; set; }

    /// <summary>
    /// 全屏事件
    /// </summary>
    public static Action<bool>? OnMaximized { get; set; }

    /// <summary>
    /// 最小化事件
    /// </summary>
    public static Action? OnMinimized { get; set; }
    
}