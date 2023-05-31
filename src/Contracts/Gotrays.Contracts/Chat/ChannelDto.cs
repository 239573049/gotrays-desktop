namespace Gotrays.Service.Contract.Chat;

public class ChannelDto
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string? Description { get; set; }

    public string? Avatar { get; set; }

    /// <summary>
    /// 创建人
    /// </summary>
    public Guid UserId { get; set; }

    public DateTime CreationTime { get; set; }
}