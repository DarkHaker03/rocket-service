
namespace Application.Features.Products.Models;

public class ReceivedProductCellModel
{
	public required long Quantity { get; set; }

	public required Guid CellId { get; set; }
}
