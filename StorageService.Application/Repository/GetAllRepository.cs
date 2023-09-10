using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using StorageService.Application.Repository.IRepository;
using StorageService.Domain.Entities;
using StorageService.Infrastructure.Data;

namespace StorageService.Application.Repository;

public class GetAllRepository : IGetAllRepository
{
    private readonly StorageServiceDbContext _db;

    public GetAllRepository(StorageServiceDbContext db)
    {
        _db = db;
    }

    private IQueryable<Advertisement> ApplySorting(IQueryable<Advertisement> query, SortOptions sortBy)
    {
        return sortBy switch
        {
            SortOptions.PriceAsc => query.OrderBy(a => a.Price),
            SortOptions.PriceDesc => query.OrderByDescending(a => a.Price),
            SortOptions.DateCreatedAsc => query.OrderBy(a => a.DateCreated),
            SortOptions.DateCreatedDesc => query.OrderByDescending(a => a.DateCreated),
            _ => query.OrderBy(a => a.DateCreated)  
        };
    }
    

    public async Task<List<Advertisement>> GetAllAsync(Expression<Func<Advertisement, bool>>? filter = null, 
        Pagination pagination = null)
    {
        IQueryable<Advertisement> query = _db.Advertisements;

        pagination ??= new Pagination();  
        query = filter != null ? query.Where(filter) : query;

        query = ApplySorting(query, pagination.SortBy);
    
        var skipAmount = pagination.PageSize * (pagination.PageNumber - 1);
        query = query.Skip(skipAmount).Take(pagination.PageSize);

        return await query.ToListAsync();
    }

}