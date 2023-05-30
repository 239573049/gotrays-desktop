namespace Gotrays.Desktop.Share;

[DependOn(typeof(GotraysDesktopServiceContractModule))]
public class GotraysDesktopShareModule : TokenModule
{
    public override void ConfigureServices(IServiceCollection services)
    {
        services.AddMasaBlazor();
    }
}
