namespace Application.Features.Products.Models;

public class ShipmentModel
{
    public required Guid ReceivedProductId { get; set; }
    
    public required long Quantity { get; set; }
}