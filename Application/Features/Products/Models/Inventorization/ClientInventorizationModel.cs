
namespace Application.Features.Products.Models.Inventorization;

public class ClientInventorizationModel : InventorizationModelBase
{
	public required string Email { get; set; }

	public required Guid ClientId { get; set; }
}
