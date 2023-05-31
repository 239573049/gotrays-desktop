using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Gotrays.Desktop.Share;

[DependOn(typeof(GotraysDesktopServiceContractModule))]
public class GotraysDesktopShareModule : TokenModule
{
    public override void ConfigureServices(IServiceCollection services)
    {
        services.AddAuthorizationCore();
        services.TryAddSingleton<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
        services.TryAddSingleton<AuthenticationState>((services) =>
        {
            var provider = services.GetRequiredService<AuthenticationStateProvider>();
            return provider.GetAuthenticationStateAsync().GetAwaiter().GetResult();
        });
        services.AddMasaBlazor();
    }
}
