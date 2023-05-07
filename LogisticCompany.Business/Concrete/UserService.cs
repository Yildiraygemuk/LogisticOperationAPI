using AutoMapper;
using LogisticCompany.Business.Abstract;
using LogisticCompany.Core.Entities.Exceptions;
using LogisticCompany.Core.Utilities.Results;
using LogisticCompany.Core.Utilities.Security.Hashing;
using LogisticCompany.DataAccess.Abstract.Repository;
using LogisticCompany.Entity.Dto;
using LogisticCompany.Entity.Entity;
using LogisticCompany.Entity.Vm;

namespace LogisticCompany.Business.Concrete
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public IDataResult<IQueryable<UserVm>> GetListQueryable()
        {
            var entityList = _userRepository.GetAll().OrderByDescending(x => x.CreatedDate);
            var userVmList = _mapper.ProjectTo<UserVm>(entityList);
            return new SuccessDataResult<IQueryable<UserVm>>(userVmList);
        }
        public IDataResult<UserVm> GetById(int id)
        {
            var entity = _userRepository.GetAll().FirstOrDefault(x => x.Id == id);
            var userVm = _mapper.Map<UserVm>(entity);
            return new SuccessDataResult<UserVm>(userVm);
        }
        public async Task<IResult> Post(UserForRegisterDto userForRegisterDto)
        {
            HashingHelper.CreatePasswordHash(userForRegisterDto.Password, out var passwordHash, out var passwordSalt);
            var user = new User
            {
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                PsrHash = passwordHash,
                PsrSalt = passwordSalt,
                PhoneNumber = userForRegisterDto.PhoneNumber,
                Email = userForRegisterDto.Email,
                Address= userForRegisterDto.Address,
                ProfilePicture = userForRegisterDto.ProfilePicture
            };
            await _userRepository.AddAsync(user);
            return new SuccessResult();
        }
        public IResult Update(UserDto userDto)
        {
            var user = _userRepository.GetById(userDto.Id);
            if (user == null) { throw new NotFoundException(userDto.Id); }
            user = _mapper.Map(userDto, user);
            _userRepository.Update(user);
            return new SuccessResult();
        }
        public IResult Delete(int id)
        {
            var entity = _userRepository.GetById(id);
            if (entity == null)
            {
                return new ErrorResult();
            }
            _userRepository.Delete(entity);
            return new SuccessResult();
        }
    }
}
