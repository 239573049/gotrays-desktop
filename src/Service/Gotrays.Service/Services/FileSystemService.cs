using Gotrays.Contracts.FileSystem;
using Gotrays.Service.Application.FileSystem.Commands;

namespace Gotrays.Service.Services;

public class FileSystemService : BaseService<FileSystemService>, IFileSystemService
{
    public async Task<string> UploadAsync(IFormFile file)
    {
        if (file.Length > 1024 * 1024 * 10)
        {
            throw new UserFriendlyException("文件大小不能超过10M");
        }

        var command = new UploadCommand(file.OpenReadStream(), file.FileName, "files");
        await EventBus.PublishAsync(command);

        return command.Result;
    }
}