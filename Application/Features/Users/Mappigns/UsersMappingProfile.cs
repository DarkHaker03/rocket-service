using Application.Features.Auth.Services;
using Application.Features.Files.Services;
using Application.Features.Users.Models;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.Users.Mappigns;

public class UsersMappingProfile : Profile
{
    public UsersMappingProfile(UserIdentity userIdentity, FilesService filesService)
    {
        this.CreateMap<RUser, UserModel>()
            .ForMember(dest => dest.Image ,src => src.MapFrom(x => filesService.GetFileLink(x.Image.Name)));
    }
}
