using Gotrays.Service.Domain.Users.Aggregates;
using Masa.BuildingBlocks.Ddd.Domain.Entities.Full;

namespace Gotrays.Service.Domain.Chat.Aggregates;

public class Channel : FullAggregateRoot<Guid, Guid?>
{
    protected Channel()
    {
    }

    public Channel(Guid id) : base(id)
    {
    }

    public string Name { get; set; }

    public string? Description { get; set; }

    public string? Avatar { get; set; }

    /// <summary>
    /// 创建人
    /// </summary>
    public Guid UserId { get; set; }

    public virtual User User { get; set; }
}