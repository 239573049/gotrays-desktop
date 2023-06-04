﻿using Gotrays.Service.Contract.Chat;

namespace Gotrays.Desktop.Service.Chat;

public class ChannelService : BaseCaller, IChannelService, ISingletonDependency
{
    private readonly ICaller _caller;

    public ChannelService(ICaller caller)
    {
        _caller = caller;
    }

    public async Task CreateAsync(CreateChannelDto dto)
    {
        await _caller.PostAsync("Channels", dto);
    }

    public async Task<List<ChannelDto>> GetListAsync(string? keywords)
    {
        return await _caller.GetAsync<List<ChannelDto>>("Channels/List?keywords=" + keywords);
    }
}