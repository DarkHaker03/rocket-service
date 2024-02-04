using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Application.Features.Host.Mappings;

public class ApplicationMappingProfile : Profile
{
    public ApplicationMappingProfile()
    {
        this.CreateMap<Exception, ProblemDetails>()
            .ForMember(dest => dest.Status, src => src.MapFrom(x => 400))
            .ForMember(dest => dest.Detail, src => src.MapFrom(x => x.Message))
            .ForMember(dest => dest.Title, src => src.MapFrom(x => "Ошибка"));
    }   
}