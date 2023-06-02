namespace Gotrays.Service.Application.Users.Queries;

public record GetUserQuery(Guid userId):Query<UserDto>
{
    public override UserDto Result { get; set; }
}