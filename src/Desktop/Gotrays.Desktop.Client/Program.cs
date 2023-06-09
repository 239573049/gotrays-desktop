using Gotrays.Desktop.Client;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Photino.Blazor;
using Token.Extensions;

internal class Program
{
    [STAThread]
    private static void Main(string[] args)
    {
        var configuration =
            new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();


        var builder = PhotinoBlazorAppBuilder.CreateDefault(args);

        builder.RootComponents.Add<App>("#app");
        
        builder.Services.AddScoped((_) => configuration);

        builder.Services.AddModuleApplicationAsync<GotraysDesktopClientModule>().GetAwaiter().GetResult();
        builder.Services.AddLogging();

        var app = builder.Build();

        app.MainWindow
            .SetChromeless(false)
            .SetIconFile("logo.ico")
            .SetUseOsDefaultSize(false)
            .SetSize(1200,800)
            .SetDevToolsEnabled(true)
            .SetTitle("Gotrays Desktop");

        AppDomain.CurrentDomain.UnhandledException += (sender, error) =>
        {
            app.MainWindow.OpenAlertWindow("Fatal exception", error.ExceptionObject.ToString());
        };

        app.Run();
    }

}