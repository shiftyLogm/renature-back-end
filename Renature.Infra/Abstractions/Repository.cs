using Microsoft.EntityFrameworkCore;
using Renature.Infra.Abstractions.Interfaces;
using Renature.Infra.Comuns;

namespace Renature.Infra.Abstractions;

public abstract class Repository<T>(DbContext context) : IRepository<T> where T : Entity
{
    private readonly DbSet<T> _dbSet = context.Set<T>();
    private readonly DbContext _context = context;
    
    public virtual IQueryable<T> GetAll()
    {
        return _dbSet.AsQueryable();
    }

    public virtual async Task<T?> GetById(Guid id)
    {
        return await _dbSet.FirstOrDefaultAsync(entity => entity.Id == id);
    }

    public virtual async Task Add(T entity)
    {
        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public virtual async Task Update(T entity)
    {
        _dbSet.Update(entity);
        await _context.SaveChangesAsync();
    }

    public virtual async Task Remove(T entity)
    {
        _dbSet.Remove(entity);
        await _context.SaveChangesAsync();
    }
}