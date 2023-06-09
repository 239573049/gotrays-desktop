﻿using Gotrays.Desktop.Share.Shared;
using Microsoft.AspNetCore.SignalR.Client;

namespace Gotrays.Desktop.Share.Pages
{
    public partial class Channel
    {
        private ChannelDto _channelDto;

        [CascadingParameter(Name = nameof(ChannelDto))]
        public ChannelDto ChannelDto
        {
            get => _channelDto;
            set
            {
                _channelDto = value;
                _ = LoadMessageAsync();
            }
        }

        public List<ChannelMessageDto> _channels { get; set; } = new();

        [Parameter]
        [CascadingParameter(Name = nameof(MainLayout))]
        public MainLayout MainLayout { get; set; }

        private string? Message;

        protected override void OnInitialized()
        {
            MainLayout.OnMessage += OnMessage;
        }

        private async Task OnClickUser(ChannelMessageDto dto)
        {
            dto.Show = true;
            await Task.CompletedTask;
        }

        private async Task LoadMessageAsync()
        {
            _channels = await StorageService.GetListAsync(ChannelDto.Id);
            _ = InvokeAsync(StateHasChanged);
        }

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="obj"></param>
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

                // 清空输入框
                Message = string.Empty;

                await Task.CompletedTask;
            }
        }

        private async Task OnMessage(ChannelMessageDto msg)
        {
            var user = ((CustomAuthenticationStateProvider)AuthenticationStateProvider).UserId();

            if (user != msg.TheirUserId)
            {
                _channels.Add(msg);
            }

            await InvokeAsync(StateHasChanged);
        }
    }
}