using WebTamagotchi.Dto.Identity;
using WebTamagotchi.Identity.Models;

namespace WebTamagotchi.Converters.Identity;

public static class AuthResponseConverter
{
    public static AuthResponseDto ToDto(AuthResponse response) => new AuthResponseDto
    {
        Username = response.Username, Email = response.Email, Token = response.Token,
        RefreshToken = response.RefreshToken
    };

    public static AuthResponse ToModel(AuthResponseDto dto) => new AuthResponse
    {
        Username = dto.Username, Email = dto.Email, Token = dto.Token, RefreshToken = dto.RefreshToken
    };
}