using AutoMapper;
using LogisticCompany.Entity.Dto;
using LogisticCompany.Entity.Entity;
using LogisticCompany.Entity.Vm;

namespace LogisticCompany.Business
{
    public class VehicleProfile : Profile
    {
        public VehicleProfile()
        {
            CreateMap<Vehicle, VehicleVm>().ReverseMap();
            CreateMap<Vehicle, VehicleDto>().ReverseMap();
        }
    }
}
