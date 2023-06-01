﻿namespace Gotrays.Service.Contract.Chat;

public class ChannelMessageDto
{
    public Guid Id { get; set; }

    public string Message { get; set; }

    public Guid ChannelId { get; set; }

    /// <summary>
    /// 用户id
    /// </summary>
    public Guid? UserId { get; set; }

    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime CreatedTime { get; set; }

    /// <summary>
    /// 消息类型
    /// </summary>
    public MessageType Type { get; set; }
}