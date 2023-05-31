using Gotrays.Service.Application.Chat.Queries;
using Gotrays.Service.Contract.Chat;
using Gotrays.Service.Domain.Chat.Repositories;

namespace Gotrays.Service.Application.Chat;

public class ChannelQueryHandler
{
    private readonly IChannelRepository _channelRepository;

    public ChannelQueryHandler(IChannelRepository channelRepository)
    {
        _channelRepository = channelRepository;
    }

    [EventHandler]
    public async Task UserChannel(UserChannelQuery query)
    {
        var result = await _channelRepository.GetListAsync(x =>
            x.UserId == query.userId && (string.IsNullOrEmpty(query.keywords) || x.Name.Contains(query.keywords)));

        query.Result = result.Select(x => new ChannelDto()
        {
            Avatar = x.Avatar,
            CreationTime = x.CreationTime,
            Description = x.Description,
            Id = x.Id,
            Name = x.Name,
            UserId = x.UserId
        }).ToList();
        
    }
}