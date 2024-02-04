using Domain.Base.Classes;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Entities;

/// <summary>
/// Линк, связывающий корзину с ячейкой
/// </summary>
[Table("uw_basket_received_product_link")]
public class UwBasketReceivedProductLink : BaseEntity<UwBasketReceivedProductLink>
{
	/// <summary>
	/// Идентификатор товара в ячейке на складе
	/// </summary>
	public required Guid ReceivedProductCellId { get; set; }

	/// <summary>
	/// Товар в ячейке на складе
	/// </summary>
	public UwReceivedProductCell ReceivedProductCell { get; set; } = null!;

	/// <summary>
	/// Идентификатор корзины
	/// </summary>
	public required Guid BasketId { get; set; }

	/// <summary>
	/// Корзина
	/// </summary>
	public UwBasket Basket { get; set; } = null!;

	protected override void Configure(EntityTypeBuilder<UwBasketReceivedProductLink> builder)
	{
		builder.HasOne(q => q.Basket)
			.WithMany(q => q.ProductLinks);

		builder.HasOne(q => q.ReceivedProductCell)
			.WithMany(q => q.BasketReceivedProductLinks);
		
		base.Configure(builder);
	}
}
