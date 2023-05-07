using LogisticCompany.Core.Utilities.Results;
using LogisticCompany.Entity.Dto;
using LogisticCompany.Entity.Vm;

namespace LogisticCompany.Business.Abstract
{
    public interface IMaintenanceHistoryService
    {
        IDataResult<IQueryable<MaintenanceHistoryVm>> GetListQueryable();
        IDataResult<MaintenanceHistoryVm> GetById(int id);
        Task<IDataResult<MaintenanceHistoryDto>> Post(MaintenanceHistoryDto maintenanceHistoryDto);
        IDataResult<MaintenanceHistoryDto> Update(MaintenanceHistoryDto maintenanceHistoryDto);
        IResult Delete(int id);
    }
}
