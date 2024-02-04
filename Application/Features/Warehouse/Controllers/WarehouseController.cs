using Application.Features.Auth;
using Application.Features.Warehouse.Filters;
using Application.Features.Warehouse.Models;
using Application.Features.Warehouse.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Application.Features.Warehouse.Controllers;

[ApiController]
[Route("warehouse")]
[UwAuthorize(UwUserClaimTypes.EmployeeId)]
public class WarehouseController(WarehouseService warehouseService)
{
	private readonly WarehouseService _warehouseService = warehouseService;

	[HttpGet]	
	public async Task<ICollection<UwWarehouse>> Get([FromQuery] WarehouseFilter filters)
	{
		return await _warehouseService.GetRange(filters);
	}

	[HttpGet("{id}")]
	public async Task<UwWarehouse> Get(Guid id)
	{
		return await _warehouseService.Get(id);
	}

	[HttpDelete]
	public async Task Delete(Guid id)
	{
		await _warehouseService.Delete(id);
	}

	[HttpPost]
	public async Task Create([FromQuery] UwWarehouse warehouse)
	{
		await _warehouseService.Add(warehouse);
	}
}
