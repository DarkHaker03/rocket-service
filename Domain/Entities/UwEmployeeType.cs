using Domain.Base.Classes;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Entities;

/// <summary>
/// Тип сотрудника
/// </summary>
[Table("employee_type")]
public class UwEmployeeType : BaseEntity<UwEmployeeType>
{
    /// <summary>
    /// Тип
    /// </summary>
    public required string Type { get; set; }
    
    public virtual ICollection<UwEmployee> Employees { get; set; } = null!;

    protected override void Configure(EntityTypeBuilder<UwEmployeeType> builder)
    {
        builder.HasMany(q => q.Employees)
            .WithOne(q => q.Type);
        
        base.Configure(builder);
    }
}