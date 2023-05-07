using AutoMapper;
using LogisticCompany.Entity.Dto;
using LogisticCompany.Entity.Entity;
using LogisticCompany.Entity.Vm;

namespace LogisticCompany.Business
{
    public class VehicleTypeProfile : Profile
    {
        public VehicleTypeProfile()
        {
            CreateMap<VehicleType, VehicleTypeVm>().ReverseMap();
            CreateMap<VehicleType, VehicleTypeDto>().ReverseMap();
        }
    }
}
