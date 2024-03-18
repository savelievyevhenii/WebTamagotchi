using WebTamagotchi.ApplicationServices.Dto.Identity;
using WebTamagotchi.Identity.Models;

namespace WebTamagotchi.ApplicationServices.Converters.Identity;

public static class TokenModelConverter
{
    public static TokenModelDto ToDto(TokenModel model) =>
        new TokenModelDto
        {
            AccessToken = model.AccessToken,
            RefreshToken = model.RefreshToken
        };

    public static TokenModel ToModel(TokenModelDto dto) =>
        new TokenModel
        {
            AccessToken = dto.AccessToken,
            RefreshToken = dto.RefreshToken
        };
}