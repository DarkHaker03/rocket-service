using Domain.Base.Classes;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Entities;

[Table("uw_user")]
public class RUser : BaseEntity<RUser>
{
	/// <summary>
	/// Имя
	/// </summary>
	public string? Name { get; set; }

	/// <summary>
	/// Почта
	/// </summary>
	public required string Email { get; set; }
	
	public Guid? ImageId { get; set; }
	
	public  RImage? Image { get; set; } = null!;

	/// <summary>
	/// Пароль
	/// </summary>
	public required string Password { get; set; }

	/// <summary>
	/// Номер телефона
	/// </summary>
	public string? Telephone { get; set; }

	/// <summary>
	/// Логин
	/// </summary>
    public string? Login { get; set; }

	/// <summary>
	/// Контакты в любом формате
	/// </summary>
	public string? OtherContacts { get; set; }
	
	protected override void ConfigureIndexes(EntityTypeBuilder<RUser> builder)
	{
		builder
			.HasIndex(q => q.Email)
			.IsUnique();
		base.ConfigureIndexes(builder);
	}
}
 