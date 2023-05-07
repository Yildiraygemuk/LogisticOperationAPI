using AutoMapper;
using LogisticCompany.Entity.Dto;
using LogisticCompany.Entity.Entity;
using LogisticCompany.Entity.Vm;

namespace LogisticCompany.Business
{
    public class PictureGroupProfile : Profile
    {
        public PictureGroupProfile()
        {
            CreateMap<PictureGroup, PictureGroupVm>().ReverseMap();
            CreateMap<PictureGroup, PictureGroupDto>().ReverseMap();
        }
    }
}
