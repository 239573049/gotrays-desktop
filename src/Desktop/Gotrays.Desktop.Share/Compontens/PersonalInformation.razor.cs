namespace Gotrays.Desktop.Share.Compontens;

public partial class PersonalInformation
{
    /// <summary>
    /// 归属用户
    /// </summary>
    [Parameter]
    public Guid TheirUserId { get; set; }

    public UserDto? User { get; set; }

    private bool _value;

    [Parameter]
    public bool Value
    {
        get => _value;
        set
        {
            if (value)
            {
                Load();
            }
            _value = value;
        }
    }

    [Parameter]
    public EventCallback<bool> ValueChanged { get; set; }

    [Parameter]
    public RenderFragment<ActivatorProps>? ActivatorContent { get; set; }

    private void Load()
    {
        _ = Task.Run(async () =>
        {
            User = await UserService.GetAsync(TheirUserId);
            _ = InvokeAsync(StateHasChanged);
        });
    }
}
