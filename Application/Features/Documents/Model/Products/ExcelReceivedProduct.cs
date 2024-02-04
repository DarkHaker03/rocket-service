using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.Features.Documents.Model.Products;

[Table("Принятые товары")]
public class ExcelReceivedProduct
{
	[DisplayName("Артикль")]
	public string Article { get; set; }

	[DisplayName("Количество")]
	public long Quantity { get; set; }

}
