namespace Renature.Infra.Abstractions.Interfaces;

public interface IRepository<T> where T : class
{
    IQueryable<T> GetAll();

    Task<T?> GetById(Guid id);

    Task Add(T entity);

    Task Update(T entity);

    Task Remove(T entity);
}