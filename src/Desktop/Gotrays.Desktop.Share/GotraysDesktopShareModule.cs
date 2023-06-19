using Gotrays.Desktop.Share.Modules;
using Gotrays.Service.Contract;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Gotrays.Desktop.Share;

[DependOn(typeof(GotraysServiceContractModule))]
public class GotraysDesktopShareModule : TokenModule
{
    public override void ConfigureServices(IServiceCollection services)
    {
        services.AddOptions();
        services.AddAuthorizationCore();
        services.AddScoped<DesktopModule>();
        services.TryAddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
        services.AddMasaBlazor();
    }
}
