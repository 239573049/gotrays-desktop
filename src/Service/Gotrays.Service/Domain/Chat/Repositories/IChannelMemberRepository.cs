using Gotrays.Service.Domain.Chat.Aggregates;
using Masa.BuildingBlocks.Ddd.Domain.Repositories;

namespace Gotrays.Service.Domain.Chat.Repositories;

public interface IChannelMemberRepository : IRepository<ChannelMember,Guid>
{
    Task<List<ChannelMember>> GetListAsync(Guid channelId);
}