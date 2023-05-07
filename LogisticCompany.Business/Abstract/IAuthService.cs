using LogisticCompany.Core.Entities.Dtos;
using LogisticCompany.Core.Utilities.Results;
using LogisticCompany.Core.Utilities.Security.Jwt;
using LogisticCompany.Entity.Dto;
using LogisticCompany.Entity.Entity;

namespace LogisticCompany.Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<User> Login(UserForLoginDto userForLoginDto);
        IDataResult<AccessToken> CreateAccessToken(User user);
        IDataResult<User> GetForAuthorization(int userId, string email);
        IResult IsUserExists(Core.Entities.Dtos.AuthUserDto authUserDto);
    }
}
