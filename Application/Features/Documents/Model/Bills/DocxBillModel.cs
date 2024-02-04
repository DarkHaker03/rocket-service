using Domain.Entities;
using System.ComponentModel;

namespace Application.Features.Documents.Model;

public class DocxBillModel
{
	[DisplayName("Название компании")]
	public required string CompanyName { get; set; }

	[DisplayName("Инн")]
	public required string CompanyInn { get; set; }

	[DisplayName("Номер счета")]
	public required string BillNumber { get; set; }

	[DisplayName("Товары")]
	public required IEnumerable<UwProduct> Products { get; set; }

	[DisplayName("Имя пользователя")]
	public required string UserName { get; set; }
}
