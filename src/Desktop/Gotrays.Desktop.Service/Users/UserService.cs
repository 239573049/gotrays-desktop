
namespace Gotrays.Desktop.Service.Users;

public class UserService : BaseCaller, IUserService, ISingletonDependency
{
    private readonly ICaller _caller;
    private readonly IStorageService _storageService;
    public UserService(ICaller caller, IStorageService storageService)
    {
        _caller = caller;
        _storageService = storageService;
    }

    public async Task CreateAsync(CreateUserDto dto)
    {
        await _caller.PostAsync("users", dto);
    }

    public async Task<string> LoginAsync(string account, string password)
    {
        try
        {
            var response = await _caller.PostAsync("Users/Login?account=" + account + "&password=" + password, null);

            if (response.IsSuccessStatusCode)
            {
                var token = await response.Content.ReadAsStringAsync();

                _storageService.Token = token;

                return token;
            }

            throw new Exception("账号或密码错误");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}