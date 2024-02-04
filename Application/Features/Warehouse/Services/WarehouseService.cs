using Application.Base.Extensions;
using Application.Base.Services;
using Application.Features.Warehouse.Filters;
using Application.Features.Warehouse.Models;
using Data;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Warehouse.Services;

public class WarehouseService(UWDbContext db) : BaseDbService(db)
{
	public async Task<UwWarehouse?> Get(Guid id) => await MasterDbContext.Warehouses.FirstOrDefaultAsync(q => q.Id == id);

	public async Task<ICollection<UwWarehouse>> GetRange(WarehouseFilter filters)
	{
		return await MasterDbContext.Warehouses
			.ApplyCollectionFilter(filters)
			.ToListAsync();
	}

	public async Task Add(UwWarehouse entity)
	{
		await MasterDbContext.Warehouses.AddAsync(entity);
		await MasterDbContext.SaveChangesAsync();
	}

	public async Task Delete(Guid id)
	{
		var entity = await Get(id).ThrowIfNull() ;

		MasterDbContext.Warehouses.Remove(entity);
		await MasterDbContext.SaveChangesAsync();
	}

}