using LogisticCompany.Core.Utilities.Results;
using LogisticCompany.Entity.Dto;
using LogisticCompany.Entity.Vm;

namespace LogisticCompany.Business.Abstract
{
    public interface IVehicleTypeService
    {
        IDataResult<IQueryable<VehicleTypeVm>> GetListQueryable();
        IDataResult<VehicleTypeVm> GetById(int id);
        Task<IDataResult<VehicleTypeDto>> Post(VehicleTypeDto vehicleTypeDto);
        IDataResult<VehicleTypeDto> Update(VehicleTypeDto vehicleTypeDto);
        IResult Delete(int id);
    }
}
