using WebTamagotchi.ApplicationServices.Dto.Identity;
using WebTamagotchi.Identity.Models;

namespace WebTamagotchi.ApplicationServices.Converters.Identity;

public static class AuthRequestConverter
{
    public static AuthRequestDto ToDto(AuthRequest request)
    {
        return new AuthRequestDto { Email = request.Email, Password = request.Password };
    }

    public static AuthRequest ToModel(AuthRequestDto dto)
    {
        return new AuthRequest { Email = dto.Email, Password = dto.Password };
    }
}