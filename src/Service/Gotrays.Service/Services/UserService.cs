using Gotrays.Service.Application.Users.Queries;

namespace Gotrays.Service.Services;

public class UserService : BaseService<UserService>, IUserService
{
    public async Task CreateAsync(CreateUserDto dto)
    {
        var command = new CreateUserCommand(dto);
        await EventBus.PublishAsync(command);
    }

    public async Task<string> LoginAsync(string account, string password)
    {
        var query = new LoginQuery(account, password);
        await EventBus.PublishAsync(query);
        return query.Result;
    }

    public async Task<UserDto?> GetAsync(Guid? userId)
    {
        if (userId == null)
        {
            userId = UserContext.GetUserId<Guid>();
            if (userId == null)
            {
                throw new UnauthorizedAccessException("未登录");
            }
        }
        var query = new GetUserQuery((Guid)userId);
        await EventBus.PublishAsync(query);
        return query.Result;
    }
}