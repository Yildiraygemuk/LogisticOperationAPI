using LogisticCompany.Core.Utilities.Results;
using LogisticCompany.Entity.Dto;
using LogisticCompany.Entity.Vm;

namespace LogisticCompany.Business.Abstract
{
    public interface IVehicleService
    {
        Task<IDataResult<IQueryable<VehicleVm>>> GetListQueryable();
        Task<IDataResult<VehicleVm>> GetById(int id);
        Task<IDataResult<VehicleDto>> Post(VehicleDto vehicleDto);
        Task<IDataResult<VehiclePutDto>> Update(VehiclePutDto vehicleDto);
        Task<IResult> Delete(int id);
    }
}
