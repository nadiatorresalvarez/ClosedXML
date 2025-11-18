using Lab13Web_NadiaTorres.Application.Interfaces;
using Lab13Web_NadiaTorres.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab13Web_NadiaTorres.Infrastructure.Adapters.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly dbContextLab13 _context;
    
    public Repository(dbContextLab13 context)
    {
        _context = context;
    }
    public void AddEntity(T entity)
    {
        _context.Set<T>().Add(entity);
    }

    public async Task<T?> GetByIdAsync(Guid id)
    {
        return await _context.Set<T>().FindAsync(id);
    }
    
    public async Task<List<T>> GetAllAsync()
    {
        return await _context.Set<T>().ToListAsync();
    }
}