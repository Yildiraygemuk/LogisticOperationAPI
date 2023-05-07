using AutoMapper;
using LogisticCompany.Entity.Dto;
using LogisticCompany.Entity.Entity;
using LogisticCompany.Entity.Vm;

namespace LogisticCompany.Business
{
    public class ActionTypeProfile: Profile
    {
        public ActionTypeProfile()
        {
            CreateMap<ActionType, ActionTypeVm>().ReverseMap();
            CreateMap<ActionType, ActionTypeDto>().ReverseMap();
        }
    }
}
