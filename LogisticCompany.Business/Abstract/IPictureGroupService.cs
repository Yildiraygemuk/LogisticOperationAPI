using LogisticCompany.Core.Utilities.Results;
using LogisticCompany.Entity.Dto;
using LogisticCompany.Entity.Vm;

namespace LogisticCompany.Business.Abstract
{
    public interface IPictureGroupService
    {
        IDataResult<IQueryable<PictureGroupVm>> GetListQueryable();
        IDataResult<PictureGroupVm> GetById(int id);
        Task<IDataResult<PictureGroupDto>> Post(PictureGroupDto pictureGroupDto);
        IDataResult<PictureGroupDto> Update(PictureGroupDto pictureGroupDto);
        IResult Delete(int id);
    }
}
