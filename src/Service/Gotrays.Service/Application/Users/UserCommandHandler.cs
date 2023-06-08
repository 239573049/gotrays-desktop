using Gotrays.Service.Domain.Users.Aggregates;
using Gotrays.Service.Domain.Users.Repositories;
using Gotrays.Service.Infrastructure.Helpers;
using Masa.BuildingBlocks.Data.UoW;

namespace Gotrays.Service.Application.Users;

public class UserCommandHandler
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserRepository _userRepository;

    public UserCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    [EventHandler]
    public async Task CreateUserHandleAsync(CreateUserCommand userCommand)
    {
        if (await _userRepository.ExistAsync(x => x.Account == userCommand.dto.Account))
        {
            throw new UserFriendlyException("存在相同账号的用户");
        }

        var dto = userCommand.dto;
        var user = new User(Guid.NewGuid())
        {
            Salt = Guid.NewGuid().ToString("N"),
            Account = dto.Account,
            UserName = dto.UserName,
            Avatar = dto.Avatar,
            Role = "user",
            LastLoginTime = DateTime.Now
        };
        user.Password = Md5Helper.HashPassword(dto.Password, user.Salt);

        await _userRepository.AddAsync(user);
        await _unitOfWork.SaveChangesAsync();
    }
}