using AutoMapper;
using LogisticCompany.Business.Abstract;
using LogisticCompany.Core.Entities.Exceptions;
using LogisticCompany.Core.Utilities.Results;
using LogisticCompany.DataAccess.Abstract.Repository;
using LogisticCompany.Entity.Dto;
using LogisticCompany.Entity.Entity;
using LogisticCompany.Entity.Vm;

namespace LogisticCompany.Business.Concrete
{
    public class VehicleService : IVehicleService
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IMapper _mapper;

        public VehicleService(IVehicleRepository vehicleRepository, IMapper mapper)
        {
            _vehicleRepository = vehicleRepository;
            _mapper = mapper;
        }
        public async Task<IDataResult<IQueryable<VehicleVm>>> GetListQueryable()
        {
            var entityList = await _vehicleRepository.GetAllAsync();
            var sortedEntityList = entityList.OrderByDescending(x => x.CreatedDate);
            var vehicleVmList = _mapper.ProjectTo<VehicleVm>(sortedEntityList);
            return new SuccessDataResult<IQueryable<VehicleVm>>(vehicleVmList);
        }
        public async Task<IDataResult<VehicleVm>> GetById(int id)
        {
            var entity = await _vehicleRepository.GetByIdAsync(id);
            var vehicleVm = _mapper.Map<VehicleVm>(entity);
            return new SuccessDataResult<VehicleVm>(vehicleVm);
        }
        public async Task<IDataResult<VehicleDto>> Post(VehicleDto vehicleDto)
        {
            var addEntity = _mapper.Map<Vehicle>(vehicleDto);
            await _vehicleRepository.AddAsync(addEntity);
            return new SuccessDataResult<VehicleDto>(vehicleDto);
        }
        public async Task<IDataResult<VehiclePutDto>> Update(VehiclePutDto vehicleDto)
        {
            var vehicle = await _vehicleRepository.GetByIdAsync(vehicleDto.Id);
            if (vehicle == null) { throw new NotFoundException(vehicleDto.Id); }
            vehicle = _mapper.Map(vehicleDto, vehicle);
            _vehicleRepository.Update(vehicle);
            return new SuccessDataResult<VehiclePutDto>(vehicleDto);
        }
        public async Task<IResult> Delete(int id)
        {
            var entity = await _vehicleRepository.GetByIdAsync(id);
            if (entity == null)
            {
                return new ErrorResult();
            }
            _vehicleRepository.Delete(entity);
            return new SuccessResult();
        }
    }
}
