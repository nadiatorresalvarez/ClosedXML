using Lab13Web_NadiaTorres.Application.Interfaces;
using Lab13Web_NadiaTorres.Infrastructure.Models;

namespace Lab13Web_NadiaTorres.Infrastructure.Adapters.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly dbContextLab13 _context;

    public UnitOfWork(dbContextLab13 context)
    {
        _context = context;
    }
    public IRepository<T> Repository<T>() where T : class
    {
        return new Repository<T>(_context);
    }

    public async Task Complete()
    {
        await _context.SaveChangesAsync();
    }
}