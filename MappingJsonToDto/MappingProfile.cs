using AutoMapper;

namespace MappingJsonToDto
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PostDto, Post>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.PostId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.PostTitle, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.PostBody, opt => opt.MapFrom(src => src.Body));
        }
    }
}