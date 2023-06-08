namespace Gotrays.Service.Contract.Users;

public class UserDto
{
    public Guid Id { get; set; }

    /// <summary>
    /// 用户名称
    /// </summary>
    public string UserName { get; set; }

    /// <summary>
    /// 账户
    /// </summary>
    public string Account { get; set; }

    /// <summary>
    /// 头像
    /// </summary>
    public string Avatar { get; set; }

    /// <summary>
    /// 是否禁用
    /// </summary>
    public bool IsDisable { get; set; }

    /// <summary>
    /// 角色
    /// </summary>
    public string? Role { get; set; }

    /// <summary>
    /// 上一次登陆时间
    /// </summary>
    public DateTime LastLoginTime { get; set; }
}