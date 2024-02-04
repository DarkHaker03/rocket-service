using Data;

namespace Application.Base.Services;

public abstract class BaseDbService
{
    public BaseDbService(RDbContext dbContext)
    {
        MasterDbContext = dbContext;
    }

    protected readonly RDbContext MasterDbContext;
}