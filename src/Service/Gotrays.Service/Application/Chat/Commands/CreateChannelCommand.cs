using Gotrays.Service.Contract.Chat;

namespace Gotrays.Service.Application.Chat.Commands;

public record CreateChannelCommand(CreateChannelDto dto) : Command;