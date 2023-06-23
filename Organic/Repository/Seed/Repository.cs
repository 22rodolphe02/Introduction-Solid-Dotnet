using Organic.Repository.Interface;

namespace Organic.Repository.Seed;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly IReadRepository<T> _readRepository;
    private readonly IWriteRepository<T> _writeRepository;

    public Repository(IReadRepository<T> readRepository, IWriteRepository<T> writeRepository)
    {
        _readRepository = readRepository;
        _writeRepository = writeRepository;
    }

    public void Add(T entity)
    {
        _writeRepository.Add(entity);
    }

    public void Delete(T entity)
    {
        _writeRepository.Delete(entity);
    }

    public void Update(T entity)
    {
        _writeRepository.Update(entity);
        
    }

    public async Task<T> GetAsync(int id)
    {
        return await _readRepository.GetAsync(id);
    }

    public async Task<IEnumerable<T>> ToListAsync()
    {
        return await _readRepository.ToListAsync();
    }

    public async Task<PageResult<T>> ToListAsync(Page page)
    {
        return await _readRepository.ToListAsync(page);

    }
}