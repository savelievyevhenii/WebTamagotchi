﻿using CSharpFunctionalExtensions;
using MediatR;
using WebTamagotchi.ApplicationServices.Dto.Identity;
using WebTamagotchi.Identity.Enums;
using WebTamagotchi.Identity.Errors;

namespace WebTamagotchi.ApplicationServices.Commands.UserCommands;

public class ChangeRoleCommand : IRequest<Result<UserDto, Error>>
{
    public string Email { get; init; } = null!;

    public Role Role { get; init; }
}