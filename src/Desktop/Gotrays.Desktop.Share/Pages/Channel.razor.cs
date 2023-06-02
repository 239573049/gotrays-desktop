using Gotrays.Desktop.Share.Shared;
using Microsoft.AspNetCore.SignalR.Client;

namespace Gotrays.Desktop.Share.Pages
{
    public partial class Channel
    {
        [CascadingParameter(Name = nameof(ChannelDto))]
        public ChannelDto ChannelDto { get; set; }

        private List<ChannelMessageDto> _channels = new();

        [Parameter]
        [CascadingParameter(Name = nameof(MainLayout))]
        public MainLayout MainLayout { get; set; }

        private string? Message;

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                _channels = await StorageService.GetListAsync(ChannelDto.Id) ?? new List<ChannelMessageDto>();
                StateHasChanged();
            }
        }

        private async Task SendMessage(KeyboardEventArgs obj)
        {
            if (string.IsNullOrEmpty(Message))
            {
                return;
            }

            if (obj.ShiftKey && obj.Key == "Enter")
            {
                Message += "\n";
                return;
            }

            if (obj.Key == "Enter")
            {
                var user = ((CustomAuthenticationStateProvider)AuthenticationStateProvider).UserId();
                var message = new ChannelMessageDto()
                {
                    Id = Guid.NewGuid(),
                    TheirUserId = user,
                    ChannelId = ChannelDto.Id,
                    CreatedTime = DateTime.Now,
                    Message = Message,
                    Type = MessageType.Message
                };
                _channels.Add(message);

                // 发送消息至服务器
                await MainLayout.Connection.SendAsync("SendChannel", message);

                // 存储消息
                await StorageService.AddChatMessage(message);

                Message = string.Empty;

                await Task.CompletedTask;
            }
        }
    }
}