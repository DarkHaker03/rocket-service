namespace Application.Features.Bills.Models;

public class ProductBillModel
{
    public required Guid ProductId { get; set; }
    
    public required long Quantity { get; set; }
    
    public required string Barcode { get; set; }
}