using Microsoft.AspNetCore.Http;

namespace Application.Features.Products.Models;

public class ProductCreateModel
{
    public string Name { get; set; }

    public string Article { get; set; }

    public string Color { get; set; }

    public IFormFile File { get; set; }
}
