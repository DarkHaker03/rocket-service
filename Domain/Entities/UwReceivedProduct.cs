
using Domain.Base.Classes;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Entities;

/// <summary>
/// Принятый товар
/// </summary>
[Table("uw_received_product")]
public class UwReceivedProduct : BaseEntity<UwReceivedProduct>
{
	
	public string Barcode { get; set; }
	/// <summary>
	/// Идентификатор товара
	/// </summary>
	public Guid ProductId { get; set; }

	/// <summary>
	/// Товар
	/// </summary>
	public UwProduct Product { get; set; } = null!;
	
	/// <summary>
	/// Идентификатор владельца
	/// </summary>
	public Guid OwnerId { get; set; }

	/// <summary>
	/// Владелец товара
	/// </summary>
	public UwUser Owner { get; set; } = null!;

	/// <summary>
	/// Количество товара
	/// </summary>
	public long Quantity { get; set; }

	/// <summary>
	/// Ячейки, в которых находится товар
	/// </summary>
	public virtual IEnumerable<UwReceivedProductCell>? Cells { get; set; } =  null!;
	
	/// <summary>
	/// Идентификатор склада
	/// </summary>
	public Guid WarehouseId { get; set; } 

	/// <summary>
	/// Склад
	/// </summary>
	public UwWarehouse Warehouse { get; set; } = null!;

	protected override void Configure(EntityTypeBuilder<UwReceivedProduct> builder)
	{
		builder.HasMany(q => q.Cells)
			.WithOne(q => q.ReceivedProduct);

		builder.HasOne(q => q.Product)
			.WithMany(q => q.ReceivedProducts);
		

		builder.HasOne(q => q.Warehouse)
			.WithMany(q => q.ReceivedProducts);

		builder.HasOne(q => q.Owner)
			.WithMany(q => q.ReceivedProducts);
		
		base.Configure(builder);
	}
}