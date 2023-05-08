using LogisticCompany.Core.Utilities.Results;
using LogisticCompany.Entity.Dto;
using LogisticCompany.Entity.Vm;

namespace LogisticCompany.Business.Abstract
{
    public interface IMaintenanceService
    {
        Task<IDataResult<IQueryable<MaintenanceVm>>> GetListQueryable();
        Task<IDataResult<MaintenanceVm>> GetById(int id);
        Task<IDataResult<MaintenanceDto>> Post(MaintenanceDto maintenanceDto);
        Task<IDataResult<MaintenancePutDto>> Update(MaintenancePutDto maintenanceDto);
        Task<IResult> UpdateStatus(MaintenanceStatusDto maintenanceStatus);
        Task<IResult> Delete(int id);
    }
}
