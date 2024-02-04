using Domain.Base.Classes;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Entities;

/// <summary>
/// Тип действия над товаром
/// </summary>
[Table("uw_action_type")]
public class UwActionType : BaseEntity<UwActionType>
{
	/// <summary>
	/// Тип действия над товаром
	/// </summary>
	public required string Type { get; set; }

	public virtual ICollection<UwProductCellAction> ProductActions { get; set; } = null!;

	protected override void Configure(EntityTypeBuilder<UwActionType> builder)
	{
		builder.HasMany(q => q.ProductActions)
			.WithOne(q => q.Type);
		
		base.Configure(builder);
	}
}
