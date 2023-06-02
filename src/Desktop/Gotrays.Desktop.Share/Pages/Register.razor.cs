using Gotrays.Service.Contract.Users;

namespace Gotrays.Desktop.Share.Pages;

public partial class Register
{
    private bool _show;

    [Inject]
    public NavigationManager Navigation { get; set; } = default!;

    public CreateUserDto Dto { get; set; } = new()
    {
        Avatar = "https://blog-simple.oss-cn-shenzhen.aliyuncs.com/Avatar.jpg"
    };

    private async Task OnRegister()
    {
        try
        {
            if (Dto.Account.Length < 5)
            {
                await PopupService.EnqueueSnackbarAsync("账号长度最低5位", AlertTypes.Error);
            }

            if (Dto.Password.Length < 5)
            {
                await PopupService.EnqueueSnackbarAsync("密码长度最低5位", AlertTypes.Error);
            }

            await UserService.CreateAsync(Dto);
            await PopupService.EnqueueSnackbarAsync("注册成功", AlertTypes.Success);
        }
        catch (Exception e)
        {
            await PopupService.EnqueueSnackbarAsync("注册失败:" + e.Message, AlertTypes.Error);
        }
    }

    private void OnLogin()
    {
        Navigation.NavigateTo("/login");
    }
}
