using Organic.Repository.Interface;

namespace Organic.Services.Seed;

public abstract class BaseService
{
    protected readonly IUnitOfWork UnitOfWork;

    protected BaseService(IUnitOfWork unitOfWork)
    {
        UnitOfWork = unitOfWork;
    }
}