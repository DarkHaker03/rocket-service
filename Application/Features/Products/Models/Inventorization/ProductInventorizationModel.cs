using Domain.Entities;

namespace Application.Features.Products.Models.Inventorization;

public class ProductInventorizationModel : InventorizationModelBase
{
    public UwProduct Product { get; set; }

}
