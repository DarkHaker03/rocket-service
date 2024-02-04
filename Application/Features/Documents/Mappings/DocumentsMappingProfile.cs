using Application.Features.Documents.Model;
using Application.Features.Documents.Model.Bills;
using Application.Features.Documents.Model.Enums;
using Application.Features.Documents.Model.Products;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.Documents.Mappings;

public class DocumentsMappingProfile : Profile
{
    public DocumentsMappingProfile()
    {
	    this.CreateProjection<UwBill, ExcelBillModel>()
		    .ForMember(dest => dest.Quantity, src => src.MapFrom(x => x.Quantity))
		    .ForMember(dest => dest.WillLeaveAt, src => src.MapFrom(x => x.RealizationDate));
			//.ForMember(dest => dest.Article, src => src.MapFrom(x => x.Product.Article)) //TODO



		this.CreateProjection<UwReceivedProduct, ExcelReceivedProduct>()
			.ForMember(dest => dest.Quantity, src => src.MapFrom(x => x.Quantity))
			.ForMember(dest => dest.Article, src => src.MapFrom(x => x.Product.Article));

		this.CreateProjection<(UwBill bill, DocumentTypes type), DocumentModel>()
			.ForMember(dest => dest.EntityId, src => src.MapFrom(x => x.bill.Id))
			.ForMember(dest => dest.DocumentType, src => src.MapFrom(x => x.type))
			.ForMember(dest => dest.FileTypes, src => src.MapFrom(x => DocumentFileTypes.XLS))
			.ForMember(dest => dest.Name, src => src.MapFrom(x => "Накладная"))
			.ForMember(dest => dest.Description, src => src.MapFrom(x => x.bill.Number));
	}
}
