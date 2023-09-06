using StorageService.Domain.Entities;

namespace Infrastructure.Application.Repository.IRepository;

public interface IAdvertisementRepository: IRepository<Advertisement>
{
    Task<Advertisement> UpdateAsync(Advertisement entity);
}