using AutoMapper;
using PersonRegisterTest.Infrastracture.DTOs;
using PersonRegisterTest.Infrastracture.Entities;

namespace PersonRegisterTest.Infrastracture.MappingProfile
{
    public class UserProfile :Profile
    {
        public UserProfile()
        {

            CreateMap<User, UserDTO>()
                .ForMember(dest => dest.TitleDescription, opts => opts.MapFrom((src, dest) => src.UserTitle != null ? src.UserTitle.Description : null))
                .ForMember(dest => dest.TypeDescription, opts => opts.MapFrom((src, dest) => src.UserType != null ? src.UserType.Description : null))
                .ForMember(dest => dest.TypeCode, opts => opts.MapFrom((src, dest) => src.UserType != null ? src.UserType.Code : null));
            

            CreateMap<UserDTO, User>()
                .AfterMap((src, dest) =>
                {
                    if(dest.UserType==null)
                    {
                        dest.UserType = new UserType();
                        dest.UserType.Id = src.UserTitleId;
                        dest.UserType.Description = src.TypeDescription;
                        dest.UserType.Code = src.TypeCode;
                    }
                    if(dest.UserTitle==null)
                    {

                        dest.UserTitle = new UserTitle();
                        dest.UserTitle.Id = src.UserTitleId;
                        dest.UserTitle.Description = src.TitleDescription;
                    }
                });


                //.ForMember(dest => dest.UserTitle.Description, opts => opts.MapFrom(src => src.TitleDescription))
                //.ForMember(dest => dest.UserType.Description, opts => opts.MapFrom(src => src.TypeDescription))
                //.ForMember(dest => dest.UserType.Code, opts => opts.MapFrom(src => src.TypeCode));
            
        }
    }
}
