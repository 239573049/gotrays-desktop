using Masa.BuildingBlocks.Authentication.Identity;

namespace Gotrays.Service.Services;

public abstract class BaseService<T> : ServiceBase where T : class
{
    internal IEventBus EventBus => GetRequiredService<IEventBus>();
    
    internal ILogger<T> Logger => GetRequiredService<ILogger<T>>();
    
    internal IUserContext UserContext => GetRequiredService<IUserContext>();
}