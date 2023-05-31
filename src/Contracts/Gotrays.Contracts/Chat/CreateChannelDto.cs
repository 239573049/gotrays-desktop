namespace Gotrays.Service.Contract.Chat;

public class CreateChannelDto
{
    public string Name { get; set; }

    public string? Description { get; set; }

    public string? Avatar { get; set; }
}