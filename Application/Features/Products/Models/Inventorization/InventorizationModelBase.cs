namespace Application.Features.Products.Models.Inventorization;

public class InventorizationModelBase
{
    public required long ActualQuantity { get; set; }

    public required long UndefiendQuantity { get; set; }
    

    public required long Quantity { get; set; }
}
