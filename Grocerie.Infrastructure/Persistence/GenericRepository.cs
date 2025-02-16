using Grocerie.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Grocerie.Infrastructure.Persistence;

public class GenericRepository<T>(ApplicationDbContext context, DbSet<T> dbSet) : IGenericRepository<T>
    where T : class
{
    
    public async Task<IEnumerable<T>> GetAllAsync() => await dbSet.ToListAsync();

    public async Task<T?> GetByIdAsync(Guid id) => await dbSet.FindAsync(id);

    public async Task AddAsync(T entity) => await dbSet.AddAsync(entity);

    public void Update(T entity) => dbSet.Update(entity);

    public void Delete(T entity) => dbSet.Remove(entity);

    public async Task SaveChangesAsync() => await context.SaveChangesAsync();
}