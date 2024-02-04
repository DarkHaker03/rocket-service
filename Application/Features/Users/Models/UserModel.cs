namespace Application.Features.Users.Models;

public class UserModel
{
	public string Name { get; set; }
	
	public string Email { get; set; }

	public string Image { get; set; }
	
	public Guid Id { get; set; }

	public Guid? EmployeeId { get; set; }
}
