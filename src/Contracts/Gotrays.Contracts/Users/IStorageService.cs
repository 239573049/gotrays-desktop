using Gotrays.Service.Contract.Chat;

namespace Gotrays.Contracts.Users
{
    public interface IStorageService
    {
        public string Token { get; set; }

        public Action TokenChange { get; set; }

        /// <summary>
        /// 添加记录
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task AddChatMessage(ChannelMessageDto dto);

        /// <summary>
        /// 获取指定管道记录
        /// </summary>
        /// <param name="channelId"></param>
        /// <returns></returns>
        Task<List<ChannelMessageDto>> GetListAsync(Guid channelId);

    }
}
