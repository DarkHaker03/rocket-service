
using Domain.Enums;

namespace Application.Features.Bills.Models;

public class CreateBillModel
{
	public required DateTime RealizeDate { get; set; }
	public Guid? CarId { get; set; }
	public required Guid WarehouseId { get; set; }
	
	public required BillType Type { get; set; }

	public string? Note { get; set; }
	
	public string? Address { get; set; }

	public IEnumerable<ProductBillModel> Products { get; set; } = new List<ProductBillModel>();
}
