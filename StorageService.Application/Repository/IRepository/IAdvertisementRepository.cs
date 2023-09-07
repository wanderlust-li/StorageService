using StorageService.Domain.Entities;

namespace StorageService.Application.Repository.IRepository;

public interface IAdvertisementRepository: IRepository<Advertisement>
{
    Task<Advertisement> UpdateAsync(Advertisement entity);
}