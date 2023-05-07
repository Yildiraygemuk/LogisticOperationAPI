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
        public IDataResult<IQueryable<ActionTypeVm>> GetListQueryable()
        {
            var entityList = _actionTypeRepository.GetAll().OrderByDescending(x => x.CreatedDate);
            var actionTypeVmList = _mapper.ProjectTo<ActionTypeVm>(entityList);
            return new SuccessDataResult<IQueryable<ActionTypeVm>>(actionTypeVmList);
        }
        public IDataResult<ActionTypeVm> GetById(int id)
        {
            var entity = _actionTypeRepository.GetAll().FirstOrDefault(x => x.Id == id);
            var actionTypeVm = _mapper.Map<ActionTypeVm>(entity);
            return new SuccessDataResult<ActionTypeVm>(actionTypeVm);
        }
        public async Task<IDataResult<ActionTypeDto>> Post(ActionTypeDto actionTypeDto)
        {
            var addEntity = _mapper.Map<ActionType>(actionTypeDto);
            await _actionTypeRepository.AddAsync(addEntity);
            return new SuccessDataResult<ActionTypeDto>(actionTypeDto);
        }
        public IDataResult<ActionTypeDto> Update(ActionTypeDto actionTypeDto)
        {
            var actionType = _actionTypeRepository.GetById(actionTypeDto.Id);
            if (actionType == null) { throw new NotFoundException(actionTypeDto.Id); }
            actionType = _mapper.Map(actionTypeDto, actionType);
            _actionTypeRepository.Update(actionType);
            return new SuccessDataResult<ActionTypeDto>(actionTypeDto);
        }
        public IResult Delete(int id)
        {
            var entity = _actionTypeRepository.GetById(id);
            if (entity == null)
            {
                return new ErrorResult();
            }
            _actionTypeRepository.Delete(entity);
            return new SuccessResult();
        }
    }
}
