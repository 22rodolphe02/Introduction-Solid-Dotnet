namespace Organic.Repository.Interface;

public interface IWriteRepository<T> where T : class
{
    void Add(T entity);
    void Delete(T entity);
    void Update(T entity);
}