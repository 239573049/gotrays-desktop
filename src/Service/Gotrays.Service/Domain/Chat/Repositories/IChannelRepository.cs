using Gotrays.Service.Domain.Chat.Aggregates;
using Masa.BuildingBlocks.Ddd.Domain.Repositories;

namespace Gotrays.Service.Domain.Chat.Repositories;

public interface IChannelRepository : IRepository<Channel, Guid>
{

}