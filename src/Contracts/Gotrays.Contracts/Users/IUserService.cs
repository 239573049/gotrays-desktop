namespace Gotrays.Service.Contract.Users;

public interface IUserService
{
    /// <summary>
    /// 注册
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    Task CreateAsync(CreateUserDto dto);

    /// <summary>
    /// 登录
    /// </summary>
    /// <param name="account"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    Task<string> LoginAsync(string account, string password);

    /// <summary>
    /// 获取用户详情
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    Task<UserDto?> GetAsync(Guid? userId);
}