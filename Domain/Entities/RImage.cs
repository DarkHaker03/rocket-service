using System.ComponentModel.DataAnnotations.Schema;
using Domain.Base.Classes;

namespace Domain.Entities;

[Table("uw_images")]
public class RImage : BaseEntity<RImage>
{
    public required string Name { get; set; }
}
