using AutoglassChallenge.Domain.Entities;
using AutoglassChallenge.Domain.Repositories;

namespace AutoglassChallenge.Infra.Repositories
{
    public class SupplierRepository : BaseRepository<Supplier>, ISupplierRepository
    {
        public SupplierRepository(AutoglassChallengeContext context) : base(context) { }
    }
}