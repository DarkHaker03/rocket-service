

namespace Application.Features.Products.Filters;

public class InventorizationFilter
{
	public Guid? ClientId { get; set; }
	public Guid? WarehouseId { get; set; }
	public Guid? ProductId { get; set; }
}
