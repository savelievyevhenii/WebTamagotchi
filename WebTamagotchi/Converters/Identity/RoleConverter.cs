using WebTamagotchi.Dto.Identity;
using WebTamagotchi.Identity.Enums;

namespace WebTamagotchi.Converters.Identity
{
    public class RoleConverter
    {
        public static RoleDto ToDto(Role role) =>
            new RoleDto
            {
                Role = role.ToString()
            };

        public static Role ToModel(RoleDto dto) =>
            Enum.TryParse<Role>(dto.Role, out var parsedRole) ? parsedRole : Role.Player;
    }
}