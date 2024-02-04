
namespace Application.Features.Products.Models.Inventorization;

public class WarehouseInventorizationModel : InventorizationModelBase
{
	public required string WarehouseName { get; set; }

	public required Guid WarehouseId { get; set; }
}
