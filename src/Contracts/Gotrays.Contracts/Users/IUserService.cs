namespace Gotrays.Service.Contract.Users;

public interface IUserService
{
    Task CreateAsync(CreateUserDto dto);
    
    Task<string> LoginAsync(string account, string password);

}