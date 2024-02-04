using Domain.Base.Classes;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Entities;

[Table("uw_product_bill")]
public class UwProductBill : BaseEntity<UwProductBill>
{
	public required long Quantity { get; set; }
	public long ActualQuantity { get; set; }
	
	
	public  Guid ProductId {get;set;}

	public UwProduct Product { get; set;} = null!;

	public Guid BillId { get; set;}

	public UwBill Bill { get; set;} = null!;
	
	public string Barcode { get; set; }
}
