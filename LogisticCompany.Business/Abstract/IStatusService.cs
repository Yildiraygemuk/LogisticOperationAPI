using LogisticCompany.Core.Utilities.Results;
using LogisticCompany.Entity.Dto;
using LogisticCompany.Entity.Vm;

namespace LogisticCompany.Business.Abstract
{
    public interface IStatusService
    {
        IDataResult<IQueryable<StatusVm>> GetListQueryable();
        IDataResult<StatusVm> GetById(int id);
        Task<IDataResult<StatusDto>> Post(StatusDto statusDto);
        IDataResult<StatusDto> Update(StatusDto statusDto);
        IResult Delete(int id);
    }
}
