using Domain.Base.Classes;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Entities;

[Table("uw_user")]
public class UwUser : BaseEntity<UwUser>
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
	
	public  UwImage? Image { get; set; } = null!;

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
	
	public virtual UwEmployee? Employee { get; set; }
	public virtual ICollection<UwReceivedProduct> ReceivedProducts { get; set; } = null!;
	public virtual ICollection<UwBill> Bills { get; set; } = null!;
	
	protected override void ConfigureIndexes(EntityTypeBuilder<UwUser> builder)
	{
		builder
			.HasIndex(q => q.Email)
			.IsUnique();
		base.ConfigureIndexes(builder);
	}

	protected override void Configure(EntityTypeBuilder<UwUser> builder)
	{
		builder.HasOne(q => q.Employee)
			.WithOne(q => q.User);

		builder.HasMany(q => q.ReceivedProducts)
			.WithOne(q => q.Owner);

		builder.HasMany(q => q.Bills)
			.WithOne(q => q.Owner);
		
		
		base.Configure(builder);
	}
}
 