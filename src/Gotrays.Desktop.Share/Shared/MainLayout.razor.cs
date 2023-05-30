namespace Gotrays.Desktop.Share.Shared;

public partial class MainLayout
{
    private bool _drawer;

    private bool _home;

    protected override async Task OnInitializedAsync()
    {
        if (NavigationManager.Uri == "http://localhost/")
        {
            _home = true;
        }

        await Task.CompletedTask;
    }
}
