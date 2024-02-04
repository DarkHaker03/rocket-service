using Application.Base.Interfaces;
using Domain.Enums;

namespace Application.Features.Bills.Filters;

public class BillsFilter : ICollectionFilter
{
	public int? Skip { get ; set ; }
	public int? Take { get ; set ; }
	
	public BillStatus? Status { get; set; }
	public BillType? Type { get; set; }

	public Guid? BillId { get; set; }


	public Guid? UserId { get; set; }
}
