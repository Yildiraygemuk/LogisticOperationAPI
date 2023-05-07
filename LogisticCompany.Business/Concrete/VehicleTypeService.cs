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
        private readonly IHttpAccessorHelper _httpAccessorHelper;
        public VehicleTypeService(IVehicleTypeRepository vehicleTypeRepository, IMapper mapper,IHttpAccessorHelper httpAccessorHelper)
        {
            _vehicleTypeRepository = vehicleTypeRepository;
            _mapper = mapper;
            _httpAccessorHelper = httpAccessorHelper;
        }
        public IDataResult<IQueryable<VehicleTypeVm>> GetListQueryable()
        {
            var userId = _httpAccessorHelper.GetUserId();
            var entityList = _vehicleTypeRepository.GetAll().OrderByDescending(x => x.CreatedDate);
            var vehicleTypeVmList = _mapper.ProjectTo<VehicleTypeVm>(entityList);
            return new SuccessDataResult<IQueryable<VehicleTypeVm>>(vehicleTypeVmList);
        }
        public IDataResult<VehicleTypeVm> GetById(int id)
        {
            var entity = _vehicleTypeRepository.GetAll().FirstOrDefault(x => x.Id == id);
            var vehicleTypeVm = _mapper.Map<VehicleTypeVm>(entity);
            return new SuccessDataResult<VehicleTypeVm>(vehicleTypeVm);
        }
        public async Task<IDataResult<VehicleTypeDto>> Post(VehicleTypeDto vehicleTypeDto)
        {
            var addEntity = _mapper.Map<VehicleType>(vehicleTypeDto);
            await _vehicleTypeRepository.AddAsync(addEntity);
            return new SuccessDataResult<VehicleTypeDto>(vehicleTypeDto);
        }
        public IDataResult<VehicleTypeDto> Update(VehicleTypeDto vehicleTypeDto)
        {
            var vehicleType = _vehicleTypeRepository.GetById(vehicleTypeDto.Id);
            if (vehicleType == null) { throw new NotFoundException(vehicleTypeDto.Id); }
            vehicleType = _mapper.Map(vehicleTypeDto, vehicleType);
            _vehicleTypeRepository.Update(vehicleType);
            return new SuccessDataResult<VehicleTypeDto>(vehicleTypeDto);
        }
        public IResult Delete(int id)
        {
            var entity = _vehicleTypeRepository.GetById(id);
            if (entity == null)
            {
                return new ErrorResult();
            }
            _vehicleTypeRepository.Delete(entity);
            return new SuccessResult();
        }
    }
}
