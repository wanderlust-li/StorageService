using StorageService.Application.Repository.IRepository;
using StorageService.Domain.Entities;
using StorageService.Infrastructure.Data;

namespace StorageService.Application.Repository;

public class AdvertisementRepository : Repository<Advertisement>, IAdvertisementRepository
{
    private readonly StorageServiceDbContext _db;

    public AdvertisementRepository(StorageServiceDbContext db) : base(db)
    {
        _db = db;
    }

    public async Task<Advertisement> UpdateAsync(Advertisement entity)
    {
        _db.Advertisements.Update(entity);
        await _db.SaveChangesAsync();

        return entity;
    }
}