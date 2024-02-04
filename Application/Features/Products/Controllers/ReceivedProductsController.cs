using Application.Features.Auth;
using Application.Features.Products.Filters;
using Application.Features.Products.Models;
using Application.Features.Products.Models.Inventorization;
using Application.Features.Products.Services;
using Microsoft.AspNetCore.Mvc;

namespace Application.Features.Products.Controllers;

[ApiController]
[Route("products/received")]
[UwAuthorize(UwUserClaimTypes.EmployeeId)]
public class ReceivedProductsController(ProductsService productsService)
{
	private readonly ProductsService _productsService = productsService;

	[HttpPost]
	public async Task AddReceivedProdutc(ICollection<AddReceivedProductRequest> models, Guid warehouseId) 
	{
		await _productsService.AddReceivedProducts(models, warehouseId);
	}

	[HttpPut("cell")]
	public async Task ChangeCellPlace(ChangeReceivedProductCellRequest model)
	{
		await _productsService.ChangeCellPlace(model.ProductCellId, model.CellId);
	}
	
	[HttpPost("writeoff")]
	public async Task WriteOffProduct(Guid receivedProductId, long quantity, Guid writeOffTypeId)
	{
		await _productsService.WriteOff(receivedProductId, quantity, writeOffTypeId);
	}
	
	[HttpPost("ship")]
	public async Task ShipProducts(ICollection<ShipmentModel> models, Guid billId)
	{
		await _productsService.Ship(models, billId);
	}

}