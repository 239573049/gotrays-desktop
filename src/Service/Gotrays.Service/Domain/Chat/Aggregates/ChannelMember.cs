using Gotrays.Service.Domain.Users.Aggregates;
using Masa.BuildingBlocks.Ddd.Domain.Entities;

namespace Gotrays.Service.Domain.Chat.Aggregates;

public class ChannelMember : Entity<Guid>
{
    public ChannelMember()
    {
    }

    public ChannelMember(Guid id) : base(id)
    {
    }

    public Guid ChannelId { get; set; }

    public Guid UserId { get; set; }

    public virtual Channel Channel { get; set; }
    
    public virtual User User { get; set; }
}