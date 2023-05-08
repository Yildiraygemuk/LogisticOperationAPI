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
    public class ActionTypeService : IActionTypeService
    {
        private readonly IActionTypeRepository _actionTypeRepository;
        private readonly IMapper _mapper;

        public ActionTypeService(IActionTypeRepository actionTypeRepository, IMapper mapper)
        {
            _actionTypeRepository = actionTypeRepository;
            _mapper = mapper;
        }
        public async Task<IDataResult<IQueryable<ActionTypeVm>>> GetListQueryable()
        {
            var entityList = await _actionTypeRepository.GetAllAsync();
            var sortedEntityList = entityList.OrderByDescending(x => x.CreatedDate);
            var actionTypeVmList = _mapper.ProjectTo<ActionTypeVm>(entityList);
            return new SuccessDataResult<IQueryable<ActionTypeVm>>(actionTypeVmList);
        }
        public async Task<IDataResult<ActionTypeVm>> GetById(int id)
        {
            var entity = await _actionTypeRepository.GetByIdAsync(id);
            var actionTypeVm = _mapper.Map<ActionTypeVm>(entity);
            return new SuccessDataResult<ActionTypeVm>(actionTypeVm);
        }
        public async Task<IDataResult<ActionTypeDto>> Post(ActionTypeDto actionTypeDto)
        {
            var addEntity = _mapper.Map<ActionType>(actionTypeDto);
            await _actionTypeRepository.AddAsync(addEntity);
            return new SuccessDataResult<ActionTypeDto>(actionTypeDto);
        }
        public async Task<IDataResult<ActionTypeDto>> Update(ActionTypeDto actionTypeDto)
        {
            var actionType = await _actionTypeRepository.GetByIdAsync(actionTypeDto.Id);
            if (actionType == null) { throw new NotFoundException(actionTypeDto.Id); }
            actionType = _mapper.Map(actionTypeDto, actionType);
            _actionTypeRepository.Update(actionType);
            return new SuccessDataResult<ActionTypeDto>(actionTypeDto);
        }
        public async Task<IResult> Delete(int id)
        {
            var entity = await _actionTypeRepository.GetByIdAsync(id);
            if (entity == null)
            {
                return new ErrorResult();
            }
            _actionTypeRepository.Delete(entity);
            return new SuccessResult();
        }
    }
}
