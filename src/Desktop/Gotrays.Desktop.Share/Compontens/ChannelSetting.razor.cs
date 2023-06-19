namespace Gotrays.Desktop.Share.Compontens;

public partial class ChannelSetting
{
    [Parameter]
    public ChannelDto ChannelDto { get; set; }

    [Parameter]
    public RenderFragment<ActivatorProps> ChildContent { get; set; }

    private List<string> _UserList = new List<string>();
}