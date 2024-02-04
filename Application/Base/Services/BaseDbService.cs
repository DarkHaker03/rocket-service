using Data;

namespace Application.Base.Services;

public abstract class BaseDbService
{
    public BaseDbService(UWDbContext dbContext)
    {
        MasterDbContext = dbContext;
    }

    protected readonly UWDbContext MasterDbContext;
}