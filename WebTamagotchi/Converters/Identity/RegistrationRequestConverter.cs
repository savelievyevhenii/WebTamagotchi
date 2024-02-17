﻿using WebTamagotchi.Dto.Identity;
using WebTamagotchi.Identity.Models;

namespace WebTamagotchi.Converters.Identity;

public class RegistrationRequestConverter
{
    public static RegistrationRequestDto ToDto(RegistrationRequest request) => new RegistrationRequestDto
        { Email = request.Email, Password = request.Password, PasswordConfirm = request.PasswordConfirm };

    public static RegistrationRequest ToModel(RegistrationRequestDto dto) =>
        new RegistrationRequest { Email = dto.Email, Password = dto.Password, PasswordConfirm = dto.PasswordConfirm };
}