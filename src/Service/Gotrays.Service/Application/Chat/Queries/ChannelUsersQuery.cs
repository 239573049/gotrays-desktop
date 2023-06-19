namespace Gotrays.Service.Application.Chat.Queries;

public record ChannelUsersQuery(Guid channelId) : Query<List<UserDto>>
{
    public override List<UserDto> Result { get; set; }
}