namespace Gotrays.Desktop.Share.Pages
{
    public partial class Channel
    {
        [CascadingParameter(Name = nameof(ChannelDto))]
        public ChannelDto ChannelDto { get; set; }

        private List<ChannelMessageDto> _channels = new();

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
                var message = new ChannelMessageDto()
                {
                    Id = Guid.NewGuid(),
                    ChannelId = ChannelDto.Id,
                    CreatedTime = DateTime.Now,
                    Message = Message,
                    Type = MessageType.Message
                };
                _channels.Add(message);

                await StorageService.AddChatMessage(message);

                Message = string.Empty;

                await Task.CompletedTask;
            }

        }
    }
}
