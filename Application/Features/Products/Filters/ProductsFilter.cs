using Application.Base.Interfaces;

namespace Application.Features.Products.Filters;

public class ProductsFilter : ICollectionFilter
{
	public int? Skip { get; set; }
	public int? Take { get; set; }
	
	public string? SearchText { get; set; }
}
