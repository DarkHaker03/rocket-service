using Domain.Base.Classes;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Entities;

/// <summary>
/// Машина с товаром
/// </summary>
[Table("uw_car")]
public class UwCar : BaseEntity<UwCar>
{
	/// <summary>
	/// Текстовая заметка
	/// </summary>
	public required string Note { get; set; }
	
	public virtual ICollection<UwBill> Bills { get; set; } = null!;

	protected override void Configure(EntityTypeBuilder<UwCar> builder)
	{
		
		builder.HasMany(q => q.Bills)
			.WithOne(q => q.Car);
		
		base.Configure(builder);
	}
}
