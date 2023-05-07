using AutoMapper;
using LogisticCompany.Entity.Dto;
using LogisticCompany.Entity.Entity;
using LogisticCompany.Entity.Vm;

namespace LogisticCompany.Business
{
    public class MaintenanceProfile : Profile
    {
        public MaintenanceProfile()
        {
            CreateMap<Maintenance, MaintenanceVm>()
                 .ForMember(dest => dest.PlateNo,
                    act => act.MapFrom(src => src.Vehicle.PlateNo))
                  .ForMember(dest => dest.ProfilePicture,
                    act => act.MapFrom(src => src.PictureGroup.PictureImage))
                  .ForMember(dest => dest.PhoneNumber,
                    act => act.MapFrom(src => src.User.PhoneNumber))
                  .ForMember(dest => dest.ResponsibleUserName,
                    act => act.MapFrom(src => src.User.FirstName + " " + src.User.LastName))
                  .ForMember(dest => dest.UserName,
                    act => act.MapFrom(src => src.User.FirstName + " " + src.User.LastName))
                   .ForMember(dest => dest.Status,
                    act => act.MapFrom(src => src.Status.Name));
            CreateMap<MaintenanceVm, Maintenance>();
            CreateMap<Maintenance, MaintenanceDto>().ReverseMap();
        }
    }
}
