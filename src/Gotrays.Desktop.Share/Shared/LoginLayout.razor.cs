using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Components.Authorization;

namespace Gotrays.Desktop.Share.Shared;

public partial class LoginLayout
{
    private bool _show;

    [Inject] public NavigationManager Navigation { get; set; } = default!;

    [Inject] public AuthenticationStateProvider AuthenticationStateProvider { get; set; } = default!;

    [Parameter] public StringNumber? Elevation { get; set; }

    [Parameter] public string CreateAccountRoute { get; set; } = $"pages/authentication/register-v1";

    [Parameter] public string ForgotPasswordRoute { get; set; } = $"pages/authentication/forgot-password-v1";

    private string? Account { get; set; }

    private string? Password { get; set; }

    private async Task OnLogin()
    {
        var token = await UserService.LoginAsync(Account, Password);

        // 解密token
        var jwt = new JwtSecurityTokenHandler().ReadJwtToken(token);
        var claims = jwt.Claims;

        ((CustomAuthenticationStateProvider)AuthenticationStateProvider).AuthenticateUser(claims);
    }
}