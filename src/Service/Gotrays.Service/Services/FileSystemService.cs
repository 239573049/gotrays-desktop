using Gotrays.Contracts.FileSystem;

namespace Gotrays.Service.Services;

public class FileSystemService : BaseService<FileSystemService>, IFileSystemService
{
    public Task<string> UploadAsync(IFormFile file)
    {
        
    }
}