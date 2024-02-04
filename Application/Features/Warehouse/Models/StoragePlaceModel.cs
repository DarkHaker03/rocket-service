using Domain.Entities;
using Domain.Enums;

namespace Application.Features.Warehouse.Models;

public class StoragePlaceModel
{
	public required string Place { get; set; }
	
	public required string Name { get; set; }

	public required StoragePlaceStatus Status { get; set; }

	public string Code { get; set; } = string.Empty;
	
	public required UwWarehouse Warehouse { get; set; }

}
