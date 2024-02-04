
namespace Application.Features.Products.Models;

public class ChangeReceivedProductCellRequest
{
	public required Guid CellId { get; set; }

	public required Guid ProductCellId { get; set; } 
}
