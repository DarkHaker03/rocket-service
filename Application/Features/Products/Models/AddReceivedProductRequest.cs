

namespace Application.Features.Products.Models;

public class AddReceivedProductRequest
{
	public required Guid WayBillId { get; set; }

	public required long ActualQuantity { get; set; }

	public required Guid ProductId { get; set; }
	public required ICollection<ReceivedProductCellModel> Cells { get; set; }
}
