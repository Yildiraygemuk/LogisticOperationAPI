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
        public IDataResult<IQueryable<MaintenanceHistoryVm>> GetListQueryable()
        {
            var entityList = _maintenanceHistoryRepository.GetAll().OrderByDescending(x => x.CreatedDate);
            var maintenanceHistoryVmList = _mapper.ProjectTo<MaintenanceHistoryVm>(entityList);
            return new SuccessDataResult<IQueryable<MaintenanceHistoryVm>>(maintenanceHistoryVmList);
        }
        public IDataResult<MaintenanceHistoryVm> GetById(int id)
        {
            var entity = _maintenanceHistoryRepository.GetAll().FirstOrDefault(x => x.Id == id);
            var maintenanceHistoryVm = _mapper.Map<MaintenanceHistoryVm>(entity);
            return new SuccessDataResult<MaintenanceHistoryVm>(maintenanceHistoryVm);
        }
        public async Task<IDataResult<MaintenanceHistoryDto>> Post(MaintenanceHistoryDto maintenanceHistoryDto)
        {
            var addEntity = _mapper.Map<MaintenanceHistory>(maintenanceHistoryDto);
            await _maintenanceHistoryRepository.AddAsync(addEntity);
            return new SuccessDataResult<MaintenanceHistoryDto>(maintenanceHistoryDto);
        }
        public IDataResult<MaintenanceHistoryDto> Update(MaintenanceHistoryDto maintenanceHistoryDto)
        {
            var maintenanceHistory = _maintenanceHistoryRepository.GetById(maintenanceHistoryDto.Id);
            if (maintenanceHistory == null) { throw new NotFoundException(maintenanceHistoryDto.Id); }
            maintenanceHistory = _mapper.Map(maintenanceHistoryDto, maintenanceHistory);
            _maintenanceHistoryRepository.Update(maintenanceHistory);
            return new SuccessDataResult<MaintenanceHistoryDto>(maintenanceHistoryDto);
        }
        public IResult Delete(int id)
        {
            var entity = _maintenanceHistoryRepository.GetById(id);
            if (entity == null)
            {
                return new ErrorResult();
            }
            _maintenanceHistoryRepository.Delete(entity);
            return new SuccessResult();
        }
    }
}
