using AutoMapper;
using LogisticCompany.Entity.Dto;
using LogisticCompany.Entity.Entity;
using LogisticCompany.Entity.Vm;

namespace LogisticCompany.Business
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserVm>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}
