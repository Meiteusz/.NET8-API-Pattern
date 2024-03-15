using AutoglassChallenge.Domain.Entities;

namespace AutoglassChallenge.Domain.Repositories
{
    public interface IProductRepository : IBaseRepository<Product> 
    {
        bool ExistsProductBySupplierId(long supplierId);
    }
}
