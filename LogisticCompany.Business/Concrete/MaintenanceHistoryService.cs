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
    public class MaintenanceHistoryService : IMaintenanceHistoryService
    {
        private readonly IMaintenanceHistoryRepository _maintenanceHistoryRepository;
        private readonly IMapper _mapper;

        public MaintenanceHistoryService(IMaintenanceHistoryRepository maintenanceHistoryRepository, IMapper mapper)
        {
            _maintenanceHistoryRepository = maintenanceHistoryRepository;
            _mapper = mapper;
        }
        public async Task<IDataResult<IQueryable<MaintenanceHistoryVm>>> GetListQueryable()
        {
            var entityList = await _maintenanceHistoryRepository.GetAllAsync();
            var sortedEntityList = entityList.OrderByDescending(x => x.CreatedDate);
            var maintenanceHistoryVmList = _mapper.ProjectTo<MaintenanceHistoryVm>(sortedEntityList);
            return new SuccessDataResult<IQueryable<MaintenanceHistoryVm>>(maintenanceHistoryVmList);
        }
        public async Task<IDataResult<MaintenanceHistoryVm>> GetById(int id)
        {
            var entity = await _maintenanceHistoryRepository.GetByIdAsync(id);
            var maintenanceHistoryVm = _mapper.Map<MaintenanceHistoryVm>(entity);
            return new SuccessDataResult<MaintenanceHistoryVm>(maintenanceHistoryVm);
        }
        public async Task<IDataResult<MaintenanceHistoryDto>> Post(MaintenanceHistoryDto maintenanceHistoryDto)
        {
            var addEntity = _mapper.Map<MaintenanceHistory>(maintenanceHistoryDto);
            await _maintenanceHistoryRepository.AddAsync(addEntity);
            return new SuccessDataResult<MaintenanceHistoryDto>(maintenanceHistoryDto);
        }
        public async Task<IDataResult<MaintenanceHistoryPutDto>> Update(MaintenanceHistoryPutDto maintenanceHistoryDto)
        {
            var maintenanceHistory = await _maintenanceHistoryRepository.GetByIdAsync(maintenanceHistoryDto.Id);
            if (maintenanceHistory == null) { throw new NotFoundException(maintenanceHistoryDto.Id); }
            maintenanceHistory = _mapper.Map(maintenanceHistoryDto, maintenanceHistory);
            _maintenanceHistoryRepository.Update(maintenanceHistory);
            return new SuccessDataResult<MaintenanceHistoryPutDto>(maintenanceHistoryDto);
        }
        public async Task<IResult> Delete(int id)
        {
            var entity = await _maintenanceHistoryRepository.GetByIdAsync(id);
            if (entity == null)
            {
                return new ErrorResult();
            }
            _maintenanceHistoryRepository.Delete(entity);
            return new SuccessResult();
        }
    }
}
