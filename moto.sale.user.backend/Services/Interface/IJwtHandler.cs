using motosale.user.backend.DTO.HelperModels;
using motosale.user.backend.DTO.HelperModels.Jwt;
using motosale.user.backend.Models;

namespace motosale.user.backend.Services.Interface
{
    public interface IJwtHandler
    {
        JwtResponse CreateToken(JwtCustomClaims claims);
    }
}
