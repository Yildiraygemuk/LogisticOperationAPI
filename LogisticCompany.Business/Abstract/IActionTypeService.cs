using LogisticCompany.Core.Utilities.Results;
using LogisticCompany.Entity.Dto;
using LogisticCompany.Entity.Vm;

namespace LogisticCompany.Business.Abstract
{
    public interface IActionTypeService
    {
        Task<IDataResult<IQueryable<ActionTypeVm>>> GetListQueryable();
        Task<IDataResult<ActionTypeVm>> GetById(int id);
        Task<IDataResult<ActionTypeDto>> Post(ActionTypeDto actionTypeDto);
        Task<IDataResult<ActionTypePutDto>> Update(ActionTypePutDto actionTypeDto);
        Task<IResult> Delete(int id);
    }
}
