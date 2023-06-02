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
        services.TryAddSingleton<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
        services.AddMasaBlazor();
    }
}
