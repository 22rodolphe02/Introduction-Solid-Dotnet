using Microsoft.EntityFrameworkCore;
using Organic.Data;

namespace Organic.Repository.Seed;

public class BaseRepository<T> where T : class
{
    private readonly AppDbContext _dbContext;
    private DbSet<T> _dbSet;

    protected DbSet<T> DbSet => _dbSet ??= _dbContext.Set<T>();

    protected BaseRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
}