using Domain.Base.Interfaces;

namespace Domain.Base.Classes;

public class BaseHaveId : IBaseHaveId
{
    public Guid Id { get; set; }
}
