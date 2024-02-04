using Application.Base.Interfaces;

namespace Application.Features.Documents.Filters;

public class DocumentsFilter : ICollectionFilter
{
	public int? Skip { get; set; }
	public int? Take { get; set; }
}
