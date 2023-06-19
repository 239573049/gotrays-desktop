using Gotrays.Service.Domain.Chat.Aggregates;
using Gotrays.Service.Domain.Chat.Repositories;
using Gotrays.Service.Infrastructure.EntityFrameworkCore;
using Masa.BuildingBlocks.Data.UoW;
using Masa.Contrib.Ddd.Domain.Repository.EFCore;

namespace Gotrays.Service.Infrastructure.Repositories;

public class ChannelMemberRepository : Repository<GotraysDbContext, ChannelMember, Guid>, IChannelMemberRepository
{
    public ChannelMemberRepository(GotraysDbContext context, IUnitOfWork unitOfWork) : base(context, unitOfWork)
    {
    }

    public async Task<List<ChannelMember>> GetListAsync(Guid channelId)
    {
        var query =
            await Context.ChannelMembers
                .Where(x => x.ChannelId == channelId)
                .Include(x => x.User)
                .ToListAsync();

        return query;
    }
}