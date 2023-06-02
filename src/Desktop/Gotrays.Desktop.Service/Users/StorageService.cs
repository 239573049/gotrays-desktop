using Gotrays.Service.Contract.Chat;

namespace Gotrays.Desktop.Service.Users
{
    public class StorageService : IStorageService, ISingletonDependency
    {
        private readonly IFreeSql _freeSql;

        private string? token;

        public StorageService(IFreeSql freeSql)
        {
            _freeSql = freeSql;
        }

        public string? Token
        {
            get => token;

            set
            {
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
