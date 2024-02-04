using Microsoft.AspNetCore.Http;

namespace Application.Features.Users.Models;

public class UpdateUserProfileModel
{
    public string? Name { get; set; }
    
    public string? Password { get; set; }
    
    public string? Email { get; set; }
    
    public IFormFile? Image { get; set; }
}
