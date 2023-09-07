using System.Linq.Expressions;
using StorageService.Domain.Entities;

namespace StorageService.Application.Repository.IRepository;

public interface IGetAllRepository 
{
    Task<List<Advertisement>> GetAllAsync(Expression<Func<Advertisement, bool>>? filter = null, 
        int pageSize = 10, int pageNumber = 1, string? sortBy = null);
}