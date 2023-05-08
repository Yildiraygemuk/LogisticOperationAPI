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
        public async Task<IDataResult<IQueryable<UserVm>>> GetListQueryable()
        {
            var entityList = await _userRepository.GetAllAsync();
            var sortedEntityList = entityList.OrderByDescending(x => x.CreatedDate);
            var userVmList = _mapper.ProjectTo<UserVm>(sortedEntityList);
            return new SuccessDataResult<IQueryable<UserVm>>(userVmList);
        }
        public async Task<IDataResult<UserVm>> GetById(int id)
        {
            var entity = await _userRepository.GetByIdAsync(id);
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
        public async Task<IResult> Update(UserDto userDto)
        {
            var user = await _userRepository.GetByIdAsync(userDto.Id);
            if (user == null) { throw new NotFoundException(userDto.Id); }
            user = _mapper.Map(userDto, user);
            _userRepository.Update(user);
            return new SuccessResult();
        }
        public async Task<IResult> Delete(int id)
        {
            var entity = await _userRepository.GetByIdAsync(id);
            if (entity == null)
            {
                return new ErrorResult();
            }
            _userRepository.Delete(entity);
            return new SuccessResult();
        }
    }
}
