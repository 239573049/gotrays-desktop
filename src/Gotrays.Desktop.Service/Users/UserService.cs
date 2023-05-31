using Gotrays.Service.Contract.Users;
using Masa.BuildingBlocks.Service.Caller;
using Token.Dependency;

namespace Gotrays.Desktop.Service.Users;

public class UserService : BaseCaller, IUserService, ISingletonDependency
{
    private readonly ICaller _caller;

    public UserService(ICaller caller)
    {
        _caller = caller;
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
                return await response.Content.ReadAsStringAsync();
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