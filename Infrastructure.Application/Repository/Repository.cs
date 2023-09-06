using System.Linq.Expressions;
using Infrastructure.Application.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using StorageService.Infrastructure.Data;

namespace Infrastructure.Application.Repository;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly StorageServiceDbContext _db;
    private DbSet<T> dbSet;

    public Repository(StorageServiceDbContext db)
    {
        _db = db;
        this.dbSet = _db.Set<T>();
    }

    public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null)
    {
        IQueryable<T> query = dbSet;

        if (filter != null)
            query = query.Where(filter);


        return await query.ToListAsync();
    }

    public async Task<T> GetAsync(Expression<Func<T, bool>> filter = null, bool tracked = true)
    {
        IQueryable<T> query = dbSet;

        if (!tracked)
            query = query.AsNoTracking();

        if (filter != null)
            query = query.Where(filter);

        return await query.FirstOrDefaultAsync();
    }

    public async Task CreateAsync(T entity)
    {
        await dbSet.AddAsync(entity);
        await SaveAsync();
    }

    public async Task RemoveAsync(T entity)
    {
        dbSet.Remove(entity);
        await SaveAsync();
    }

    public async Task SaveAsync()
    {
        await _db.SaveChangesAsync();
    }
}