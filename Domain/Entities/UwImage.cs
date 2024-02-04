using System.ComponentModel.DataAnnotations.Schema;
using Domain.Base.Classes;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Entities;

[Table("uw_images")]
public class UwImage : BaseEntity<UwImage>
{
    public required string Name { get; set; }
    
    public virtual ICollection<UwImageProductLink> ImageProductLinks { get; set; } = null!;

    protected override void Configure(EntityTypeBuilder<UwImage> builder)
    {
        builder.HasMany(q => q.ImageProductLinks)
            .WithOne(q => q.Image);
        
        base.Configure(builder);
    }
}
