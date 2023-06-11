using Microsoft.AspNetCore.Components.Forms;
using Token.Helpers;

namespace Gotrays.Desktop.Share.Compontens;

public partial class AddChannel : IAsyncDisposable
{
    private const string FileId = "addChannelFile";

    [Parameter] public bool Value { get; set; }

    [Parameter] public EventCallback<bool> ValueChanged { get; set; }

    /// <summary>
    /// 管道名称
    /// </summary>
    private string Name { get; set; }

    /// <summary>
    /// 头像
    /// </summary>
    private string Avatar { get; set; } = "https://cdn.masastack.com/stack/images/website/masa-blazor/jack.png";

    /// <summary>
    /// 描述
    /// </summary>
    private string Description { get; set; }

    private MemoryStream? fileStream;

    [Parameter]
    public EventCallback OnClickChanged { get; set; }

    private async Task HandleOnChange(InputFileChangeEventArgs eventArgs)
    {
        fileStream = new MemoryStream();
        await eventArgs.File.OpenReadStream().CopyToAsync(fileStream).ConfigureAwait(false);
        Avatar = $"data:{eventArgs.File.ContentType};base64,{Convert.ToBase64String(fileStream.ToArray())}";
    }

    private async Task AvatarClick()
    {
        await DesktopModule.Click(FileId);
    }
    
    private async Task OnClick()
    {
        if (Name.IsNullOrEmpty() || Description.IsNullOrEmpty())
        {
            return;
        }

        await ChannelService.CreateAsync(new CreateChannelDto()
        {
            Name = Name,
            Description = Description
        });

        await OnClickChanged.InvokeAsync();
    }

    public async ValueTask DisposeAsync()
    {
        fileStream?.Close();
        await Task.CompletedTask;
    }
}