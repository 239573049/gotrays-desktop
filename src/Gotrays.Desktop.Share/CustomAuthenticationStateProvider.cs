using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace Gotrays.Desktop.Share;

using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Authorization;

public class CustomAuthenticationStateProvider : AuthenticationStateProvider
{
    private ClaimsPrincipal User { get; set; }

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

    public void AuthenticateUser(IEnumerable<Claim> _claims)
    {
        var identity = new ClaimsIdentity(_claims, "Gotrays");

        User = new ClaimsPrincipal(identity);

        NotifyAuthenticationStateChanged(
            Task.FromResult(new AuthenticationState(User)));
    }
}