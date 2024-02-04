using Application.Features.Auth;
using Application.Features.Warehouse.Filters;
using Application.Features.Warehouse.Models;
using Application.Features.Warehouse.Services;
using Microsoft.AspNetCore.Mvc;

namespace Application.Features.Warehouse.Controllers;

[ApiController]
[Route("storage")]
[UwAuthorize(UwUserClaimTypes.EmployeeId)]
public class CellController(StorageService storageService)
{
	private readonly StorageService _storageService = storageService;

	[HttpGet("places")]
	public async Task<ICollection<StoragePlaceModel>> StoragePlaces([FromQuery]StoragePlaceFilter filter, Guid warehouseId)
	{
		return await _storageService.GetStorageCells(filter, warehouseId);
	}

	[HttpPost("place")]
	public async Task CreatePlace(CreateStoragePlaceRequest request)
	{
		await _storageService.CreateStorageCell(request);
	}
}
