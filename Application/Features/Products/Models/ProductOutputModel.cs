using Domain.Entities;

namespace Application.Features.Products.Models;

public class ProductOutputModel : UwProduct
{
    public string[] Images { get; set; }
    
    public long Quantity { get; set; }
}