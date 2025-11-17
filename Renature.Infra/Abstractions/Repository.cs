using Microsoft.EntityFrameworkCore;
using Renature.Infra.Abstractions.Interfaces;
using Renature.Infra.Comuns;

namespace Renature.Infra.Abstractions;

public abstract class Repository<T>(DbContext context) : IRepository<T> where T : Entity
{
    protected readonly DbSet<T> dbSet = context.Set<T>();
    
    public virtual IQueryable<T> GetAll(Guid? id = null)
    {
        var result = dbSet.AsQueryable();
        
        return id is null
            ? result
            : result.Where(x => x.Id == id);
    }

    public virtual async Task<T?> GetById(Guid id)
    {
        return await dbSet.FirstOrDefaultAsync(entity => entity.Id == id);
    }

    public virtual async Task Add(T entity)
    {
        await dbSet.AddAsync(entity);
        await context.SaveChangesAsync();
    }

    public virtual async Task Update(T entity)
    {
        dbSet.Update(entity);
        await context.SaveChangesAsync();
    }

    public virtual async Task Remove(T entity)
    {
        dbSet.Remove(entity);
        await context.SaveChangesAsync();
    }
}