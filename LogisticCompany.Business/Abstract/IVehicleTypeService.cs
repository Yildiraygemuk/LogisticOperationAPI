using LogisticCompany.Core.Utilities.Results;
using LogisticCompany.Entity.Dto;
using LogisticCompany.Entity.Vm;

namespace LogisticCompany.Business.Abstract
{
    public interface IVehicleTypeService
    {
        Task<IDataResult<IQueryable<VehicleTypeVm>>> GetListQueryable();
        Task<IDataResult<VehicleTypeVm>> GetById(int id);
        Task<IDataResult<VehicleTypeDto>> Post(VehicleTypeDto vehicleTypeDto);
        Task<IDataResult<VehicleTypePutDto>> Update(VehicleTypePutDto vehicleTypeDto);
        Task<IResult> Delete(int id);
    }
}
