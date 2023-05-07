using AutoMapper;
using LogisticCompany.Business.Abstract;
using LogisticCompany.Business.Constants;
using LogisticCompany.Core.Utilities.Results;
using LogisticCompany.Core.Utilities.Security.Hashing;
using LogisticCompany.Core.Utilities.Security.Jwt;
using LogisticCompany.DataAccess.Abstract.Repository;
using LogisticCompany.Entity.Dto;
using LogisticCompany.Entity.Entity;

namespace LogisticCompany.Business.Concrete
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtHelper _tokenHelper;
        private readonly IMapper _mapper;

        public AuthService(IUserRepository userRepository,
                           IJwtHelper tokenHelper,
                           IMapper mapper)
        {
            _userRepository = userRepository;
            _tokenHelper = tokenHelper;
            _mapper = mapper;
        }
     

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var userDto = new Core.Entities.Dtos.UserDto()
            {
                Email = user.Email,
                FirstName = user.FirstName,
                Id = user.Id,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
            };
            var accessToken = _tokenHelper.CreateToken(userDto);
            return new SuccessDataResult<AccessToken>(accessToken, Messages.AccessTokenCreated);
        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userRepository.GetAll().FirstOrDefault(x => x.Email == userForLoginDto.Email);
            if (userToCheck == null)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.PsrHash, userToCheck.PsrSalt))
            {
                return new ErrorDataResult<User>(Messages.PasswordError);
            }

            return new SuccessDataResult<User>(userToCheck, Messages.SuccessfulLogin);
        }
        public IDataResult<User> GetForAuthorization(int userId, string email)
        {
            var user = _userRepository.GetAll().FirstOrDefault(x => x.Id == userId && x.Email == email);
            if (user != null)
            {
                return new SuccessDataResult<User>(user);
            }

            return new ErrorDataResult<User>(Messages.UserNotFound);
        }
        public IResult IsUserExists(Core.Entities.Dtos.AuthUserDto authUserDto)
        {
            var user = _userRepository.GetAll().FirstOrDefault(x => x.Email == authUserDto.UserEmail);
            if (user != null)
            {
                return new SuccessResult(Messages.UserExist);
            }
            return new SuccessResult();
        }
    }
}
