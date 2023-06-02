using Gotrays.Desktop.Client;
using Microsoft.Extensions.DependencyInjection;
using Photino.Blazor;
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

}