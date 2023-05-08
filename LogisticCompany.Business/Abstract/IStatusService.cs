using LogisticCompany.Core.Utilities.Results;
using LogisticCompany.Entity.Dto;
using LogisticCompany.Entity.Vm;

namespace LogisticCompany.Business.Abstract
{
    public interface IStatusService
    {
        Task<IDataResult<IQueryable<StatusVm>>> GetListQueryable();
        Task<IDataResult<StatusVm>> GetById(int id);
        Task<IDataResult<StatusDto>> Post(StatusDto statusDto);
        Task<IDataResult<StatusPutDto>> Update(StatusPutDto statusDto);
        Task<IResult> Delete(int id);
    }
}
