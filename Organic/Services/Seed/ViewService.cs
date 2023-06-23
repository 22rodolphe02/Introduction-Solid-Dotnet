using Organic.Repository;
using Organic.Repository.Interface;

namespace Organic.Services.Seed;

public class ViewService<T> : IViewService<T> where T : class
{
    protected readonly IReadRepository<T> _repository;

    public ViewService(IReadRepository<T> repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<T>> List()
    {
        return await _repository.ToListAsync();
    }

    public async Task<PageResult<T>> List(Page page)
    {
        return await _repository.ToListAsync(page);
    }
}