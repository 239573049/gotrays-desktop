
using Gotrays.Service.Contract.Base;
using System.Net.Http.Json;

namespace Gotrays.Desktop.Service.Users;

public class UserService : BaseCaller, IUserService, IScopedDependency
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
        var response = await _caller.PostAsync("Users", dto);

        if (response.IsSuccessStatusCode)
        {
            return;
        }
        throw new Exception((await response.Content.ReadFromJsonAsync<AbnormalDto>()).Message);
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

    public Task<UserDto?> GetAsync(Guid? userId)
    {
        return _caller.GetAsync<UserDto>("Users", userId);
    }
}