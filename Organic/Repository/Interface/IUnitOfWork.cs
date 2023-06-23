namespace Organic.Repository.Interface;

public interface IUnitOfWork
{
    Task<int> SaveChangeAsync();
}