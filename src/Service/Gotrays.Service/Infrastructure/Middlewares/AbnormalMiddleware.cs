using Gotrays.Service.Contract.Base;

namespace Gotrays.Service.Infrastructure.Middlewares;

public class AbnormalMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (UserFriendlyException exception)
        {
            context.Response.StatusCode = 400;
            await context.Response.WriteAsJsonAsync(new AbnormalDto
            {
                Message = exception.Message,
                Code = "400"
            });
        }
        catch (UnauthorizedAccessException)
        {
            context.Response.StatusCode = 401;
        }
        catch (Exception e)
        {
            context.Response.StatusCode = 500;
            await context.Response.WriteAsJsonAsync(new AbnormalDto
            {
                Message = "服务器发生异常",
                Code = "500"
            });
        }

    }
}