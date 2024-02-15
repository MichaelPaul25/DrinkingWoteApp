using AutoMapper;
using DrinkingWoteApp_API.Dto;
using DrinkingWoteApp_API.Models;

namespace DrinkingWoteApp_API.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
            CreateMap<Consument,  ConsumentDto>();
            CreateMap<ConsumentDto, Consument>();
            CreateMap<Order, OrderDto>();
            CreateMap<CrewDto, CrewMember>();
            CreateMap<CrewMember, CrewDto>();
            CreateMap<OrderDto, Order>();
            CreateMap<Order, OrderDto>();
            CreateMap<BillDto, Bill>();
            CreateMap<Bill, BillDto>();
        }
    }
}
