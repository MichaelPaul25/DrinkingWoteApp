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
            CreateMap<Consument,  ConsumentDto>();
            CreateMap<Order, OrderDto>();
        }
    }
}
