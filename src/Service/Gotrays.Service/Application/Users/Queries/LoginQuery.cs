namespace Gotrays.Service.Application.Users.Queries;

public record LoginQuery(string account,string password) : Query<string>
{
    public override string Result { get; set; }
}