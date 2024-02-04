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
        this.CreateMap<UwUser, UserModel>()
            .ForMember(dest => dest.EmployeeId, src => src.MapFrom(x => GetEmployeeId(userIdentity)))
            .ForMember(dest => dest.Image ,src => src.MapFrom(x => filesService.GetFileLink(x.Image.Name)));
    }

    private Guid? GetEmployeeId(UserIdentity userIdentity)
    {
        return userIdentity.IsEmployee ? userIdentity.EmployeeId : null;

	}
}
