using Domain.Base.Classes;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Entities;

/// <summary>
/// Склад
/// </summary>
[Table("uw_warehouse")]
public class UwWarehouse : BaseEntity<UwWarehouse>
{
	/// <summary>
	/// Название склада
	/// </summary>
	public string? Name { get; set; }

	/// <summary>
	/// Адрес склада
	/// </summary>
	public required string Address { get; set; }

	/// <summary>
	/// Страна, в которой находится склад
	/// </summary>
	public required string Country { get; set; }

	public required string Subject { get; set; }

	/// <summary>
	/// Город, в котором находится склад
	/// </summary>
	public required string City { get; set; }

	/// <summary>
	/// Название улицы, на которой находится склад
	/// </summary>
	public required string Street { get; set; }

	/// <summary>
	/// Номер дома
	/// </summary>
	public required string House { get; set; }

	/// <summary>
	/// Координаты
	/// </summary>
	public string? Coordinates { get; set; }

	public virtual ICollection<UwReceivedProduct> ReceivedProducts { get; set; } = null!;
	public virtual ICollection<UwEmployee> Employees { get; set; } = null!;
	public virtual ICollection<UwCell> Cells { get; set; } = null!;
	public virtual ICollection<UwBill> WasteBills { get; set; } = null!;

	protected override void Configure(EntityTypeBuilder<UwWarehouse> builder)
	{
		builder.HasMany(q => q.WasteBills)
			.WithOne(q => q.Warehouse);

		builder.HasMany(q => q.Cells)
			.WithOne(q => q.Warehouse);

		builder.HasMany(q => q.WasteBills)
			.WithOne(q => q.Warehouse);
		

		builder.HasMany(q => q.Employees)
			.WithOne(q => q.Warehouse);
		
		base.Configure(builder);
	}
}
