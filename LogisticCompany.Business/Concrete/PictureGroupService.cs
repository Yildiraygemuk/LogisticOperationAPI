using AutoMapper;
using LogisticCompany.Business.Abstract;
using LogisticCompany.Core.Entities.Exceptions;
using LogisticCompany.Core.Utilities.Results;
using LogisticCompany.DataAccess.Abstract.Repository;
using LogisticCompany.Entity.Dto;
using LogisticCompany.Entity.Entity;
using LogisticCompany.Entity.Vm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticCompany.Business.Concrete
{
    public class PictureGroupService : IPictureGroupService
    {
        private readonly IPictureGroupRepository _actionTypeRepository;
        private readonly IMapper _mapper;

        public PictureGroupService(IPictureGroupRepository actionTypeRepository, IMapper mapper)
        {
            _actionTypeRepository = actionTypeRepository;
            _mapper = mapper;
        }
        public async Task<IDataResult<IQueryable<PictureGroupVm>>> GetListQueryable()
        {
            var entityList = await _actionTypeRepository.GetAllAsync();
            var sortedEntityList = entityList.OrderByDescending(x => x.CreatedDate);
            var actionTypeVmList = _mapper.ProjectTo<PictureGroupVm>(entityList);
            return new SuccessDataResult<IQueryable<PictureGroupVm>>(actionTypeVmList);
        }
        public async Task<IDataResult<PictureGroupVm>> GetById(int id)
        {
            var entity = await _actionTypeRepository.GetByIdAsync(id);
            var actionTypeVm = _mapper.Map<PictureGroupVm>(entity);
            return new SuccessDataResult<PictureGroupVm>(actionTypeVm);
        }
        public async Task<IDataResult<PictureGroupDto>> Post(PictureGroupDto actionTypeDto)
        {
            var addEntity = _mapper.Map<PictureGroup>(actionTypeDto);
            await _actionTypeRepository.AddAsync(addEntity);
            return new SuccessDataResult<PictureGroupDto>(actionTypeDto);
        }
        public IDataResult<PictureGroupDto> Update(PictureGroupDto actionTypeDto)
        {
            var actionType = _actionTypeRepository.GetById(actionTypeDto.Id);
            if (actionType == null) { throw new NotFoundException(actionTypeDto.Id); }
            actionType = _mapper.Map(actionTypeDto, actionType);
            _actionTypeRepository.Update(actionType);
            return new SuccessDataResult<PictureGroupDto>(actionTypeDto);
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
