using Domain.Base.Interfaces;

namespace Domain.Base.Classes;

public class BaseHaveObjectCreateData : IBaseHaveObjectCreateData
{
    public DateTime ObjectCreateDate { get; set; }
}
