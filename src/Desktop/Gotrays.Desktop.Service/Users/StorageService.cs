using Gotrays.Service.Contract.Chat;

namespace Gotrays.Desktop.Service.Users
{
    public class StorageService : IStorageService, IScopedDependency
    {
        private readonly IFreeSql _freeSql;

        private string? token;

        public StorageService(IFreeSql freeSql)
        {
            _freeSql = freeSql;
        }

        public string? Token
        {
            get
            {
                if (token.IsNullOrEmpty())
                {
                    var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                        "Gotrays", "token.key");
                    if (File.Exists(path))
                    {
                        token = File.ReadAllText(path);
                        TokenChange?.Invoke();
                    }
                }
                return token;
            }

            set
            {
                var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                    "Gotrays", "token.key");

                var info = new FileInfo(path);
                if (!Directory.Exists(info.DirectoryName))
                {
                    Directory.CreateDirectory(info.DirectoryName);
                }

                File.WriteAllText(path, value);
                token = value;
                TokenChange?.Invoke();
            }
        }

        public Action? TokenChange { get; set; }

        public async Task AddChatMessage(ChannelMessageDto dto)
        {
            await _freeSql.Insert(dto).ExecuteAffrowsAsync();
        }

        public async Task<List<ChannelMessageDto>> GetListAsync(Guid channelId)
        {
            return await _freeSql.Select<ChannelMessageDto>().Where(x => x.ChannelId == channelId).ToListAsync();
        }
    }
}