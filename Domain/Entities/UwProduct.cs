using Domain.Base.Classes;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Entities;

/// <summary>
/// Товар
/// </summary>
[Table("uw_product")]
public class UwProduct : BaseEntity<UwProduct>
{
	/// <summary>UwProduct
	/// Наименование товара
	/// </summary>
	public required string Name { get; set; }

	/// <summary>
	/// Артикль товара
	/// </summary>
	public string Article { get; set; }

	/// <summary>
	/// Цвет товара
	/// </summary>
	public string? Color { get; set; }
	
	public virtual ICollection<UwReceivedProduct> ReceivedProducts { get; set; } = null!;
	public virtual ICollection<UwImageProductLink> ImageLinks { get; set; }

	protected override void Configure(EntityTypeBuilder<UwProduct> builder)
	{
		builder.HasMany(q => q.ReceivedProducts)
			.WithOne(q => q.Product);

		builder.HasMany(q => q.ImageLinks)
			.WithOne(q => q.Product);
		
		base.Configure(builder);
	}
}