namespace Gotrays.Desktop.Share;

using Gotrays.Contracts.Users;
using Microsoft.AspNetCore.Components.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;

public class CustomAuthenticationStateProvider : AuthenticationStateProvider
{
    private readonly IStorageService _storageService;

    public CustomAuthenticationStateProvider(IStorageService storageService)
    {
        _storageService = storageService;

        // 用于监听Token变化从而更新界面变化
        _storageService.TokenChange = () =>
        {
            // 如果token是空的则情况消息返回到登录界面 如果不为空则登录成功
            if (string.IsNullOrEmpty(_storageService.Token))
            {
                User = null;

                var identity = new ClaimsIdentity();
                User = new ClaimsPrincipal(identity);

                NotifyAuthenticationStateChanged(
                    Task.FromResult(new AuthenticationState(User)));
            }
            else
            {

                // 解密token
                var jwt = new JwtSecurityTokenHandler().ReadJwtToken(_storageService.Token);
                var claims = jwt.Claims;
                AuthenticateUser(claims);
            }
        };
    }

    private ClaimsPrincipal? User { get; set; }

    public override Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        if (User != null)
        {
            return Task.FromResult(new AuthenticationState(User));
        }

        var identity = new ClaimsIdentity();
        User = new ClaimsPrincipal(identity);

        return Task.FromResult(new AuthenticationState(User));
    }

    public Guid UserId()
    {
        return new Guid(User?.Claims.FirstOrDefault(x => x.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Value);
    }

    public void AuthenticateUser(IEnumerable<Claim> _claims)
    {
        var identity = new ClaimsIdentity(_claims, "Gotrays");

        User = new ClaimsPrincipal(identity);

        NotifyAuthenticationStateChanged(
            Task.FromResult(new AuthenticationState(User)));
    }
}