using AutoMapper;
using motosale.user.backend.DTO.HelperModels.Jwt;
using motosale.user.backend.DTO.RequestModels;
using motosale.user.backend.DTO.RequestModels.Auth;
using motosale.user.backend.DTO.ResponseModels.Inner;
using motosale.user.backend.Models;

namespace motosale.user.backend.Extensions
{
    public class MappingEntity: Profile
    {
        public MappingEntity()
        {
            CreateMap<STATIC_DATA, StaticVM>().ReverseMap();
            CreateMap<COMPANY_EMPLOYEE, CompanyEmployeeDto>().ReverseMap();
            CreateMap<COMPANY_EMPLOYEE, CompanyEmployeeVM>().ReverseMap();

  


            CreateMap<USER, RegisterDto>().ReverseMap();
            CreateMap<USER, JwtCustomClaims>()
                .ForMember(dest => dest.UserId, opts => opts.MapFrom(src => src.Id))
                .ReverseMap();

        }
    }
}
