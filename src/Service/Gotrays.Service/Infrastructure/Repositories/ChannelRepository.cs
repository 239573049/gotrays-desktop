using Gotrays.Service.Domain.Chat.Aggregates;
using Gotrays.Service.Domain.Chat.Repositories;
using Gotrays.Service.Infrastructure.EntityFrameworkCore;
using Masa.BuildingBlocks.Data.UoW;
using Masa.Contrib.Ddd.Domain.Repository.EFCore;

namespace Gotrays.Service.Infrastructure.Repositories;

public class ChannelRepository : Repository<GotraysDbContext,Channel,Guid>, IChannelRepository
{
    public ChannelRepository(GotraysDbContext context, IUnitOfWork unitOfWork) : base(context, unitOfWork)
    {
    }
}