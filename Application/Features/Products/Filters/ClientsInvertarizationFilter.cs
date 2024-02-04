
using Application.Base.Interfaces;

namespace Application.Features.Products.Filters;

public class ClientsInvertarizationFilter : ICollectionFilter
{
	public int? Skip { get; set; }
	public int? Take { get; set; }
}
