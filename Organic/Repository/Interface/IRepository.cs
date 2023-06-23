namespace Organic.Repository.Interface;

public interface IRepository<T> : IReadRepository<T>, IWriteRepository<T> where T : class
{
    
}