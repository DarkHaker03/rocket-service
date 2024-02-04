using Application.Base.Extensions;
using Application.Base.Services;
using Application.Features.Warehouse.Filters;
using Application.Features.Warehouse.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Data;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Warehouse.Services;

public class StorageService(UWDbContext db, IMapper mapper) : BaseDbService(db)
{
	IMapper _mapper = mapper;

	public async Task<ICollection<StoragePlaceModel>> GetStorageCells(StoragePlaceFilter? filter, Guid warehouseId)
	{
		return await MasterDbContext.Cells
			.Where(q => q.WarehouseId == warehouseId)
			.ApplyCollectionFilter(filter)
			.ProjectTo<StoragePlaceModel>(_mapper.ConfigurationProvider)
			.ToListAsync();
	}

	public async Task CreateStorageCell(CreateStoragePlaceRequest model)
	{
		var entity = _mapper.Map<UwCell>(model);
		await MasterDbContext.AddAsync(entity);
		await MasterDbContext.SaveChangesAsync();
	}
}
