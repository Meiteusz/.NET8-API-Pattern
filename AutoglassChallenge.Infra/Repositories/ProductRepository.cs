using AutoglassChallenge.Domain.Entities;
using AutoglassChallenge.Domain.Repositories;

namespace AutoglassChallenge.Infra.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        private readonly AutoglassChallengeContext _context;

        public ProductRepository(AutoglassChallengeContext context) : base(context) 
        {
            _context = context;
        }

        public bool ExistsProductBySupplierId(long supplierId)
            => _context.Products.Any(x => x.SupplierId == supplierId);
    }
}