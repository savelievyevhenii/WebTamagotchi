using WebTamagotchi.ApplicationServices.Dto.Identity;
using WebTamagotchi.Identity.Enums;
using WebTamagotchi.Identity.Models;

namespace WebTamagotchi.ApplicationServices.Converters.Identity;

public static class UserConverter
{
    public static UserDto ToDto(User user) =>
        new UserDto
        {
            Id = user.Id,
            Username = user.UserName,
            Email = user.Email,
            Role = user.Role.ToString()
        };

    public static User ToModel(UserDto dto) =>
        new User
        {
            Id = dto.Id,
            UserName = dto.Username,
            Email = dto.Email,
            Role = Enum.Parse<Role>(dto.Role!)
        };
}