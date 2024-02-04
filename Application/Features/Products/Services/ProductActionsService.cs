using Application.Base.Extensions;
using Application.Base.Services;
using Application.Features.Auth.Services;
using Application.Features.Products.Filters;
using Data;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Products.Services
{
	public class ProductActionsService(UWDbContext dbContext, UserIdentity userIdentity) : BaseDbService(dbContext)
	{
		private readonly UserIdentity _userIdentity = userIdentity;
		
		public async Task AddAction(Guid receivedProductCellId, Guid actionTypeId)
		{
			var employee = await MasterDbContext.Employees.FirstOrDefaultAsync(q => q.UserId == _userIdentity.UserId)
				?? throw new NullReferenceException("У вас нет прав доступа к запрашиваемому ресурсу");
			
			var action = new UwProductCellAction()
			{
				EmployeeId = employee!.Id,
				ActionTime = DateTime.UtcNow,
				ReceivedProductCellId = receivedProductCellId,
				TypeId = actionTypeId
			};

			await MasterDbContext.AddAsync(action);
			await MasterDbContext.SaveChangesAsync();
		}
	
		public async Task<ICollection<UwProductCellAction>> GetActions(ProductActionsFilter filter)
		{
			return await MasterDbContext.ReceivedProductActions
				.Include(q => q.ReceivedProductCell)
				.ApplyCollectionFilter(filter).ToListAsync();
		}
	}
}
