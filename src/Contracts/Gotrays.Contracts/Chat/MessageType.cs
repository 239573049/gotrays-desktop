namespace Gotrays.Service.Contract.Chat;

public enum MessageType
{
    /// <summary>
    /// 普通消息
    /// </summary>
    Message,

    /// <summary>
    /// 文件
    /// </summary>
    File,

    /// <summary>
    /// 图片
    /// </summary>
    Image,

    /// <summary>
    /// 视频
    /// </summary>
    Video,

    /// <summary>
    /// 音频
    /// </summary>
    Audio,

    /// <summary>
    /// 系统消息
    /// </summary>
    System,

    /// <summary>
    /// 通知消息
    /// </summary>
    Notice,

    /// <summary>
    /// 命令消息
    /// </summary>
    Command,

    /// <summary>
    /// 未知消息
    /// </summary>
    Unknown,
}