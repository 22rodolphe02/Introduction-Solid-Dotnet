using Organic.Data;
using Organic.Repository.Interface;

namespace Organic.Repository.Seed;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;
    
    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }
    public Task<int> SaveChangeAsync()
    {
        return _context.SaveChangesAsync();
    }
}