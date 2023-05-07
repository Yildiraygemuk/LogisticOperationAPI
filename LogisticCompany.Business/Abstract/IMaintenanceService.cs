using LogisticCompany.Core.Utilities.Results;
using LogisticCompany.Entity.Dto;
using LogisticCompany.Entity.Vm;

namespace LogisticCompany.Business.Abstract
{
    public interface IMaintenanceService
    {
        IDataResult<IQueryable<MaintenanceVm>> GetListQueryable();
        IDataResult<MaintenanceVm> GetById(int id);
        Task<IDataResult<MaintenanceDto>> Post(MaintenanceDto maintenanceDto);
        IDataResult<MaintenanceDto> Update(MaintenanceDto maintenanceDto);
        IResult Delete(int id);
    }
}
