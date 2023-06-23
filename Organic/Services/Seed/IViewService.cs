using Organic.Repository;

namespace Organic.Services.Seed;

public interface IViewService<T> where T : class
{
    Task<IEnumerable<T>> List();

    Task<PageResult<T>> List(Page page);
}