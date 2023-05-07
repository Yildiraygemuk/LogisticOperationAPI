using AutoMapper;
using LogisticCompany.Entity.Dto;
using LogisticCompany.Entity.Entity;
using LogisticCompany.Entity.Vm;

namespace LogisticCompany.Business
{
    public class StatusProfile : Profile
    {
        public StatusProfile()
        {
            CreateMap<Status, StatusVm>().ReverseMap();
            CreateMap<Status, StatusDto>().ReverseMap();
        }
    }
}
