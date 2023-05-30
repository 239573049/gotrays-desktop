using Microsoft.AspNetCore.Components.Web;

namespace Gotrays.Desktop.Share.Shared;
public partial class MainLayout
{
    private bool maximized = false;

    private bool _drawer;

    private bool start;

    private int x, y;

    private int i;

    private CancellationTokenSource cancellationToken;

    private void BottomRightOnMouseDown(MouseEventArgs args)
    {
        start = true;
        var (width, height) = SystemEvent.WindowSize?.Invoke() ?? (0, 0);
        x = width - (int)args.PageX;
        y = height - (int)args.PageY;
        cancellationToken = new CancellationTokenSource();
        i = 1;
        Task.Run((async () =>
        {
            while (cancellationToken.IsCancellationRequested == false)
            {
                if (i == 0)
                {
                    start = false;
                    cancellationToken.Cancel();
                    return;
                }
                i = 0;
                await Task.Delay(400);
            }
        }), cancellationToken.Token);
    }
    private void BottomRightOnMouseUp(MouseEventArgs args)
    {
        start = false;
    }

    private async Task BottomRightOnMouseMove(MouseEventArgs args)
    {
        if (!start) return;
        i = 1;
        SystemEvent.OnResize?.Invoke((int)(args.PageX + x), (int)(args.PageY + y));
        await Task.CompletedTask;
    }

    private static async Task OnClose()
    {
        Environment.Exit(0);
        await Task.CompletedTask;
    }

    private async Task OnMaximized()
    {
        maximized = !maximized;
        SystemEvent.OnMaximized?.Invoke(maximized);
        await Task.CompletedTask;
    }

    private async Task OnMinus()
    {
        maximized = !maximized;
        SystemEvent.OnMinimized?.Invoke();
        await Task.CompletedTask;
    }
}
