using Gotrays.Service.Application.Users.Queries;
using Gotrays.Service.Contract.Jwt;
using Gotrays.Service.Domain.Users.Repositories;
using Gotrays.Service.Infrastructure.Helpers;
using Microsoft.Extensions.Options;

namespace Gotrays.Service.Application.Users;

public class UserQueryHandler
{
    private readonly IUserRepository _userRepository;
    private readonly JwtOptions _jwtOptions;

    public UserQueryHandler(IUserRepository userRepository, IOptions<JwtOptions> jwtOptions)
    {
        _userRepository = userRepository;
        _jwtOptions = jwtOptions.Value;
    }

    [EventHandler]
    public async Task LoginHandleAsync(LoginQuery query)
    {
        var user = await _userRepository.FindAsync(x => x.Account == query.account);

        if (user == null)
        {
            throw new UserFriendlyException("账号或密码错误");
        }

        if (user.Password != Md5Helper.HashPassword(query.password, user.Salt))
        {
            throw new UserFriendlyException("账号或密码错误");
        }


        var userDto = new UserDto()
        {
            Id = user.Id,
            Account = user.Account,
            Avatar = user.Avatar,
            IsDisable = user.IsDisable,
            LastLoginTime = user.LastLoginTime,
            UserName = user.UserName,
            Role = user.Role
        };

        var claimsIdentity = JwtHelper.GetClaimsIdentity(userDto);

        var token = JwtHelper.GeneratorAccessToken(claimsIdentity, _jwtOptions);

        query.Result = token;
    }

    [EventHandler]
    public async Task GetUserAsync(GetUserQuery query)
    {
        var user = await _userRepository.FindAsync(x => x.Id == query.userId);

        if (user == null)
        {
            throw new UserFriendlyException("用户不存在");
        }

        query.Result = new UserDto()
        {
            Id = user.Id,
            Account = user.Account,
            Avatar = user.Avatar,
            IsDisable = user.IsDisable,
            LastLoginTime = user.LastLoginTime,
            UserName = user.UserName,
            Role = user.Role,
        };
    }
}