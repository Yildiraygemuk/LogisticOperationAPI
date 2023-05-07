using LogisticCompany.Core.Utilities.Results;
using LogisticCompany.Entity.Dto;
using LogisticCompany.Entity.Vm;

namespace LogisticCompany.Business.Abstract
{
    public interface IVehicleService
    {
        IDataResult<IQueryable<VehicleVm>> GetListQueryable();
        IDataResult<VehicleVm> GetById(int id);
        Task<IDataResult<VehicleDto>> Post(VehicleDto vehicleDto);
        IDataResult<VehicleDto> Update(VehicleDto vehicleDto);
        IResult Delete(int id);
    }
}
