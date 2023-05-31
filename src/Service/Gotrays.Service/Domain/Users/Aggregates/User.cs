using Masa.BuildingBlocks.Ddd.Domain.Entities.Full;

namespace Gotrays.Service.Domain.Users.Aggregates;

public class User : FullAggregateRoot<Guid, Guid?>
{
    protected User()
    {
    }

    public User(Guid id) : base(id)
    {
    }

    /// <summary>
    /// 用户名称
    /// </summary>
    public string UserName { get;  set; }

    /// <summary>
    /// 账户
    /// </summary>
    public string Account { get;  set; }

    /// <summary>
    /// 密码
    /// </summary>
    public string Password { get;  set; }

    /// <summary>
    /// 盐
    /// </summary>
    public string Salt { get;  set; }

    /// <summary>
    /// 头像
    /// </summary>
    public string Avatar { get;  set; }

    /// <summary>
    /// 是否禁用
    /// </summary>
    public bool IsDisable { get;  set; }

    /// <summary>
    /// 角色
    /// </summary>
    public string? Role { get; set; }

    /// <summary>
    /// 上一次登陆时间
    /// </summary>
    public DateTime LastLoginTime { get;  set; }
}