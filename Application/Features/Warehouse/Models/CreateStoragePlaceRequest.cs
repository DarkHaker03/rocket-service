using Domain.Enums;

namespace Application.Features.Warehouse.Models;

public class CreateStoragePlaceRequest
{
	public required string Place { get; set; }

	public required string Name { get; set; }
	public string Description { get; set; }

	public required StoragePlaceStatus Status { get; set; }

	public string Code { get; set; } = string.Empty;
	
	public Guid StageId { get; set; }

	public required Guid WarehouseId { get; set; }
}
