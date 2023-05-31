using Gotrays.Service.Application.Chat.Commands;
using Gotrays.Service.Application.Chat.Queries;
using Gotrays.Service.Contract.Chat;

namespace Gotrays.Service.Services;

public class ChannelService : BaseService<ChannelService>, IChannelService
{
    public async Task CreateAsync(CreateChannelDto dto)
    {
        var command = new CreateChannelCommand(dto);
        await EventBus.PublishAsync(command);
    }

    public async Task<List<ChannelDto>> GetListAsync(string? keywords)
    {
        var query = new UserChannelQuery(UserContext.GetUserId<Guid>(), keywords);
        await EventBus.PublishAsync(query);
        return query.Result;
    }
}