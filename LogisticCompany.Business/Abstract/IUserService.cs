using LogisticCompany.Core.Utilities.Results;
using LogisticCompany.Entity.Dto;
using LogisticCompany.Entity.Vm;

namespace LogisticCompany.Business.Abstract
{
    public interface IUserService
    {
        Task<IDataResult<IQueryable<UserVm>>> GetListQueryable();
        Task<IDataResult<UserVm>> GetById(int id);
        Task<IResult> Post(UserForRegisterDto userForRegisterDto);
        Task<IResult> Update(UserDto userDto);
        Task<IResult> Delete(int id);
    }
}
