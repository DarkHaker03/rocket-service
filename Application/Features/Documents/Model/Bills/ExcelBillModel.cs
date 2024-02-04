using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.Features.Documents.Model.Bills;


[Table("Отходная накладная")]
public class ExcelBillModel
{
	[DisplayName("Артикул")]
	public string Article { get; set; }

	[DisplayName("Кол -во шт , пар")]
	public required long Quantity { get; set; }

	[DisplayName("Дата отбытия")]
	public required DateTime WillLeaveAt { get; set; }
	
	[DisplayName("Наименование")]
	public required string Name { get; set; }
}
