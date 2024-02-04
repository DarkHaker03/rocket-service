using Domain.Base.Classes;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Entities;

/// <summary>
/// Принятый товар в ячейке склада
/// </summary>
[Table("uw_received_product_cell")]
public class UwReceivedProductCell : BaseEntity<UwReceivedProductCell>
{
	/// <summary>
	/// Идентификатор места хранения 
	/// </summary>
	public Guid CellId { get; set; }

	/// <summary>
	/// Место хранения 
	/// </summary>
	public UwCell Cell { get;set; } = null!;

	/// <summary>
	/// Идентификатор товара в ячейке
	/// </summary>
	public Guid ReceivedProductId { get; set; }

	/// <summary>
	/// Товар в ячейке
	/// </summary>
	public UwReceivedProduct? ReceivedProduct { get; set; } = null!;

	/// <summary>
	/// Количество товара
	/// </summary>
	public required long Quantity { get; set; }

	public virtual ICollection<UwBasketReceivedProductLink> BasketReceivedProductLinks { get; set; } = null!;

	protected override void Configure(EntityTypeBuilder<UwReceivedProductCell> builder)
	{
		builder.HasOne(q => q.Cell)
			.WithMany(q => q.ProductCells);

		builder.HasOne(q => q.ReceivedProduct)
			.WithMany(q => q.Cells);

		builder.HasMany(q => q.BasketReceivedProductLinks)
			.WithOne(q => q.ReceivedProductCell);
		
		base.Configure(builder);
	}
}