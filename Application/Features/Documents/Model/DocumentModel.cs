using Application.Features.Documents.Model.Enums;

namespace Application.Features.Documents.Model;

public class DocumentModel
{
	public required Guid EntityId { get; set; }

	public required DocumentTypes DocumentType { get; set; }

	public string Description { get; set; } = "";
	public string Name { get; set; } = "";

	public required DocumentFileTypes FileTypes { get; set; }
}
