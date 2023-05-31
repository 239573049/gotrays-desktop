

namespace Gotrays.Desktop.Share.Compontens
{
    public partial class GMenu
    {
        private StringNumber _selectedItem;

        private List<ChannelDto> channelDtos = new();

        [Parameter]
        public EventCallback<ChannelDto> OnClick { get; set; }

        private async Task OnGitHub()
        {
            await JSRuntime.InvokeVoidAsync("open", "https://github.com/239573049/gotrays-desktop");
        }

        private async Task LoadAsync()
        {
            channelDtos = await ChannelService.GetListAsync(string.Empty);
        }

        protected override async Task OnInitializedAsync()
        {
            await LoadAsync();
        }
    }
}
