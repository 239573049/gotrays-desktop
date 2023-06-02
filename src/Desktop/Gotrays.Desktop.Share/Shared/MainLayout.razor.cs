using Microsoft.AspNetCore.SignalR.Client;
using System.Data.Common;

namespace Gotrays.Desktop.Share.Shared;

public partial class MainLayout
{
    private bool _drawer;

    private bool _home;

    public ChannelDto Channel { get; private set; }

    public HubConnection Connection { get; private set; }

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
        if (string.IsNullOrEmpty(StorageService.Token))
        {
            NavigationManager.NavigateTo("/login");

            return;
        }

        if (NavigationManager.Uri == "http://localhost/")
        {
            _home = true;
        }

        if (!ConnectStatus)
        {
            Connection = new HubConnectionBuilder()
                .WithUrl("http://localhost:5126/ChatHub",
                    options => { options.AccessTokenProvider = () => Task.FromResult(StorageService.Token); })
                .AddMessagePackProtocol()
                .WithAutomaticReconnect()
                .Build();

            await Connection.StartAsync();

            Connection.Closed += async (Exception? exception) =>
            {
                ConnectStatus = false;
                await PopupService.EnqueueSnackbarAsync(exception?.Message, AlertTypes.Error);
            };

            Connection.On<ChannelMessageDto>("channel", (message) => { });

            ConnectStatus = true;
        }


        await Task.CompletedTask;
    }
}