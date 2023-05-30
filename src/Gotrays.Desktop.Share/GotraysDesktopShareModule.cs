using Gotrays.Desktop.Service.Contract;
using Microsoft.Extensions.DependencyInjection;
using Token.Attributes;

namespace Gotrays.Desktop.Share;

[DependOn(typeof(GotraysDesktopServiceContractModule))]
public class GotraysDesktopShareModule : TokenModule
{
    public override void ConfigureServices(IServiceCollection services)
    {
        services.AddMasaBlazor();
    }
}
