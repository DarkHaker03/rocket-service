using Application.Features.Auth.Services;
using Application.Features.Warehouse.Models;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.Warehouse.Mappings;

public class StorageCellsMappingProfile : Profile
{
    public StorageCellsMappingProfile(UserIdentity userIdentity)
    {
        this.CreateProjection<UwCell, StoragePlaceModel>()
            .ForMember(dest => dest.Status, src => src.MapFrom(x => x.Status))
            .ForMember(dest => dest.Warehouse, src => src.MapFrom(x => x.Warehouse))
            .ForMember(dest => dest.Code, src => src.MapFrom(x => "TODO"))
            .ForMember(dest => dest.Name, src => src.MapFrom(x => x.Name))
            .ForMember(dest => dest.Place, src => src.MapFrom(x => x.Place));

        this.CreateMap<CreateStoragePlaceRequest, UwCell>()
            .ForMember(dest => dest.Status, src => src.MapFrom(x => x.Status))
            .ForMember(dest => dest.Description, src => src.MapFrom(x => x.Description))
            .ForMember(dest => dest.CreatedByEmployeeId, src => src.MapFrom(x => userIdentity.EmployeeId))
            .ForMember(dest => dest.WarehouseId, src => src.MapFrom(x => x.WarehouseId))
            .ForMember(dest => dest.Name, src => src.MapFrom(x => x.Name))
            .ForMember(dest => dest.Place, src => src.MapFrom(x => x.Place));
    }
}
