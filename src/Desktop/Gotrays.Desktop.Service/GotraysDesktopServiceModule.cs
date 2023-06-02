using Gotrays.Desktop.Service.Middlewares;
using Microsoft.Extensions.DependencyInjection;

namespace Gotrays.Desktop.Service;

public class GotraysDesktopServiceModule : TokenModule
{
    public override void ConfigureServices(IServiceCollection services)
    {
        Func<IServiceProvider, IFreeSql> fsqlFactory = r =>
        {
            IFreeSql fsql = new FreeSql.FreeSqlBuilder()
                .UseConnectionString(FreeSql.DataType.Sqlite, @"Data Source=gotrays.db")
                .UseMonitorCommand(cmd => Console.WriteLine($"Sql：{cmd.CommandText}"))//监听SQL语句
                .UseAutoSyncStructure(true) //自动同步实体结构到数据库，FreeSql不会扫描程序集，只有CRUD时才会生成表。
                .Build();

            return fsql;
        };

        services.AddSingleton(fsqlFactory);

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