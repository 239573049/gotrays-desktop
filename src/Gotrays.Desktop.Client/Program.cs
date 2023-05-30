using Gotrays.Desktop.Client;
using Gotrays.Desktop.Share.Shared;
using Microsoft.Extensions.DependencyInjection;
using Photino.Blazor;
using PhotinoNET;
using System.Drawing;
using System.Text.Json;
using Token.Extensions;

internal class Program
{
    [STAThread]
    private static void Main(string[] args)
    {
        var builder = PhotinoBlazorAppBuilder.CreateDefault(args);

        builder.RootComponents.Add<App>("#app");

        builder.Services.AddModuleApplicationAsync<GotraysDesktopClientModule>().GetAwaiter().GetResult();
        builder.Services.AddLogging();

        var app = builder.Build();

        app.MainWindow
            .SetChromeless(true)
            .SetContextMenuEnabled(true)
            .SetUseOsDefaultSize(true)
            .SetDevToolsEnabled(true)
            .RegisterWebMessageReceivedHandler(MessageReceived)
            .SetTitle("Gotrays Desktop");

        SystemEvent.WindowSize += () => (app.MainWindow.Width, app.MainWindow.Height);

        SystemEvent.OnResize += (width, height) =>
            app.MainWindow.Size = new Size(width, height);

        SystemEvent.OnMaximized += (maximized) =>
            app.MainWindow.Maximized = maximized;

        SystemEvent.OnMinimized += () =>
            app.MainWindow.Minimized = true;

        AppDomain.CurrentDomain.UnhandledException += (sender, error) =>
            { app.MainWindow.OpenAlertWindow("Fatal exception", error.ExceptionObject.ToString()); };

        app.Run();
    }


    private static void MessageReceived(object? sender, string message)
    {
        if (!message.StartsWith("{")) return;

        var window = sender as PhotinoWindow;
        var data = JsonSerializer.Deserialize<Message>(message);

        if (data == null) return;

        switch (data.Command)
        {
            case "MouseMove":
            {
                var left = window.Left + data.X;
                var top = window.Top + data.Y;
                if (left <= -window.Width / 2)
                {
                    left = -window.Width / 2;
                }

                if (window.Top < 0)
                {
                    window.Top = 0;
                }

                window.SetLeft((int)left);
                window.SetTop((int)top);
                break;
            }
        }

    }

    public class Message
    {
        public string Command { get; set; }

        public double X { get; set; }

        public double Y { get; set; }
    }
}