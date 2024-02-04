using Application.Base.Extensions;
using Application.Base.Services;
using Application.Features.Products.Filters;
using Application.Features.Products.Models.Inventorization;
using Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Application.Features.Products.Services;

public class ProductsInventorizationService(UWDbContext dbContext) : BaseDbService(dbContext)
{
	public async Task<WarehouseInventorizationModel> InventorizeWarehouse(Guid warehouseId)
	{
		var warehouse = await MasterDbContext.Warehouses.FirstOrDefaultAsync(q => q.Id ==  warehouseId);

		var produtcsInvertarization = InventorizeProductsInternal(new InventorizationFilter()
		{
			WarehouseId = warehouseId
		});

		return new WarehouseInventorizationModel()
		{
			ActualQuantity = await produtcsInvertarization.SumAsync(q => q.ActualQuantity),
			WarehouseId = warehouse.Id,
			WarehouseName = warehouse.Name,
			Quantity = await produtcsInvertarization.SumAsync(q => q.Quantity),
			UndefiendQuantity = await produtcsInvertarization.SumAsync(q => q.UndefiendQuantity)
		};
	}

	public async Task<ClientInventorizationModel> InventorizeClient(Guid clientId)
	{
		var client = await MasterDbContext.Users.FirstOrDefaultAsync(q => q.Id == clientId);

		var produtcsInvertarization = InventorizeProductsInternal(new InventorizationFilter()
		{
			ClientId = clientId
		});

		return new ClientInventorizationModel()
		{
			ActualQuantity = await produtcsInvertarization.SumAsync(q => q.ActualQuantity),
			ClientId = clientId,
			Email = client.Email,
			Quantity = await produtcsInvertarization.SumAsync(q => q.Quantity),
			UndefiendQuantity = await produtcsInvertarization.SumAsync(q => q.UndefiendQuantity)
		};
	}

	public async  Task<IEnumerable<ProductInventorizationModel>> InventorizeProducts(InventorizationFilter? filter)
	{
		return await InventorizeProductsInternal(filter).ToListAsync();
	}

	private IQueryable<ProductInventorizationModel> InventorizeProductsInternal(InventorizationFilter? filter = null)
	{
		var products = MasterDbContext.Products
				.FilterIfNotNull(q => q.Id == filter!.ProductId, filter?.ProductId);

		var receivedProducts = MasterDbContext.ReceivedProducts
				.FilterIfNotNull(q => q.WarehouseId == filter!.WarehouseId, filter?.WarehouseId)
				.FilterIfNotNull(q => q.OwnerId == filter!.ClientId, filter?.ClientId)
				.FilterIfNotNull(q => q.ProductId == filter!.ProductId, filter?.ProductId);

		var bills = MasterDbContext.Bills
			.FilterIfNotNull(q => q.WarehouseId == filter!.WarehouseId, filter?.WarehouseId)
			.FilterIfNotNull(q => q.OwnerId == filter!.ClientId, filter?.ClientId);
			//.FilterIfNotNull(q => q.ProductWays.Any(x => x.ProductId == filter!.ProductId), filter?.ProductId); //TODO
			
			


		return products.Select(p => new ProductInventorizationModel
		{
			Product = p,
			ActualQuantity = receivedProducts.Sum(q => q.Quantity),
			Quantity = receivedProducts.Sum(q => q.Quantity) +
			           bills.Sum(q => q.Quantity),
			UndefiendQuantity = bills.Sum(q => q.Quantity)
		});

	}

	public async Task<IEnumerable<ClientInventorizationModel>> InvertorizeClients(ClientsInvertarizationFilter? filter)
	{
		var clients = from u in MasterDbContext.Users
					  from e in MasterDbContext.Employees.Where(q => q.UserId == u.Id).DefaultIfEmpty()
					  where e == null
					  select u;

		var receivedProducts = MasterDbContext.ReceivedProducts;

		var bills = MasterDbContext.Bills;

		

		return await clients.Select(c => new ClientInventorizationModel
		{
			ClientId = c.Id,
			Email = c.Email,
			ActualQuantity = receivedProducts.Where(q => q.OwnerId == c.Id).Sum(q => q.Quantity),
			Quantity = receivedProducts.Where(q => q.OwnerId == c.Id).Sum(q => q.Quantity) +
			           bills.Where(q => q.OwnerId == c.Id).Sum(q => q.Quantity),
			UndefiendQuantity = bills.Where(q => q.OwnerId == c.Id).Sum(q => q.Quantity),
		}).ToListAsync();



	}
}
