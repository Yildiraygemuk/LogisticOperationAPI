using LogisticCompany.Core.Utilities.Results;
using LogisticCompany.Entity.Dto;
using LogisticCompany.Entity.Vm;

namespace LogisticCompany.Business.Abstract
{
    public interface IPictureGroupService
    {
        Task<IDataResult<IQueryable<PictureGroupVm>>> GetListQueryable();
        Task<IDataResult<PictureGroupVm>> GetById(int id);
        Task<IDataResult<PictureGroupDto>> Post(PictureGroupDto pictureGroupDto);
        Task<IDataResult<PictureGroupPutDto>> Update(PictureGroupPutDto pictureGroupDto);
        Task<IResult> Delete(int id);
    }
}
