using Application.Base.Interfaces;

namespace Application.Features.Warehouse.Filters;

public class WarehouseFilter : ICollectionFilter
{
	public int? Skip { get ; set ; }
	public int? Take { get ; set ; }
}