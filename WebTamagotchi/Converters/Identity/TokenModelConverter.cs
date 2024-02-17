using WebTamagotchi.Dto.Identity;
using WebTamagotchi.Identity.Models;

namespace WebTamagotchi.Converters.Identity;

public class TokenModelConverter
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