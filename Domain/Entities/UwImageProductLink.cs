using System.ComponentModel.DataAnnotations.Schema;
using Domain.Base.Classes;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Entities;

[Table("uw_image_product_link")]
public class UwImageProductLink : BaseEntity<UwImageProductLink>
{
    public Guid ImageId { get; set; }
    public UwImage Image { get; set; } = null!; 
    public Guid ProductId { get; set; }
    public UwProduct Product { get; set; } = null!;

    protected override void Configure(EntityTypeBuilder<UwImageProductLink> builder)
    {
        builder.HasOne(q => q.Image)
            .WithMany(q => q.ImageProductLinks);

        builder.HasOne(q => q.Product)
            .WithMany(q => q.ImageLinks);
        
        base.Configure(builder);
    }
}
