using Domain.Base.Classes;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Entities;

[Table("uw_product_stage")]
public class UwProductStage : BaseEntity<UwProductStage>
{
	public required string Stage { get; set; }

	public virtual ICollection<UwCell> Cells { get; set; }

	protected override void Configure(EntityTypeBuilder<UwProductStage> builder)
	{
		
		
		base.Configure(builder);
	}
}
