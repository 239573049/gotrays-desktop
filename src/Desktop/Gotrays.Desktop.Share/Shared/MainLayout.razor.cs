using Microsoft.AspNetCore.SignalR.Client;

namespace Gotrays.Desktop.Share.Shared;

public partial class MainLayout
{
    private bool _drawer;

    private bool _home;

    public ChannelDto Channel { get; set; }

    private HubConnection _connection { get; set; }

    private bool ConnectStatus;

    private void OnChannelClick(ChannelDto channel)
    {
        if (Channel == channel)
        {
            Channel = null;
            NavigationManager.NavigateTo("/");
            return;
        }
        Channel = channel;
        NavigationManager.NavigateTo("/channel");
    }

    protected override async Task OnInitializedAsync()
    {
        if (NavigationManager.Uri == "http://localhost/")
        {
            _home = true;
        }

        if (!ConnectStatus)
        {
            _connection = new HubConnectionBuilder()
                .WithUrl("http://localhost:5126/ChatHub", options =>
                {
                    options.AccessTokenProvider = () => Task.FromResult(StorageService.Token);
                })
                .AddMessagePackProtocol()
                .WithAutomaticReconnect()
                .Build();

            await _connection.StartAsync();

            _connection.Closed += async (Exception? exception) =>
            {
                ConnectStatus = false;
                await PopupService.EnqueueSnackbarAsync(exception?.Message, AlertTypes.Error);
            };

            ConnectStatus = true;
        }


        await Task.CompletedTask;
    }
}
