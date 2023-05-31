using Gotrays.Service.Application.Chat.Commands;
using Gotrays.Service.Domain.Chat.Aggregates;
using Gotrays.Service.Domain.Chat.Repositories;
using Masa.BuildingBlocks.Authentication.Identity;
using Masa.BuildingBlocks.Data.UoW;

namespace Gotrays.Service.Application.Chat;

public class ChannelCommandHandler
{
    private readonly IUserContext _userContext;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IChannelRepository _channelRepository;

    public ChannelCommandHandler(IChannelRepository channelRepository, IUserContext userContext, IUnitOfWork unitOfWork)
    {
        _channelRepository = channelRepository;
        _userContext = userContext;
        _unitOfWork = unitOfWork;
    }

    [EventHandler]
    public async Task CreateChannelAsync(CreateChannelCommand command)
    {
        var result = await _channelRepository.FindAsync(
            x => x.Name == command.dto.Name && x.UserId == _userContext.GetUserId<Guid>());
        if (result != null)
        {
            throw new UserFriendlyException("已存在相同名称的频道");
        }

        var channel = new Channel(Guid.NewGuid())
        {
            Name = command.dto.Name,
            Description = command.dto.Description,
            Avatar = command.dto.Avatar,
            UserId = _userContext.GetUserId<Guid>()
        };

        await _channelRepository.AddAsync(channel);
        await _unitOfWork.SaveChangesAsync();
    }
}