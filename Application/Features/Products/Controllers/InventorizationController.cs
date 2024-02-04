using Application.Features.Auth;
using Application.Features.Products.Filters;
using Application.Features.Products.Models.Inventorization;
using Application.Features.Products.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Application.Features.Products.Controllers;

[ApiController]
[Route("products/inventorize")]
[UwAuthorize(UwUserClaimTypes.EmployeeId)]
public class InventorizationController(ProductsInventorizationService inventorizationService)
{
	private readonly ProductsInventorizationService _inventorizationService = inventorizationService;

	[HttpGet("warehouse")]
	
	public async Task<WarehouseInventorizationModel> InvertorizeWarehouse([FromQuery]  Guid warehouseId)
	{
		return await _inventorizationService.InventorizeWarehouse(warehouseId);
	}


	[HttpGet("clients")]
	public async Task<IEnumerable<ClientInventorizationModel>> InvertorizeClients([FromQuery] ClientsInvertarizationFilter filter)
	{
		return await _inventorizationService.InvertorizeClients(filter);
	}

	[HttpGet("client")]
	public async Task<ClientInventorizationModel> InvertorizeClient([FromQuery] Guid clientId)
	{
		return await _inventorizationService.InventorizeClient(clientId);
	}

	[HttpGet("products")]
	public async Task<IEnumerable<ProductInventorizationModel>> InvertorizeProducts([FromQuery] InventorizationFilter? filter)
	{
		return await _inventorizationService.InventorizeProducts(filter);
	}
}