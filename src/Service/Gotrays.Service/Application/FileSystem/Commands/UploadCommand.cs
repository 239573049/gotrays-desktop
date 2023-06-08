namespace Gotrays.Service.Application.FileSystem.Commands;

public record UploadCommand(Stream Stream, string FileName) : Command
{
    public string Result { get; set; }
}