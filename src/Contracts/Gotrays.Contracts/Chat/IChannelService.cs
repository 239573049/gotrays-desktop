using Gotrays.Service.Contract.Users;

namespace Gotrays.Service.Contract.Chat;

public interface IChannelService
{
    Task CreateAsync(CreateChannelDto dto);

    Task<List<ChannelDto>> GetListAsync(string? keywords);
    
    /// <summary>
    /// 获取频道用户
    /// </summary>
    /// <param name="channelId"></param>
    /// <returns></returns>
    Task<List<UserDto>> GetChannelUsersAsync(Guid channelId);
}