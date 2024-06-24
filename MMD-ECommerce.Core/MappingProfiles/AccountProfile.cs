using AutoMapper;
using MMD_ECommerce.Core.DTOs.Account;
using MMD_ECommerce.Data.Models.Users;
using MMD_ECommerce.Service.HelperModels;

namespace MMD_ECommerce.Core.MappingProfiles
{
    public class AccountProfile : Profile
    {
        public AccountProfile()
        {
            CreateMap<AuthenticationHM, AuthenticationDto>().ReverseMap();
            CreateMap<UserHM, UserDto>().ReverseMap();
            CreateMap<AppUser, UserDto>()
    .ForMember(dest => dest.Role, opt => opt.Ignore());
        }
    }
}
