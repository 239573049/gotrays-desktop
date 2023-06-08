using Microsoft.AspNetCore.Http;

namespace Gotrays.Contracts.FileSystem;

public interface IFileSystemService
{
    Task<string> UploadAsync(IFormFile file);
}