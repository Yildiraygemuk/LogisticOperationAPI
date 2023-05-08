using LogisticCompany.Core.Utilities.Results;
using LogisticCompany.Entity.Dto;
using LogisticCompany.Entity.Vm;

namespace LogisticCompany.Business.Abstract
{
    public interface IMaintenanceHistoryService
    {
        Task<IDataResult<IQueryable<MaintenanceHistoryVm>>> GetListQueryable();
        Task<IDataResult<MaintenanceHistoryVm>> GetById(int id);
        Task<IDataResult<MaintenanceHistoryDto>> Post(MaintenanceHistoryDto maintenanceHistoryDto);
        Task<IDataResult<MaintenanceHistoryPutDto>> Update(MaintenanceHistoryPutDto maintenanceHistoryDto);
        Task<IResult> Delete(int id);
    }
}
