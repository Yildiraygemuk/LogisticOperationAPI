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
        public IDataResult<IQueryable<VehicleVm>> GetListQueryable()
        {
            var entityList = _vehicleRepository.GetAll().OrderByDescending(x => x.CreatedDate);
            var vehicleVmList = _mapper.ProjectTo<VehicleVm>(entityList);
            return new SuccessDataResult<IQueryable<VehicleVm>>(vehicleVmList);
        }
        public IDataResult<VehicleVm> GetById(int id)
        {
            var entity = _vehicleRepository.GetAll().FirstOrDefault(x => x.Id == id);
            var vehicleVm = _mapper.Map<VehicleVm>(entity);
            return new SuccessDataResult<VehicleVm>(vehicleVm);
        }
        public async Task<IDataResult<VehicleDto>> Post(VehicleDto vehicleDto)
        {
            var addEntity = _mapper.Map<Vehicle>(vehicleDto);
            await _vehicleRepository.AddAsync(addEntity);
            return new SuccessDataResult<VehicleDto>(vehicleDto);
        }
        public IDataResult<VehicleDto> Update(VehicleDto vehicleDto)
        {
            var vehicle = _vehicleRepository.GetById(vehicleDto.Id);
            if (vehicle == null) { throw new NotFoundException(vehicleDto.Id); }
            vehicle = _mapper.Map(vehicleDto, vehicle);
            _vehicleRepository.Update(vehicle);
            return new SuccessDataResult<VehicleDto>(vehicleDto);
        }
        public IResult Delete(int id)
        {
            var entity = _vehicleRepository.GetById(id);
            if (entity == null)
            {
                return new ErrorResult();
            }
            _vehicleRepository.Delete(entity);
            return new SuccessResult();
        }
    }
}
