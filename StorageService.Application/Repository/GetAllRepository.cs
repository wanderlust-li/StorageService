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


    public async Task<List<Advertisement>> GetAllAsync(Expression<Func<Advertisement, bool>>? filter = null, 
        Pagination pagination = null)
    {
        IQueryable<Advertisement> query = _db.Advertisements;

        if (pagination == null)
        {
            pagination = new Pagination(); // Defaults to 10 items per page, and sortBy dateCreatedAsc
        }
        
        if (filter != null)
        {
            query = query.Where(filter);
        }
        switch (pagination.SortBy)
        {
            case "priceAsc":
                query = query.OrderBy(a => a.Price);
                break;
            case "priceDesc":
                query = query.OrderByDescending(a => a.Price);
                break;
            case "dateCreatedAsc":
                query = query.OrderBy(a => a.DateCreated);
                break;
            case "dateCreatedDesc":
                query = query.OrderByDescending(a => a.DateCreated);
                break;
            default:
                query = query.OrderBy(a => a.DateCreated);
                break;
        }

        var skipAmount = pagination.PageSize * (pagination.PageNumber - 1);
        query = query.Skip(skipAmount).Take(pagination.PageSize);

        return await query.ToListAsync();
        
    }
}