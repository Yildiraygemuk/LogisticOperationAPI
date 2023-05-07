using LogisticCompany.Core.Utilities.Results;
using LogisticCompany.Entity.Dto;
using LogisticCompany.Entity.Vm;

namespace LogisticCompany.Business.Abstract
{
    public interface IUserService
    {
        IDataResult<IQueryable<UserVm>> GetListQueryable();
        IDataResult<UserVm> GetById(int id);
        Task<IResult> Post(UserForRegisterDto userForRegisterDto);
        IResult Update(UserDto userDto);
        IResult Delete(int id);
    }
}
