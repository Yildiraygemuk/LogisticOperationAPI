using AutoMapper;
using LogisticCompany.Business.Abstract;
using LogisticCompany.Core.Entities.Exceptions;
using LogisticCompany.Core.Utilities.Results;
using LogisticCompany.DataAccess.Abstract.Repository;
using LogisticCompany.Entity.Dto;
using LogisticCompany.Entity.Entity;
using LogisticCompany.Entity.Enum;
using LogisticCompany.Entity.Vm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticCompany.Business.Concrete
{
    public class MaintenanceService : IMaintenanceService
    {
        private readonly IMaintenanceRepository _maintenanceRepository;
        private readonly IMaintenanceHistoryRepository _maintenanceHistoryRepository;
        private readonly IMapper _mapper;

        public MaintenanceService(IMaintenanceRepository maintenanceRepository, IMaintenanceHistoryRepository maintenanceHistoryRepository, IMapper mapper)
        {
            _maintenanceRepository = maintenanceRepository;
            _maintenanceHistoryRepository = maintenanceHistoryRepository;
            _mapper = mapper;
        }
        public async Task<IDataResult<IQueryable<MaintenanceVm>>> GetListQueryable()
        {
            var entityList = await _maintenanceRepository.GetAllAsync();
            var sortedEntityList = entityList.OrderByDescending(x => x.CreatedDate);
            var maintenanceVmList = _mapper.ProjectTo<MaintenanceVm>(sortedEntityList);
            return new SuccessDataResult<IQueryable<MaintenanceVm>>(maintenanceVmList);
        }
        public async Task<IDataResult<MaintenanceVm>> GetById(int id)
        {
            var entity = await _maintenanceRepository.GetByIdAsync(id);
            var maintenanceVm = _mapper.Map<MaintenanceVm>(entity);
            return new SuccessDataResult<MaintenanceVm>(maintenanceVm);
        }
        public async Task<IDataResult<MaintenanceDto>> Post(MaintenanceDto maintenanceDto)
        {
            var addEntity = _mapper.Map<Maintenance>(maintenanceDto);
            var result = await _maintenanceRepository.AddAsync(addEntity);
            if (result.Success)
            {
                MaintenanceHistory history = new MaintenanceHistory();
                history.MaintenanceId = result.Data.Id;
                history.ActionTypeId = (int)ActionTypeEnum.WillDoRightNow;
                await _maintenanceHistoryRepository.AddAsync(history);
            }
            return new SuccessDataResult<MaintenanceDto>(maintenanceDto);
        }
        public async Task<IDataResult<MaintenanceDto>> Update(MaintenanceDto maintenanceDto)
        {
            var maintenance = await _maintenanceRepository.GetByIdAsync(maintenanceDto.Id);
            if (maintenance == null) { throw new NotFoundException(maintenanceDto.Id); }
            maintenance = _mapper.Map(maintenanceDto, maintenance);
            _maintenanceRepository.Update(maintenance);
            return new SuccessDataResult<MaintenanceDto>(maintenanceDto);
        }

        public async Task<IResult> UpdateStatus(MaintenanceStatusDto maintenanceStatus)
        {
            var maintenance = await _maintenanceRepository.GetByIdAsync(maintenanceStatus.MaintenanceId);
            maintenance.StatusID = maintenanceStatus.StatusId;
            var result = _maintenanceRepository.Update(maintenance);
            if (result.Success)
            {
                MaintenanceHistory history = new MaintenanceHistory();
                history.MaintenanceId = result.Data.Id;
                history.ActionTypeId = maintenanceStatus.ActionTypeId;
                await _maintenanceHistoryRepository.AddAsync(history);
            }
            return new SuccessResult();
        }
        public async Task<IResult> Delete(int id)
        {
            var entity = await _maintenanceRepository.GetByIdAsync(id);
            if (entity == null)
            {
                return new ErrorResult();
            }
            _maintenanceRepository.Delete(entity);
            return new SuccessResult();
        }
    }
}
