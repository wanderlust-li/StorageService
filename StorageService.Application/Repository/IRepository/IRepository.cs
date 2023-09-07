using System.Linq.Expressions;
using StorageService.Domain.Entities;

namespace StorageService.Application.Repository.IRepository;

public interface IRepository<T> where T: class
{
    // Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null, int pageSize = 0, int pageNumber = 1,
    //     string? sortBy = null);
    
    Task<T> GetAsync(Expression<Func<T, bool>> filter = null, bool tracked = true);
    
    Task CreateAsync(T entity);

    Task RemoveAsync(T entity);

    Task SaveAsync();
}