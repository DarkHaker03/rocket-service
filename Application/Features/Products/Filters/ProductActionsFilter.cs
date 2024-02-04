
using Application.Base.Interfaces;

namespace Application.Features.Products.Filters
{
	public class ProductActionsFilter : ICollectionFilter
	{
		public int? Skip { get; set; }
		public int? Take { get; set; }
	}
}
