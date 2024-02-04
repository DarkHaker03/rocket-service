using Application.Base.Interfaces;

namespace Application.Features.Warehouse.Filters;

public class StoragePlaceFilter : ICollectionFilter
{
	public int? Skip { get; set; }
	public int? Take { get; set; }
}
