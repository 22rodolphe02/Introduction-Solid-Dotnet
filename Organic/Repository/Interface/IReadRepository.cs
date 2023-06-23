namespace Organic.Repository.Interface;

public interface IReadRepository<T> where T : class
{
    Task<T> GetAsync(int id);
    Task<IEnumerable<T>> ToListAsync();
    Task<PageResult<T>> ToListAsync(Page page);
}