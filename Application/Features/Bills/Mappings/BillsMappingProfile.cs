
using Application.Features.Bills.Models;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;

namespace Application.Features.Bills.Mappings;

public class BillsMappingProfile : Profile
{
    public BillsMappingProfile()
    {
        this.CreateMap<CreateBillModel, UwBill>()
            .ForMember(dest => dest.CarId, src => src.MapFrom(x => x.CarId))
            .ForMember(dest => dest.WarehouseId, src => src.MapFrom(x => x.WarehouseId))
            .ForMember(dest => dest.RealizationDate, src => src.MapFrom(x => x.RealizeDate))
            .ForMember(dest => dest.Note, src => src.MapFrom(x => x.Note))
            .ForMember(dest => dest.Address, src => src.MapFrom(x => x.Address ?? ""))
            .ForMember(dest => dest.Status, src => src.MapFrom(x => BillStatus.New))
            .ForMember(dest => dest.ProductsBills, src => src.MapFrom(x =>x.Products))
            .ForMember(dest => dest.Number, src => src.MapFrom(x => 0));

        this.CreateMap<ProductBillModel, UwProductBill>()
            .ForMember(dest => dest.ProductId, src => src.MapFrom(x => x.ProductId))
            .ForMember(dest => dest.Barcode, src => src.MapFrom(x => x.Barcode))
            .ForMember(dest => dest.Quantity, src => src.MapFrom(x => x.Quantity));
    }
}
