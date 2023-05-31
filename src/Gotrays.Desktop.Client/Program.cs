using Gotrays.Desktop.Client;
using Gotrays.Desktop.Share.Shared;
using Microsoft.Extensions.DependencyInjection;
using Photino.Blazor;
using PhotinoNET;
using System.Drawing;
using System.Text.Json;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.DependencyInjection.Extensions;
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
            .SetChromeless(false)
            .SetIconFile("logo.ico")
            .SetUseOsDefaultSize(true)
            .SetDevToolsEnabled(true)
            .SetTitle("Gotrays Desktop");
        
        AppDomain.CurrentDomain.UnhandledException += (sender, error) =>
        {
            app.MainWindow.OpenAlertWindow("Fatal exception", error.ExceptionObject.ToString());
        };

        app.Run();
    }
    
    public class Message
    {
        public string Command { get; set; }

        public double X { get; set; }

        public double Y { get; set; }
    }
}