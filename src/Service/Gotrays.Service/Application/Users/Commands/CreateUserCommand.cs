﻿using Gotrays.Service.Contract.Users;

namespace Gotrays.Service.Application.Users.Commands;

public record CreateUserCommand(CreateUserDto dto) : Command;