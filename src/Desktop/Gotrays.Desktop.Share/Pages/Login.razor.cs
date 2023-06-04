namespace Gotrays.Desktop.Share.Pages;

public partial class Login
{
    private bool _show;

    [Inject] public NavigationManager Navigation { get; set; } = default!;

    private string? Account { get; set; }

    private string? Password { get; set; }

    private async Task OnLogin()
    {
        var token = await UserService.LoginAsync(Account, Password);
        Navigation.NavigateTo("/");
    }

    private void CreateAccount(MouseEventArgs obj)
    {
        Navigation.NavigateTo("/register");
    }
}