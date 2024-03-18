using WebTamagotchi.ApplicationServices.Dto.Identity;
using WebTamagotchi.Identity.Enums;

namespace WebTamagotchi.ApplicationServices.Converters.Identity;

public static class RoleConverter
{
    public static RoleDto ToDto(Role role)
    {
        return new RoleDto() { Role = role.ToString() };
    }

    public static Role ToModel(RoleDto dto)
    {
        return Enum.TryParse<Role>(dto.Role, out var parsedRole) ? parsedRole : Role.Player;
    }
}