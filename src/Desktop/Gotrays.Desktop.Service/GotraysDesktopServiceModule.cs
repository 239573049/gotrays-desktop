using Gotrays.Desktop.Service.Middlewares;
using Microsoft.Extensions.DependencyInjection;

namespace Gotrays.Desktop.Service;

public class GotraysDesktopServiceModule : TokenModule
{
    public override void ConfigureServices(IServiceCollection services)
    {
        services.AddCaller(clientBuilder =>
        {
            clientBuilder.UseHttpClient(httpClient =>
            {
                httpClient.BaseAddress = "http://localhost:5126/"; //指定API服务域名地址
                httpClient.Prefix = "api/v1/";//指定API服务前缀
            }).AddMiddleware<GotraysMiddleware>();
        });



    }
}