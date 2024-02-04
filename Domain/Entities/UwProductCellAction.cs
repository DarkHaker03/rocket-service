using Domain.Base.Classes;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Entities;

/// <summary>
/// Действие над принятым товаром
/// </summary>
[Table("uw_received_product_action")]
public class UwProductCellAction : BaseEntity<UwProductCellAction>
{
	/// <summary>
	/// Время, когда произошло действие
	/// </summary>
	public required DateTime ActionTime { get; set; }

	/// <summary>
	/// Идентификатор типа действия
	/// </summary>
	public Guid TypeId { get; set; }

	/// <summary>
	/// Тип действия
	/// </summary>
	public UwActionType Type { get; set; } = null!;

	/// <summary>
	/// Идентификатор сотрудника, совершившего действие
	/// </summary>
	public required Guid EmployeeId { get; set; }

	/// <summary>
	/// Сотрудник совершивший действие
	/// </summary>
	public UwEmployee Employee { get; set; } = null!;
	
	/// <summary>
	/// Идентификатор товара
	/// </summary>
	public required Guid ReceivedProductCellId { get; set; }

	/// <summary>
	/// Товар
	/// </summary>
	public UwReceivedProductCell ReceivedProductCell { get; set; } = null!;

	protected override void Configure(EntityTypeBuilder<UwProductCellAction> builder)
	{
		builder.HasOne(q => q.Type)
			.WithMany(q => q.ProductActions);

		builder.HasOne(q => q.Employee)
			.WithMany(q => q.ProductActions);
		
		base.Configure(builder);
	}
}
