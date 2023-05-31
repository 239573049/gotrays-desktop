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
}