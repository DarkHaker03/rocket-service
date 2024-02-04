
namespace Application.Base.Interfaces;

public interface ICollectionFilter
{
	public int? Skip { get; set; }

	public int? Take { get; set; }
}
