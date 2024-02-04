using Domain.Base.Classes;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Entities;

/// <summary>
/// Сотрудник
/// </summary>
[Table("uw_employee")]
public class UwEmployee : BaseEntity<UwEmployee>
{
    /// <summary>
	/// Идентификатор типа сотрудника
	/// </summary>
    public required Guid TypeId { get; set; }

	/// <summary>
	/// Тип сотрудника
	/// </summary>
	public UwEmployeeType Type { get; set; } = null!;

	/// <summary>
	/// Идентификатор пользователя
	/// </summary>
	public required Guid UserId { get; set; }

	/// <summary>
	/// Пользователь
	/// </summary>
	public UwUser User { get; set; } = null!;

	/// <summary>
	/// Идентификатор склада, на котром работает сотрудник
	/// </summary>
	public required Guid WarehouseId { get; set; }

	/// <summary>
	/// Склад, на котором работает сотрудник
	/// </summary>
	public UwWarehouse Warehouse { get; set; } = null!;

	/// <summary>
	/// Расписание работы сотрудника
	/// </summary>
	public required string WortkSchedule { get; set; }

	public virtual ICollection<UwProductCellAction> ProductActions { get; set; } = null;

	protected override void Configure(EntityTypeBuilder<UwEmployee> builder)
	{
		builder.HasOne(q => q.Type)
			.WithMany(q => q.Employees);
		
		builder.HasOne(q => q.Warehouse)
			.WithMany(q => q.Employees);
		
		builder.HasOne(q => q.User)
			.WithOne(q => q.Employee);

		builder.HasMany(q => q.ProductActions)
			.WithOne(q => q.Employee);
		
		base.Configure(builder);
	}
}