using Microsoft.EntityFrameworkCore;
using Organic.Data;
using Organic.Models;
using Organic.Repository.Interface;

namespace Organic.Repository.Seed;

public class ReadRepository<T> : BaseRepository<T> ,IReadRepository<T> where T : class
{
    public ReadRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
    
    public async Task<T> GetAsync(int id)
    {
        return await DbSet.FirstOrDefaultAsync(_ => (_ as EntityBase).Id == id);
    }

    public async Task<IEnumerable<T>> ToListAsync()
    {
        return await DbSet.ToListAsync();
    }

    public async Task<PageResult<T>> ToListAsync(Page page)
    {
        var result = await DbSet
            .Skip((page.Number - 1) * page.Size)
            .Take(page.Size)
            .ToListAsync();

        // var total = (int)Math.Ceiling(DbSet.Count() / (double) page.Size);

        return PageResult<T>.GetInstance(page.Number, page.Size, DbSet.Count(), result);
    }
}