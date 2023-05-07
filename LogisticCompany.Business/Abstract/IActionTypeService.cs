using LogisticCompany.Core.Utilities.Results;
using LogisticCompany.Entity.Dto;
using LogisticCompany.Entity.Vm;

namespace LogisticCompany.Business.Abstract
{
    public interface IActionTypeService
    {
        IDataResult<IQueryable<ActionTypeVm>> GetListQueryable();
        IDataResult<ActionTypeVm> GetById(int id);
        Task<IDataResult<ActionTypeDto>> Post(ActionTypeDto actionTypeDto);
        IDataResult<ActionTypeDto> Update(ActionTypeDto actionTypeDto);
        IResult Delete(int id);
    }
}
