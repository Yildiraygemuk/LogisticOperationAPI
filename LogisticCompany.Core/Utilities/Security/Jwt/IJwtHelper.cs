using LogisticCompany.Core.Entities.Dtos;

namespace LogisticCompany.Core.Utilities.Security.Jwt
{
    public interface IJwtHelper
    {
        AccessToken CreateToken(UserDto user);
    }
}