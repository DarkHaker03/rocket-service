using System.ComponentModel;
using Domain.Base.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Base.Classes;

public class BaseEntity<TEntity> :  IEntityTypeConfiguration<TEntity>,IBaseHaveId, IBaseHaveObjectCreateData where TEntity : BaseEntity<TEntity>
{
    /// <summary>
    /// Идендификатор
    /// </summary>
    [DisplayName("Идендификатор")]
    public Guid Id { get; set; }

    /// <summary>
    /// Дата и время создания объекта
    /// </summary>
    [DisplayName("Дата и время создания объекта")]
    public DateTime ObjectCreateDate { get; set; }
    
    void IEntityTypeConfiguration<TEntity>.Configure(EntityTypeBuilder<TEntity> builder)
    {
        Configure(builder);
        ConfigureIndexes(builder);
    }
    
    protected virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder.HasKey(p => p.Id);
    }

    protected virtual void ConfigureIndexes(EntityTypeBuilder<TEntity> builder)
    {
        
    }
}