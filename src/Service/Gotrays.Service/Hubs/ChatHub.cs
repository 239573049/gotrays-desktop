using Gotrays.Service.Application.Chat.Queries;
using Gotrays.Service.Contract.Chat;
using Masa.BuildingBlocks.Authentication.Identity;
using Microsoft.AspNetCore.SignalR;
using System.Text.Json;

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
        foreach (var item in channelQuery.Result.Select(x => x.Id.ToString("N")))
        {
            // 添加到指定群聊
            await Groups.AddToGroupAsync(Context.ConnectionId, item);
            _ = Clients.Group(item);
        }
    }

    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        var channelQuery = new UserChannelQuery(_userContext.GetUserId<Guid>(), null);
        await _eventBus.PublishAsync(channelQuery);

        foreach (var item in channelQuery.Result.Select(x => x.Id.ToString("N")))
        {
            // 退出群聊
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, item);
        }
    }

    [HubMethodName("SendChannel")]
    public async Task SendChannelAsync(ChannelMessageDto dto)
    {
        await Clients.Group(dto.ChannelId.ToString("N")).SendAsync("channel", dto);
    }
}