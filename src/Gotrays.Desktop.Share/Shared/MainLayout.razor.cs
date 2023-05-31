namespace Gotrays.Desktop.Share.Shared;

public partial class MainLayout
{
    private bool _drawer;

    private bool _home;

    public ChannelDto Channel { get; set; }

    private void OnChannelClick(ChannelDto channel)
    {
        Channel = channel;
        NavigationManager.NavigateTo("/channel");
    }

    protected override async Task OnInitializedAsync()
    {
        if (NavigationManager.Uri == "http://localhost/")
        {
            _home = true;
        }

        await Task.CompletedTask;
    }
}
