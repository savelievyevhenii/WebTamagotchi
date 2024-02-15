using WebTamagotchi.Dal.Dto;
using WebTamagotchi.Dal.Entity;

namespace WebTamagotchi.Dal.Converters;

public class UserConverter
{
    public static UserDto ToDto(User user) => new UserDto
        { Email = user.Email };

    public static User ToModel(UserDto dto) =>
        new User { Email = dto.Email };
}