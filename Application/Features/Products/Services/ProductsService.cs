using Application.Base.Extensions;
using Application.Base.Services;
using Application.Features.Auth.Services;
using Application.Features.Files.Services;
using Application.Features.Products.Filters;
using Application.Features.Products.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Data;
using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Products.Services;

public class ProductsService(UWDbContext dbContext, UserIdentity userIdentity, FilesService filesService, IMapper mapper) : BaseDbService(dbContext)
{

	private readonly UserIdentity _userIdentity = userIdentity;
	private readonly FilesService _filesService = filesService;
	private readonly IMapper _mapper = mapper;

	public async Task<ICollection<ProductOutputModel>> Get(ProductsFilter? filter)
	{
		var products = MasterDbContext.Products
			.UnionSearch(q => q.Article, filter?.SearchText)
			.UnionSearch(q => q.Color, filter?.SearchText)
			.Search(q => q.Name, filter?.SearchText)
			.GroupJoin(MasterDbContext.ReceivedProducts, q => q.Id,
			q => q.ProductId, (p, rp) => new ProductOutputModel()
			{
				Id = p.Id,
				ObjectCreateDate = p.ObjectCreateDate,
				Name = p.Name,
				Article = p.Article,
				Color = p.Color,
				Images = MasterDbContext.ImageProductLinks.Where(q => q.ProductId == p.Id).Select(q => _filesService.GetFileLink(q.Image.Name)).ToArray(),
				Quantity = rp.Sum(q => q.Quantity)
			})
			.ApplyCollectionFilter(filter);
		
			return await products.ToListAsync();
	}

	public async Task<ICollection<UwReceivedProduct>> GetReceived(ProductsFilter? filter)
	{
		return await MasterDbContext.ReceivedProducts.ApplyCollectionFilter(filter).ToListAsync();
	}

	public async Task<UwReceivedProduct?> GetReceived(Guid receivedProductId)
	{
		return await MasterDbContext.ReceivedProducts.FirstOrDefaultAsync(q => q.Id == receivedProductId);
	}

	public async Task<ProductOutputModel> Create(ProductCreateModel product)
	{
		var productEntity = new UwProduct
		{
			Name = product.Name,
			Article = product.Article,
			Color = product.Color,
		};
		
		var image = new UwImage
		{
			Name = await _filesService.Write(product.File)
		};

		var imageProductLink = new UwImageProductLink
		{
			Image = image,
			Product = productEntity
		};
		
		await MasterDbContext.AddAsync(image);
		await MasterDbContext.AddAsync(productEntity);
		await MasterDbContext.AddAsync(imageProductLink);
        await MasterDbContext.SaveChangesAsync();

	
        return _mapper.Map<ProductOutputModel>((new List<UwImage>(){image}, productEntity));
    }

	public async Task<ICollection<UwReceivedProduct>> AddReceivedProducts(ICollection<AddReceivedProductRequest> models, Guid warehouseId)
	{

		var wayBills = MasterDbContext.Bills
			.Where(q => q.Type == BillType.Way)
			.Where(q => models.Select(q => q.WayBillId).Contains(q.Id)).AsEnumerable();

		var receivedProductsResult = from wb in wayBills
									 join m in models on wb.Id equals m.WayBillId
									 select new
									 {
										 ReceivedProduct = new UwReceivedProduct()
										 {
											 ProductId = m.ProductId,
											 OwnerId = wb.OwnerId,
											 Quantity = m.ActualQuantity,
											 Cells = m.Cells.Select(q => new UwReceivedProductCell()
											 {
												 CellId = q.CellId,
												 Quantity = q.Quantity
											 }).ToList()
										 },
										 QuantityEquality = m.ActualQuantity == wb.Quantity
									 };
											
		foreach (var item in receivedProductsResult)
		{
			if (!item.QuantityEquality)
			{
				throw new Exception("TODO");
			}
		}

		var recievedProducts = receivedProductsResult.Select(q => q.ReceivedProduct);

		await MasterDbContext.ReceivedProducts.AddRangeAsync(recievedProducts);
		
		await MasterDbContext.SaveChangesAsync();

		return recievedProducts.ToList();
	}

	public async Task ChangeCellPlace(Guid receievdCellId, Guid cellId)
	{
		var cell = await MasterDbContext.ReceivedProductCells.FirstOrDefaultAsync(q => q.Id == receievdCellId);
		cell.ThrowIfNull();

		cell!.CellId = cellId;

		MasterDbContext.Update(cell);
		await MasterDbContext.SaveChangesAsync();
	}
	
	public async Task Delete(Guid id)
	{
		var product = await MasterDbContext.Products.FirstOrDefaultAsync(q => q.Id == id);
		   
		product.ThrowIfNull();

		MasterDbContext.Remove(product!);
		await MasterDbContext.SaveChangesAsync();
	}

	public async Task WriteOff(Guid receivedProductCellId, long quantity, Guid actionTypeId)
	{

		var receivedProductCell = await MasterDbContext.ReceivedProductCells.FirstAsync(q => q.Id == receivedProductCellId);


		if (receivedProductCell.Quantity < quantity)
		{
			throw new Exception("Вы не можете списать больше товара, чем его есть в базе данных");
		}
		
		receivedProductCell.Quantity -= quantity;
		
		var action = new UwProductCellAction
		{
			ObjectCreateDate = DateTime.UtcNow,
			ActionTime = DateTime.UtcNow,
			TypeId = actionTypeId, //TODO
			EmployeeId = _userIdentity.EmployeeId,
			ReceivedProductCellId = receivedProductCellId,
		};
		
		await MasterDbContext.AddAsync(action);
		MasterDbContext.Update(receivedProductCell);
		await MasterDbContext.SaveChangesAsync();
	}

	public async Task Ship(ICollection<ShipmentModel> models, Guid billId)
	{


		var bill = await MasterDbContext.Bills
			.Include(q => q.ProductsBills)
			.FirstOrDefaultAsync(q => q.Id == billId);
			
		
		
		var receivedProducts = await (from rp in MasterDbContext.ReceivedProducts
			join m in models on rp.Id equals m.ReceivedProductId
			select new {ReceivedProduct = rp ,ShipModel = m}).ToListAsync();

		var productBills = from pb in bill.ProductsBills
			join rp in receivedProducts on pb.ProductId equals rp.ReceivedProduct.ProductId
			select new UwProductBill
			{
				Id = pb.Id,
				ObjectCreateDate = pb.ObjectCreateDate,
				Quantity = pb.Quantity,
				ActualQuantity = rp.ShipModel.Quantity,
				ProductId = pb.ProductId,
				Product = pb.Product,
				BillId = pb.BillId,
				Bill = pb.Bill,
				Barcode = pb.Barcode
			};

		var updatedReceivedProducts = from rp in receivedProducts
			join m in models on rp.ReceivedProduct.Id equals m.ReceivedProductId
			select new UwReceivedProduct
			{
				Id = rp.ReceivedProduct.Id,
				ObjectCreateDate = rp.ReceivedProduct.ObjectCreateDate,
				ProductId = rp.ReceivedProduct.ProductId,
				Product = rp.ReceivedProduct.Product,
				OwnerId = rp.ReceivedProduct.OwnerId,
				Owner = rp.ReceivedProduct.Owner,
				Quantity = rp.ReceivedProduct.Quantity - m.Quantity,
				Cells = rp.ReceivedProduct.Cells,
				WarehouseId = rp.ReceivedProduct.WarehouseId,
				Warehouse = rp.ReceivedProduct.Warehouse
			};
		
		if (updatedReceivedProducts.Any(q => q.Quantity < 0))
		{
			throw new Exception("TODO");
		}
		
		var productsToRemove = updatedReceivedProducts.Where(q => q.Quantity == 0);
		var productsToUpdate = updatedReceivedProducts.Except(productsToRemove);
		
		MasterDbContext.RemoveRange(productsToRemove);
		MasterDbContext.Update(productsToUpdate);
		await MasterDbContext.SaveChangesAsync();

	}
}