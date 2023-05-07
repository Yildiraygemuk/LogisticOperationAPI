using AutoMapper;
using LogisticCompany.Entity.Dto;
using LogisticCompany.Entity.Entity;
using LogisticCompany.Entity.Vm;

namespace LogisticCompany.Business
{
    public class MaintenanceHistoryProfile : Profile
    {
        public MaintenanceHistoryProfile()
        {
            CreateMap<MaintenanceHistory, MaintenanceHistoryVm>().ReverseMap();
            CreateMap<MaintenanceHistory, MaintenanceHistoryDto>().ReverseMap();
        }
    }
}
