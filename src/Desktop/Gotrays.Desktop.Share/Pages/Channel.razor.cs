namespace Gotrays.Desktop.Share.Pages
{
    public partial class Channel
    {
        [CascadingParameter(Name = nameof(ChannelDto))]
        public ChannelDto ChannelDto { get; set; }

        private List<ChannelMessageDto> _channels = new();

        private string? Message;

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
                _channels.Add(new ChannelMessageDto()
                {
                    Id = Guid.NewGuid(),
                    ChannelId = ChannelDto.Id,
                    CreatedTime = DateTime.Now,
                    Message = Message,
                    Type = MessageType.Message
                });
                Message = string.Empty;

                await Task.CompletedTask;
            }

        }
    }
}
