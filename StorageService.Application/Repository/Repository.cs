using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using StorageService.Application.Repository.IRepository;
using StorageService.Domain.Entities;
using StorageService.Infrastructure.Data;

namespace StorageService.Application.Repository;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly StorageServiceDbContext _db;
    private DbSet<T> dbSet;

    public Repository(StorageServiceDbContext db)
    {
        _db = db;
        this.dbSet = _db.Set<T>();
    }

    public async Task<List<Advertisement>> GetAllAsync(Expression<Func<Advertisement, bool>>? filter = null, int pageSize = 0, int pageNumber = 1,
        string? sortBy = null);
    {
        
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