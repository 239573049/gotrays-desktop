using Gotrays.Service.Application.Chat.Queries;
using Masa.BuildingBlocks.Authentication.Identity;
using Microsoft.AspNetCore.SignalR;

namespace Gotrays.Service.Hubs;

public class ChatHub : Hub
{
    private readonly IUserContext _userContext;
    private readonly IEventBus _eventBus;

    public ChatHub(IUserContext userContext, IEventBus eventBus)
    {
        _userContext = userContext;
        _eventBus = eventBus;
    }

    public override async Task OnConnectedAsync()
    {
        var channelQuery = new UserChannelQuery(_userContext.GetUserId<Guid>(), null);
        await _eventBus.PublishAsync(channelQuery);

        // 加入群聊
        Clients.Groups(channelQuery.Result.Select(x => x.Id.ToString("N")));
    }

    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        var channelQuery = new UserChannelQuery(_userContext.GetUserId<Guid>(), null);
        await _eventBus.PublishAsync(channelQuery);

        // 退出群聊
        foreach (var s in channelQuery.Result.Select(x => x.Id.ToString("N")))
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, s);
        }
    }
}