using Gotrays.Service.Application.FileSystem.Commands;

namespace Gotrays.Service.Application.FileSystem;

public class CommandHandler
{
    private readonly IWebHostEnvironment _webHostEnvironment;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CommandHandler(IWebHostEnvironment webHostEnvironment, IHttpContextAccessor httpContextAccessor)
    {
        _webHostEnvironment = webHostEnvironment;
        _httpContextAccessor = httpContextAccessor;
    }

    [EventHandler(1)]
    public async Task UploadAsync(UploadCommand command)
    {
        // 生成唯一的文件名
        var fileName = Guid.NewGuid().ToString("N") + Path.GetExtension(command.FileName);

        // 保存图片到服务器
        var path = Path.Combine(_webHostEnvironment.WebRootPath, command.type);
        var filePath = Path.Combine(path, fileName);
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }

        await using var stream = new FileStream(filePath, FileMode.Create);

        await command.Stream.CopyToAsync(stream);

        command.Result = $"{_httpContextAccessor.HttpContext!.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host}/{command.type}/{fileName}";

    }
}