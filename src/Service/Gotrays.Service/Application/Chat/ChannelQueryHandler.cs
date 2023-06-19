using Gotrays.Service.Application.Chat.Queries;
using Gotrays.Service.Contract.Chat;
using Gotrays.Service.Domain.Chat.Repositories;

namespace Gotrays.Service.Application.Chat;

public class ChannelQueryHandler
{
    private readonly IChannelRepository _channelRepository;
    private readonly IChannelMemberRepository _channelMemberRepository;

    public ChannelQueryHandler(IChannelRepository channelRepository, IChannelMemberRepository channelMemberRepository)
    {
        _channelRepository = channelRepository;
        _channelMemberRepository = channelMemberRepository;
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

    [EventHandler]
    public async Task ChannelUsers(ChannelUsersQuery query)
    {
        var ids = await _channelMemberRepository.GetListAsync(query.channelId);

        query.Result = ids.Select(x => new UserDto()
        {
            Id = x.User.Id,
            Avatar = x.User.Avatar,
            Account = x.User.Account,
            UserName = x.User.UserName,
            Role = x.User.Role,
            IsDisable = x.User.IsDisable
        }).ToList();
    }
}