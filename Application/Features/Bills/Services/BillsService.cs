using Application.Base.Extensions;
using Application.Base.Services;
using Application.Features.Auth.Services;
using Application.Features.Bills.Filters;
using Application.Features.Bills.Models;
using Application.Features.Documents.Model;
using Application.Features.Documents.Model.Bills;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Data;
using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Application.Features.Bills.Services;

public class BillsService(UWDbContext dbContext, UserIdentity userIdentity, IMapper mapper) : BaseDbService(dbContext)
{
	private readonly UserIdentity _userIdentity = userIdentity;
	private readonly IMapper _mapper = mapper;

	public async Task<UwBill> CreateBill(CreateBillModel billModel)
	{
		var bill = _mapper.Map<UwBill>(billModel);

		bill.Quantity = bill.ProductsBills.Sum(q => q.Quantity);
		bill.OwnerId = _userIdentity.UserId;
		bill.RealizationDate = DateTime.UtcNow;

		await MasterDbContext.Bills.AddAsync(bill);
		await MasterDbContext.SaveChangesAsync();

		return bill;
	}
	
	public async Task<ICollection<UwBill>> GetBills(BillsFilter? filter)
	{
		var query = MasterDbContext.Bills
			.FilterIfNotNull(q => q.Status == filter!.Status, filter?.Status);

		if (!_userIdentity.IsEmployee)
		{
			query = query.Where(q => q.OwnerId == _userIdentity.UserId);
		}


		return await query.ApplyCollectionFilter(filter).ToListAsync();
	}
	
	public async Task DeleteBill(Guid id)
	{
		var bill = await MasterDbContext.Bills.FirstOrDefaultAsync(q => q.Id == id);
		MasterDbContext.Bills.Remove(bill!);
		await MasterDbContext.SaveChangesAsync();
	}

	/// <summary>
	/// Добавить приходную накладную из xlsx файла
	/// </summary>
	/// <param name="rows">строки excel таблицы</param>
	/// <param name="data">информация по накладной</param>
	/// <param name="userId">id владельца товаров - null, если владелец текущий юзер</param>
	/// <returns></returns>
	public async Task<UwBill> AddFromExcel(ICollection<ExcelBillModel> rows , CreateBillFromExcel data, Guid? userId = null)
	{
		rows.ThrowIfNullOrEmpty("Таблица не может быть пустой");
		
		var productBills = await (from p in MasterDbContext.Products
					   join r in rows on p.Article equals r.Article
					   select new UwProductBill()
					   {
						   Quantity = r.Quantity,
						   ProductId = p.Id
					   }).ToListAsync();

		var bill = new UwBill
		{
			Status = Domain.Enums.BillStatus.New,
			RealizationDate = data.RealizeDate,
			Note = data.Note,
			OwnerId = userId ?? _userIdentity.UserId,
			Quantity = productBills.Sum(pw => pw.Quantity),
			WarehouseId = data.WarehouseId,
			ProductsBills = productBills,
			Address = null,
			Type = data.Type
		};
		
		await MasterDbContext.AddAsync(bill);
		await MasterDbContext.AddRangeAsync(productBills);
		await MasterDbContext.SaveChangesAsync();

		return bill;
	}
	
	
	public async Task<IEnumerable<ExcelBillModel>> GetExcelBillModels(BillsFilter? filter)
	{
		return await MasterDbContext.Bills
			//.Include(q => q.Product)
			.FilterIfTrue(q => q.OwnerId == _userIdentity.UserId, !_userIdentity.IsEmployee)
			.FilterIfNotNull(q => q.Status == filter!.Status, filter?.Status)
			.FilterIfNotNull(q => q.Id == filter!.BillId, filter?.BillId)
			.ApplyCollectionFilter(filter)
			.ProjectTo<ExcelBillModel>(_mapper.ConfigurationProvider)
			.ToListAsync();
	}
	
	public async Task<DocxBillModel> GetBillDocxModel(Guid billId, Guid? userId = null)
	{
		var bill = await MasterDbContext.Bills
			.Include(q => q.Owner)
			.Where(q => q.OwnerId == (userId ?? _userIdentity.UserId))
			.FirstOrDefaultAsync(q => q.Id == billId);

		if (bill == null)
		{
			throw new NullReferenceException("Накладная не найдена");
		}

		return new DocxBillModel()
		{
			BillNumber = bill.Number.ToString(),
			CompanyInn = "560405266674", //TODO
			CompanyName = "ИП Лабусов Александр Витальевич",
			Products =  new List<UwProduct>(),//wayBill.ProductWays.Select(q => q.Product), //TODO
			UserName =  bill.Owner.Name
		};
	}
	
	public async Task<UwBill> ChangeBillStatus(Guid billId, BillStatus status)
	{
		var bill = await MasterDbContext.Bills
			.FirstOrDefaultAsync(q => q.Id == billId);

		if (bill == null)
		{
			throw new NullReferenceException("Накладная не найдена");
		}

		bill.Status = status;

		MasterDbContext.Update(bill);
		await MasterDbContext.SaveChangesAsync();
		
		return bill;
	}
	
	
}
