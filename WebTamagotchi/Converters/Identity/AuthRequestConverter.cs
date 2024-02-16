using WebTamagotchi.Dto.Identity;
using WebTamagotchi.Identity.Models;

namespace WebTamagotchi.Converters.Identity;

public class AuthRequestConverter
{
    public static AuthRequestDto ToDto(AuthRequest request) => new AuthRequestDto
        { Email = request.Email, Password = request.Password };

    public static AuthRequest ToModel(AuthRequestDto dto) =>
        new AuthRequest { Email = dto.Email, Password = dto.Password };
}