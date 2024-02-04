using Domain.Base.Classes;
using Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Entities;

[Table("uw_cell")]
public class UwCell : BaseEntity<UwCell>
{
	public string Place { get; set; }
	public string Name { get; set; }

	public string Description { get; set; } = "";
	public Guid CreatedByEmployeeId { get; set; }

	public StoragePlaceStatus Status { get; set; }
	public UwEmployee CreatedByEmployee { get; set; } = null!;

	/// <summary>
	/// Идентификатор склада
	/// </summary>
	public Guid WarehouseId { get; set; }

	/// <summary>
	/// Склад
	/// </summary>
	public UwWarehouse Warehouse { get; set; } = null!;

	public virtual IEnumerable<UwReceivedProductCell> ProductCells { set; get; } = null!;

	public Guid StageId { get; set; }
	
	public UwProductStage Stage { get; set; }
	
	protected override void Configure(EntityTypeBuilder<UwCell> builder)
	{
		builder.HasMany(q => q.ProductCells)
			.WithOne(q => q.Cell);
		
		base.Configure(builder);
	}
}
