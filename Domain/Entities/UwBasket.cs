using Domain.Base.Classes;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Entities;

[Table("uw_basket")]
public class UwBasket : BaseEntity<UwBasket>
{
	/// <summary>
	/// Баркод ячейки склада
	/// </summary>
	public required string Barcode { get; set; } 

	/// <summary>
	/// Место нахождения ячейки
	/// </summary>
	public required string Cell { get; set; }

	public virtual ICollection<UwBasketReceivedProductLink> ProductLinks { get; set; } = null!;
	protected override void Configure(EntityTypeBuilder<UwBasket> builder)
	{
		builder.HasMany(q => q.ProductLinks)
			.WithOne(q => q.Basket);
		
		base.Configure(builder);
	}
}
