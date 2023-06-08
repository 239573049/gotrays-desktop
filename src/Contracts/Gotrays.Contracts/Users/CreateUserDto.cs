namespace Gotrays.Service.Contract.Users;

public class CreateUserDto
{
    /// <summary>
    /// 用户名称
    /// </summary>
    public string UserName { get; set; }

    /// <summary>
    /// 账户
    /// </summary>
    public string Account { get; set; }

    /// <summary>
    /// 密码
    /// </summary>
    public string Password { get; set; }

    /// <summary>
    /// 头像
    /// </summary>
    public string Avatar { get; set; }
}