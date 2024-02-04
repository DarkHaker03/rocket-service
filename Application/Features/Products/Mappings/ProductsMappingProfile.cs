
using Application.Features.Products.Models;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.Products.Mappings;

public class ProductsMappingProfile : Profile
{
    public ProductsMappingProfile()
    {
        this.CreateMap<(List<UwImage> images, UwProduct product), ProductOutputModel>()
            .ForMember(dest => dest.Images, src => src.MapFrom(x => x.images))
            .ForMember(dest => dest.Article, src => src.MapFrom(x => x.product.Article))
            .ForMember(dest => dest.Color, src => src.MapFrom(x => x.product.Color))
            .ForMember(dest => dest.Id, src => src.MapFrom(x => x.product.Id))
            .ForMember(dest => dest.ObjectCreateDate, src => src.MapFrom(x => x.product.ObjectCreateDate))
            .ForMember(dest => dest.Name, src => src.MapFrom(x => x.product.Name));
        
        
        //TODO: images converting
        this.CreateProjection<UwProduct, ProductOutputModel>()
            //.ForMember(dest => dest.Images, src => src.MapFrom(x => x.ImageLinks.Select(q => q.Image.Name)))
            .ForMember(dest => dest.Article, src => src.MapFrom(x => x.Article))
            .ForMember(dest => dest.Color, src => src.MapFrom(x => x.Color))
            .ForMember(dest => dest.Id, src => src.MapFrom(x => x.Id))
            .ForMember(dest => dest.ObjectCreateDate, src => src.MapFrom(x => x.ObjectCreateDate))
            .ForMember(dest => dest.Name, src => src.MapFrom(x => x.Name));

    }
}
