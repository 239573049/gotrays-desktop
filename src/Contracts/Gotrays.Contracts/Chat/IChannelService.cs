namespace Gotrays.Service.Contract.Chat;

public interface IChannelService
{
    Task CreateAsync(CreateChannelDto dto);

    Task<List<ChannelDto>> GetListAsync(string? keywords);
}