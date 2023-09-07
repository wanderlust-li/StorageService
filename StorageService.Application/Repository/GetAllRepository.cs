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
        int pageSize = 0, int pageNumber = 1, string? sortBy = null)
    {
        IQueryable<Advertisement> query = _db.Advertisements;

        if (filter != null)
        {
            query = query.Where(filter);
        }
        switch (sortBy)
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
                query = query.OrderByDescending(a => a.DateCreated);
                break;
        }
        
        var skipAmount = pageSize * (pageNumber - 1);
        query = query.Skip(skipAmount).Take(pageSize);

        return await query.ToListAsync();
        
    }
}