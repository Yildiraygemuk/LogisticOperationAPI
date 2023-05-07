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
    public class StatusService : IStatusService
    {
        private readonly IStatusRepository _statusRepository;
        private readonly IMapper _mapper;

        public StatusService(IStatusRepository statusRepository, IMapper mapper)
        {
            _statusRepository = statusRepository;
            _mapper = mapper;
        }
        public IDataResult<IQueryable<StatusVm>> GetListQueryable()
        {
            var entityList = _statusRepository.GetAll().OrderByDescending(x => x.CreatedDate);
            var statusVmList = _mapper.ProjectTo<StatusVm>(entityList);
            return new SuccessDataResult<IQueryable<StatusVm>>(statusVmList);
        }
        public IDataResult<StatusVm> GetById(int id)
        {
            var entity = _statusRepository.GetAll().FirstOrDefault(x => x.Id == id);
            var statusVm = _mapper.Map<StatusVm>(entity);
            return new SuccessDataResult<StatusVm>(statusVm);
        }
        public async Task<IDataResult<StatusDto>> Post(StatusDto statusDto)
        {
            var addEntity = _mapper.Map<Status>(statusDto);
            await _statusRepository.AddAsync(addEntity);
            return new SuccessDataResult<StatusDto>(statusDto);
        }
        public IDataResult<StatusDto> Update(StatusDto statusDto)
        {
            var status = _statusRepository.GetById(statusDto.Id);
            if (status == null) { throw new NotFoundException(statusDto.Id); }
            status = _mapper.Map(statusDto, status);
            _statusRepository.Update(status);
            return new SuccessDataResult<StatusDto>(statusDto);
        }
        public IResult Delete(int id)
        {
            var entity = _statusRepository.GetById(id);
            if (entity == null)
            {
                return new ErrorResult();
            }
            _statusRepository.Delete(entity);
            return new SuccessResult();
        }
    }
}
