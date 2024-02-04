using Application.Features.Products.Filters;
using Application.Features.Products.Models;
using Application.Features.Products.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Application.Features.Products.Controllers;

[ApiController]
[Route("products")]
public class ProductsController(ProductsService productsService)
{
	private readonly ProductsService _productsService = productsService;

    [HttpGet]
	public async Task<ICollection<ProductOutputModel>> Get([FromQuery]ProductsFilter filter)
	{
		return await _productsService.Get(filter);
	}

	[HttpPost]
	public async Task<ProductOutputModel> Create([FromForm] ProductCreateModel product)
	{
		return await _productsService.Create(product);
	}

	[HttpDelete]
	public async Task Delete(Guid id)
	{
		await _productsService.Delete(id);
	}
}