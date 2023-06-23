using Organic.Data;
using Organic.Repository.Interface;

namespace Organic.Repository.Seed;

public class WriteRepository<T>  : BaseRepository<T> ,IWriteRepository<T> where T : class
{
    public WriteRepository(AppDbContext dbContext) : base(dbContext)
    {
    }

    public void Add(T entity)
    {
        DbSet.Add(entity);
    }

    public void Delete(T entity)
    {
        DbSet.Remove(entity);
    }

    public void Update(T entity)
    {
        DbSet.Update(entity);
        
    }
}