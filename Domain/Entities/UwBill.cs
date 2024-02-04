using Domain.Base.Classes;
using Domain.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Entities;

/// <summary>
/// Отходная накладная
/// </summary>
[Table("uw_bill")]
public class UwBill : BaseEntity<UwBill>
{
	/// <summary>
	/// Количество товара
	/// </summary>
	public required long Quantity { get; set; }
	
	public ICollection<UwProductBill> ProductsBills { get; set; }

	/// <summary>
	/// Идентификатор пользователя владельца товара
	/// </summary>
	public required Guid OwnerId { get; set; }

	/// <summary>
	/// Владелец товара
	/// </summary>
	public UwUser? Owner { get; set; }

	/// <summary>
	/// Идентификатор машины, увозящей товар
	/// </summary>
	public Guid? CarId { get; set; }

	/// <summary>
	/// Машина, увозящая товар
	/// </summary>
	public UwCar? Car { get; set; } 

	/// <summary>
	/// Идентификатор склада, с которого увозят товар
	/// </summary>
	public required Guid WarehouseId { get; set; }
	
	/// <summary>
	/// Текстовая заметка
	/// </summary>
	public string  Note { get; set; }

	/// <summary>
	/// Склад, с которого уходит товар
	/// </summary>
	public UwWarehouse Warehouse { get; set; } = null!;
	
	/// <summary>
	/// Адрес назначения товара
	/// </summary>
	public required string Address { get; set; }

	/// <summary>
	/// Запланированное время отъезда машины
	/// </summary>
	public DateTime? RealizationDate { get; set; }

	/// <summary>
	/// Фактическое время отъезда машины
	/// </summary>
	public DateTime? ActualRealizationDate { get; set; }

	public required BillStatus Status { get; set; }
	public required BillType Type { get; set; }

	/// <summary>
	/// Номер  накладной
	/// </summary>
	public ulong Number { get; set; }
	
	protected override void ConfigureIndexes(EntityTypeBuilder<UwBill> builder)
	{
		builder.HasIndex(q => q.Number)
			.IsUnique();
		base.ConfigureIndexes(builder);
	}

	protected override void Configure(EntityTypeBuilder<UwBill> builder)
	{
		builder.HasMany(q => q.ProductsBills)
			.WithOne(q => q.Bill);

		builder.HasOne(q => q.Owner)
			.WithMany(q => q.Bills);

		builder.HasOne(q => q.Car)
			.WithMany(q => q.Bills);

		builder.HasOne(q => q.Warehouse)
			.WithMany(q => q.WasteBills);
		
		base.Configure(builder);
	}
}
