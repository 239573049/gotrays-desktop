using Gotrays.Service.Contract.Chat;

namespace Gotrays.Service.Application.Chat.Queries;

public record UserChannelQuery(Guid userId,string? keywords) : Query<List<ChannelDto>>()
{
    public override List<ChannelDto> Result { get; set; }
}