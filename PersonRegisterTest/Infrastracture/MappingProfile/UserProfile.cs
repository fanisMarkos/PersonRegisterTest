using AutoMapper;
using PersonRegisterTest.Infrastracture.DTOs;
using PersonRegisterTest.Infrastracture.Entities;

namespace PersonRegisterTest.Infrastracture.MappingProfile
{
    /// <summary>
    /// Profile For Mapping
    /// </summary>
    public class UserProfile :Profile
    {
        public UserProfile()
        {

            CreateMap<User, UserDTO>()
                .ForMember(dest => dest.TitleDescription, opts => opts.MapFrom((src, dest) => src.UserTitle != null ? src.UserTitle.Description : null))
                .ForMember(dest => dest.TypeDescription, opts => opts.MapFrom((src, dest) => src.UserType != null ? src.UserType.Description : null))
                .ForMember(dest => dest.TypeCode, opts => opts.MapFrom((src, dest) => src.UserType != null ? src.UserType.Code : null));


            CreateMap<User, UserCreateEditDto>().ReverseMap();


               
            
        }
    }
}
