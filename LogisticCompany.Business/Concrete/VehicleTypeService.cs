using AutoMapper;
using LogisticCompany.Business.Abstract;
using LogisticCompany.Core.Entities.Exceptions;
using LogisticCompany.Core.Helpers;
using LogisticCompany.Core.Utilities.Results;
using LogisticCompany.DataAccess.Abstract.Repository;
using LogisticCompany.Entity.Dto;
using LogisticCompany.Entity.Entity;
using LogisticCompany.Entity.Vm;

namespace LogisticCompany.Business.Concrete
{
    public class VehicleTypeService : IVehicleTypeService
    {
        private readonly IVehicleTypeRepository _vehicleTypeRepository;
        private readonly IMapper _mapper;
        public VehicleTypeService(IVehicleTypeRepository vehicleTypeRepository, IMapper mapper)
        {
            _vehicleTypeRepository = vehicleTypeRepository;
            _mapper = mapper;
        }
        public async Task<IDataResult<IQueryable<VehicleTypeVm>>> GetListQueryable()
        {
            var entityList = await _vehicleTypeRepository.GetAllAsync();
            var sortedEntityList = entityList.OrderByDescending(x => x.CreatedDate);
            var vehicleTypeVmList = _mapper.ProjectTo<VehicleTypeVm>(sortedEntityList);
            return new SuccessDataResult<IQueryable<VehicleTypeVm>>(vehicleTypeVmList);
        }
        public async Task<IDataResult<VehicleTypeVm>> GetById(int id)
        {
            var entity = await _vehicleTypeRepository.GetByIdAsync(id);
            var vehicleTypeVm = _mapper.Map<VehicleTypeVm>(entity);
            return new SuccessDataResult<VehicleTypeVm>(vehicleTypeVm);
        }
        public async Task<IDataResult<VehicleTypeDto>> Post(VehicleTypeDto vehicleTypeDto)
        {
            var addEntity = _mapper.Map<VehicleType>(vehicleTypeDto);
            await _vehicleTypeRepository.AddAsync(addEntity);
            return new SuccessDataResult<VehicleTypeDto>(vehicleTypeDto);
        }
        public async Task<IDataResult<VehicleTypePutDto>> Update(VehicleTypePutDto vehicleTypeDto)
        {
            var vehicleType = await _vehicleTypeRepository.GetByIdAsync(vehicleTypeDto.Id);
            if (vehicleType == null) { throw new NotFoundException(vehicleTypeDto.Id); }
            vehicleType = _mapper.Map(vehicleTypeDto, vehicleType);
            _vehicleTypeRepository.Update(vehicleType);
            return new SuccessDataResult<VehicleTypePutDto>(vehicleTypeDto);
        }
        public async Task<IResult> Delete(int id)
        {
            var entity = await _vehicleTypeRepository.GetByIdAsync(id);
            if (entity == null)
            {
                return new ErrorResult();
            }
            _vehicleTypeRepository.Delete(entity);
            return new SuccessResult();
        }
    }
}
